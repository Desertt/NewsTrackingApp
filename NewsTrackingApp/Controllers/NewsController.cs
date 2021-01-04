using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NewsTrackingApp.Models;

namespace NewsTrackingApp.Controllers
{
    public class NewsController : Controller
    {
        private NTDBEntities dbcontext = new NTDBEntities();


        public ActionResult Index()
        {

            return View();
        }



        public ActionResult News_Read([DataSourceRequest] DataSourceRequest request)
        {

            List<HaberViewModel> news = dbcontext.Database.SqlQuery<HaberViewModel>("exec sp_SelectAllNews").OrderByDescending(x => x.Id).ToList();
            return Json(news.ToDataSourceResult(request));
        }



        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(dbcontext.Tbl_Kategori, "Id", "KategoriAdi");
            return View();

        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriId,HaberBaslik,HaberIcerik")] Tbl_Haber tbl_Haber)
        {
            if (ModelState.IsValid)
            {


                dbcontext.Database.ExecuteSqlCommand("exec sp_InsertNews @KategoriId,@HaberBaslik,@HaberIcerik",
                    new SqlParameter("@KategoriId", tbl_Haber.KategoriId),
                    new SqlParameter("@HaberBaslik", tbl_Haber.HaberBaslik),
                    new SqlParameter("@HaberIcerik", tbl_Haber.HaberIcerik)
                    );
                return RedirectToAction("Index");

            }

            ViewBag.KategoriId = new SelectList(dbcontext.Tbl_Kategori, "Id", "KategoriAdi", tbl_Haber.KategoriId);
            return View(tbl_Haber);
        }

      


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Haber tbl_Haber = dbcontext.Tbl_Haber.Find(id);
            if (tbl_Haber == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(dbcontext.Tbl_Kategori, "Id", "KategoriAdi", tbl_Haber.KategoriId);
            return View(tbl_Haber);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriId,HaberBaslik,HaberIcerik")] Tbl_Haber tbl_Haber)
        {
            if (ModelState.IsValid)
            {


                dbcontext.Database.ExecuteSqlCommand("exec sp_UpdateNews @id,@KategoriId,@HaberBaslik,@HaberIcerik",
                    new SqlParameter("@id", tbl_Haber.Id),
                    new SqlParameter("@KategoriId", tbl_Haber.KategoriId),
                    new SqlParameter("@HaberBaslik", tbl_Haber.HaberBaslik),
                    new SqlParameter("@HaberIcerik", tbl_Haber.HaberIcerik)
                    );
                return RedirectToAction("Index");


            }
            ViewBag.KategoriId = new SelectList(dbcontext.Tbl_Kategori, "Id", "KategoriAdi", tbl_Haber.KategoriId);
            return View(tbl_Haber);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Haber tbl_Haber = dbcontext.Tbl_Haber.Find(id);
            if (tbl_Haber == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Haber);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Haber tbl_Haber = dbcontext.Tbl_Haber.Find(id);

            dbcontext.Database.ExecuteSqlCommand("exec sp_DeleteNews @id",
                    new SqlParameter("@id", tbl_Haber.Id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbcontext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
