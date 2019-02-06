using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_WithMongo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.students_collection =
                    Models.MongoHelper.database.GetCollection<Models.Student>("students");

                Object id = GenerateRandomID(24);

                Models.MongoHelper.students_collection.InsertOneAsync(new Models.Student {
                    _id = id,
                    firstName = collection["firstName"],
                    lastName = collection["lastName"],
                    emailAddress = collection["emailAddress"]
                });

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray,v).Select(s=>s[random.Next(s.Length)]).ToArray());
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
