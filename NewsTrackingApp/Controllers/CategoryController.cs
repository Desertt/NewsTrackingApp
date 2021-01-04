using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NewsTrackingApp.Models;

namespace NewsTrackingApp.Controllers
{
    public class CategoryController : Controller
    {
        private NTDBEntities dbcontext = new NTDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<CategoryViewModel> categories = dbcontext.Database.SqlQuery<CategoryViewModel>("exec sp_SelectAllCategory").ToList();
            return Json(categories.ToDataSourceResult(request));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriAdi")] Tbl_Kategori tbl_Kategori)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Database.ExecuteSqlCommand("exec sp_InsertCategory @KategoriAdi",
                   new SqlParameter("@KategoriAdi", tbl_Kategori.KategoriAdi));
                return RedirectToAction("Index");
                
            }

            return View(tbl_Kategori);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kategori tbl_Kategori = dbcontext.Tbl_Kategori.Find(id);
            if (tbl_Kategori == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriAdi")] Tbl_Kategori tbl_Kategori)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Database.ExecuteSqlCommand("exec sp_UpdateCategory @id,@KategoriAdi",
                    new SqlParameter("@id", tbl_Kategori.Id),
                    new SqlParameter("@KategoriAdi", tbl_Kategori.KategoriAdi));
                return RedirectToAction("Index");

            }
            return View(tbl_Kategori);
        }

        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tbl_Kategori tbl_Kategori = dbcontext.Tbl_Kategori.Find(id);
            if (tbl_Kategori == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kategori);
        }


        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Kategori tbl_Kategori = dbcontext.Tbl_Kategori.Find(id);
            try
            {
                dbcontext.Database.ExecuteSqlCommand("exec sp_DeleteCategory @id",
                 new SqlParameter("@id", tbl_Kategori.Id));
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Silme işlemi gerçekleştirilemedi.Kategoriye bağlı haber bulunmaktadır!";
                return RedirectToAction("Delete");
            }

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
