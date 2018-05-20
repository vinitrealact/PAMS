using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAMS.DAL;
using PAMS.Services;
using PAMS.Models;
namespace PAMS.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DAL.Dept objDalDept = new Dept();
        Services.AutoGenerate objServiceAuto = new Services.AutoGenerate();
        public ActionResult Index()
        {
            IEnumerable<Models.Department> ie = objDalDept.GetDept().ToList();
            return View(ie);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        [HttpGet]
        public ActionResult Create()
        {
            Models.AutoGenerate objModelAuto = new Models.AutoGenerate();
            Models.Department objModelDepartment = new Department();
            objModelAuto.TableName = "dept";
            objModelAuto.ColumnName = "dno";
            objModelDepartment.Dno =objServiceAuto.AutoGenerateId(objModelAuto);
            return View(objModelDepartment);
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Models.Department objModelDepartment)
        {
            try
            {
                // TODO: Add insert logic here
                int i = objDalDept.AddDept(objModelDepartment);
                if(i==1)
                {
                    Models.AutoGenerate objModelAutoGenerate = new Models.AutoGenerate();
                    objModelAutoGenerate.TableName = "dept";
                    objModelAutoGenerate.ColumnName = "dno";
                    objModelDepartment.Dno = objServiceAuto.AutoGenerateId(objModelAutoGenerate);
                    ViewBag.message = "Department added";
                    return View(objModelDepartment);
                }
                 return View();

                // return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();

                // return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
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

        // GET: Department/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            Models.Department objModelDepartment = new Department();
            objModelDepartment.Dno = id;
            int i = objDalDept.DeleteDept(objModelDepartment);
            return RedirectToAction("Index");

        }

      
    }
}
