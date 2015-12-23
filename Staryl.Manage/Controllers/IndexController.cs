using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staryl.Manage.Controllers
{
    public class IndexController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            return View();
        }

        //
        // GET: /Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AuthAttribute(FunCode = "create")]
        public ActionResult Create()
        {
            return View();
        }

        [AuthAttribute(FunCode = "create")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AuthAttribute(FunCode = "modify")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [AuthAttribute(FunCode = "modify")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Index/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
