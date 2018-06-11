using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAMS.DAL;

namespace PAMS.Controllers
{
    public class ClientController : Controller
    {
        clientEntities obj = new clientEntities();
        PAMS.Services.AutoGenerate objservice = new Services.AutoGenerate();
        // GET: Client
        public ActionResult Index()
        {

            IEnumerable<tblClient> ie = obj.tblClients.ToList();
            return View(ie);
        }

        // GET: Client/Details/5
        public ActionResult Details(string id)
        {
            PAMS.DAL.tblClient cl = obj.tblClients.Find(id);
            return View(cl);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            Models.AutoGenerate objModelAuto = new Models.AutoGenerate();
            objModelAuto.TableName = "tblClient";
            objModelAuto.ColumnName = "clientId";
            string s = objservice.AutoGenerateId(objModelAuto);
            PAMS.DAL.tblClient objmodelclient = new tblClient();
            objmodelclient.clientId = s;

            return View(objmodelclient);
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(PAMS.DAL.tblClient objmodelclient)
        {
            int bf = obj.tblClients.Count();
            obj.tblClients.Add(objmodelclient);
            obj.SaveChanges();
            int af = obj.tblClients.Count();
            if (af > bf)
            {
                return RedirectToAction("Create");
            }
            else
                return View();
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

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
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

        // GET: Client/Delete/5
        public ActionResult Delete(string id)
        {
            PAMS.DAL.tblClient cl = obj.tblClients.Find(id);
            obj.tblClients.Remove(cl);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Client/Delete/5
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
