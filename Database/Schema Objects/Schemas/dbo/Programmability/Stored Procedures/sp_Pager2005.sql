Create PROCEDURE [dbo].[sp_Pager2005] --sp_Pager2005 'xtest','*','ORDER BY ID ASC','xname like ''%222name%''',2,20,0,0
 
 @tblName nvarchar(255), -- 表名如：'xtest'
 @strGetFields nvarchar(1000) = '*', -- 需要返回的列如：'xname,xdemo'
 @strOrder nvarchar(255)='', -- 排序的字段名如：'order by id desc'
 @strWhere nvarchar(max) = '', -- 查询条件(注意:不要加where)如:'xname like ''%222name%''' 
 @pageIndex int = 1, -- 页码如：2
 @pageSize int = 20, -- 每页记录数如：20
 @recordCount  int  output, -- 记录总数
 @doCount bit=0 -- 非0则统计,为0则不统计(统计会影响效率)
 AS
 
declare @strSQL nvarchar(max)
 declare @strCount nvarchar(max)
 --总记录条数
 
 set @RecordCount = -111

 if(@doCount!=0)
 begin
	 if(@strWhere !='')
		 begin
			set @strCount='set @num=(select count(1) from dbo.['+ @tblName + '] where '+@strWhere+' )'
		 end
	 else
		 begin
			 set @strCount='set @num=(select count(1) from dbo.['+ @tblName + '] )'
		 end
		EXECUTE sp_executesql @strCount ,N'@num INT output',@RecordCount output
 end
 
if @strWhere !=''
 begin
 set @strWhere=' where '+@strWhere
 end
 if @PageIndex>1
		begin
			 set @strSQL=' With SQLPaging_WanJia_scofi   As (  Select Top('+str((@PageIndex)*@PageSize)+') ROW_NUMBER() OVER ( '+@strOrder+' ) as resultNum_WanJia_scofi, ' +' ' +@strGetFields+'   FROM dbo.['+@tblName+']   '+@strWhere+' )   ';
			 set @strSQL=@strSQL+	'select * from SQLPaging_WanJia_scofi where resultNum_WanJia_scofi >  '+str((@PageIndex-1)*@PageSize)+'   '
			 --set @strSQL='SELECT * FROM (SELECT ROW_NUMBER() OVER ( '+@strOrder+' ) AS ROWID,'
			 --set @strSQL=@strSQL+@strGetFields+' FROM dbo.['+@tblName+'] '+@strWhere
			 --set @strSQL=@strSQL+') AS sp WHERE ROWID BETWEEN '+str((@PageIndex-1)*@PageSize+1)
			 --set @strSQL=@strSQL+' AND '+str(@PageIndex*@PageSize)
			 
			 exec (@strSQL)
		end
else 
	begin
		 set @strSQL='select top '+STR(@PageSize)+' ' +@strGetFields+' FROM dbo.['+@tblName+'] '+@strWhere+'  '+ @strOrder;
		 
		 exec (@strSQL)
	end
