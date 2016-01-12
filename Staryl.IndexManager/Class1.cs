using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Staryl.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Staryl.IndexManager
{
    public class IndexManager
    {
        public static readonly IndexManager starUserIndex = new IndexManager();
        public static readonly string indexPath = ConfigurationManager.AppSettings["IndexPath"];
        private IndexManager()
        {
        }
        //请求队列 解决索引目录同时操作的并发问题
        private Queue<IndexQueue> starUserQueue = new Queue<IndexQueue>();

        /// <summary>
        /// 新增Books表信息时 添加邢增索引请求至队列
        /// </summary>
        /// <param name="books"></param>
        public void Add(StarUserInfo user)
        {
            IndexQueue bvm = new IndexQueue();
            bvm.Id = user.Id;
            bvm.KeyWords = user.RealName;
            bvm.IT = IndexType.Insert;

            starUserQueue.Enqueue(bvm);
        }
        /// <summary>
        /// 删除Books表信息时 添加删除索引请求至队列
        /// </summary>
        /// <param name="bid"></param>
        public void Del(int bid)
        {
            IndexQueue bvm = new IndexQueue();
            bvm.Id = bid;
            bvm.IT = IndexType.Delete;
            starUserQueue.Enqueue(bvm);
        }
        /// <summary>
        /// 修改Books表信息时 添加修改索引(实质上是先删除原有索引 再新增修改后索引)请求至队列
        /// </summary>
        /// <param name="books"></param>
        public void Mod(StarUserInfo user)
        {
            IndexQueue bvm = new IndexQueue();
            bvm.Id = user.Id;
            bvm.KeyWords = user.RealName;
            bvm.IT = IndexType.Modify;

            starUserQueue.Enqueue(bvm);
        }

        public void StartNewThread()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(QueueToIndex));
        }

        //定义一个线程 将队列中的数据取出来 插入索引库中
        private void QueueToIndex(object para)
        {
            while (true)
            {
                if (starUserQueue.Count > 0)
                {
                    CRUDIndex();
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }
        /// <summary>
        /// 更新索引库操作
        /// </summary>
        private void CRUDIndex()
        {
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath + "\\starUser"), new NativeFSLockFactory());
            bool isExist = IndexReader.IndexExists(directory);
            if (isExist)
            {
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isExist, IndexWriter.MaxFieldLength.UNLIMITED);
            while (starUserQueue.Count > 0)
            {
                Document document = new Document();
                IndexQueue indexInfo = starUserQueue.Dequeue();
                if (indexInfo.IT == IndexType.Insert)
                {
                    document.Add(new Field("id", indexInfo.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    document.Add(new Field("title", indexInfo.KeyWords, Field.Store.YES, Field.Index.ANALYZED,
                                           Field.TermVector.WITH_POSITIONS_OFFSETS));

                    writer.AddDocument(document);
                }
                else if (indexInfo.IT == IndexType.Delete)
                {
                    writer.DeleteDocuments(new Term("id", indexInfo.Id.ToString()));
                }
                else if (indexInfo.IT == IndexType.Modify)
                {
                    //先删除 再新增
                    writer.DeleteDocuments(new Term("id", indexInfo.Id.ToString()));
                    document.Add(new Field("id", indexInfo.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    document.Add(new Field("title", indexInfo.KeyWords, Field.Store.YES, Field.Index.ANALYZED,
                                           Field.TermVector.WITH_POSITIONS_OFFSETS));
                    writer.AddDocument(document);
                }
            }
            writer.Close();
            directory.Close();
        }
    }

}
