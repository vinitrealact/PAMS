using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAMS.DAL;
using PAMS.Models;
using PAMS.Services;
namespace PAMS.Controllers
{
    public class TechnologyController : Controller
    {
        DAL.Technology objdaltech = new DAL.Technology();
        Services.AutoGenerate objservices = new Services.AutoGenerate();
        // GET: Technology
        public ActionResult Index()
        {
            IEnumerable<Models.Technology> ie = objdaltech.selectTechnology().ToList();
            return View(ie);
        }

        // GET: Technology/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Technology/Create
        public ActionResult Create()
        {
            Models.AutoGenerate objmodauto = new Models.AutoGenerate();
            Models.Technology objmodtech = new Models.Technology();
            objmodauto.TableName = "technology";
            objmodauto.ColumnName = "techid";
            objmodtech.techid = objservices.AutoGenerateId(objmodauto);
            return View(objmodtech);
        }

        // POST: Technology/Create
        [HttpPost]
        public ActionResult Create(Models.Technology objmodtech)
        {
            Models.AutoGenerate objmodauto = new Models.AutoGenerate();
            //  Models.Technology objmodtech = new Models.Technology();
            int i = objdaltech.AddTechnology(objmodtech);
            objmodauto.TableName = "technology";
            objmodauto.ColumnName = "techid";
            objmodtech.techid = objservices.AutoGenerateId(objmodauto);
            return RedirectToAction("Create");//View(objmodtech);
        }

        // GET: Technology/Edit/5
        public ActionResult Edit(string id)
        {
            Models.Technology objmodtech = new Models.Technology();
            objmodtech.techid = id;
            int i = objdaltech.AddTechnology(objmodtech);
            return View();
        }

        // POST: Technology/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
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

        // GET: Technology/Delete/5
        public ActionResult Delete(string id)
        {
            Models.Technology objmodeltech = new Models.Technology();
            objmodeltech.techid = id;
            int i = objdaltech.deleteTechnology(objmodeltech);

            return RedirectToAction("Index"); //View("Index");
        }

        // POST: Technology/Delete/5
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
