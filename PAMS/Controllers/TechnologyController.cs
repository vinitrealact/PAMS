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
        //  DAL.Technology objdaltech = new DAL.Technology();
        clientEntities obj = new clientEntities();
        Services.AutoGenerate objservices = new Services.AutoGenerate();
        // GET: Technology
        public ActionResult Index()
        {
            //IEnumerable<Models.Technology> ie =obj.selectTechnology().ToList();
            return View(obj.technologies.ToList());
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
        public ActionResult Create(DAL.technology objmodtech)
        {
            Models.AutoGenerate objmodauto = new Models.AutoGenerate();
            //  Models.Technology objmodtech = new Models.Technology();
            int bf = obj.technologies.Count();
            obj.technologies.Add(objmodtech);
            obj.SaveChanges();
            int af = obj.technologies.Count();
            objmodauto.TableName = "technology";
            objmodauto.ColumnName = "techid";
            objmodtech.techid = objservices.AutoGenerateId(objmodauto);

            if (af > bf)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View();
            }

            // return RedirectToAction("Create");//View(objmodtech);
        }

        // GET: Technology/Edit/5
        public ActionResult Edit(string id)
        {
            DAL.technology daltech = obj.technologies.Find(id);
            Models.Technology objmodtech = new Models.Technology();
            //objmodtech.techid = id;
            //int i = objdaltech.AddTechnology(objmodtech);
            return View(daltech);
        }

        // POST: Technology/Edit/5
        [HttpPost]
        public ActionResult Edit(DAL.technology objdalTech)
        {

            obj.Entry(objdalTech).State = System.Data.Entity.EntityState.Modified;
            obj.SaveChanges();
            return RedirectToAction("Index");

            try
            {
                // TODO: Add update logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: Technology/Delete/5
        public ActionResult Delete(string id)
        {
            PAMS.DAL.technology cl = obj.technologies.Find(id);
            obj.technologies.Remove(cl);
            obj.SaveChanges();
            //Models.Technology objmodeltech = new Models.Technology();
            //objmodeltech.techid = id;
            //int i = objdaltech.deleteTechnology(objmodeltech);

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
