using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WadE16Crud.Models;
using System.Data;
using Dapper;
namespace WadE16Crud.Controllers
{
    public class UsersController : Controller
    {
        DapperHelper db;
        public UsersController()
        {
            db = new DapperHelper();
        }
        // GET: Users
        public ActionResult Index()
        {
            var model = db._connection.Query<AppUsers>("Select * from AppUsers").ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AppUsers u)
        {
            int r = db._connection.Execute("Insert Into AppUsers (Username, Password, Name) Values (@Username, @Password, @Name)", u);
            if(r>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = db._connection.Query<AppUsers>("Select * from AppUsers where Id = @Id",new { Id = id }).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AppUsers u)
        {
            int r = db._connection.Execute("Update AppUsers Set Username = @Username, Password= @Password, Name = @Name Where Id = @Id", u);
            if (r > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            int r = db._connection.Execute("Delete from AppUsers where Id = @Id", new { Id = id });
            if(r>0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}