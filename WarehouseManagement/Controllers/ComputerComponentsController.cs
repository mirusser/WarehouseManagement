using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarehouseManagement.Logic.Factories.Interfaces;
using WarehouseManagement.Logic.Managers;
using WarehouseManagement.Logic.Managers.Interfaces;
using WarehouseManagement.Models;
using WarehouseManagement.Models.Context;

namespace WarehouseManagement.Controllers
{
    public class ComputerComponentsController : Controller
    {
        #region Properties
        private readonly IComputerComponentsManager computerComponentsManager;
        #endregion

        #region Constructors
        public ComputerComponentsController(IManagerFactory managerFactory)
        {
            computerComponentsManager = managerFactory.Get<ComputerComponentsManager>();
        }
        #endregion
        // GET: ComputerComponents
        public ActionResult Index()
        {
            var computerComponents = computerComponentsManager.GetAll();
            return View(computerComponents.ToList());
        }

        // GET: ComputerComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var computerComponents = computerComponentsManager.GetById(Convert.ToInt32(id));

            if (computerComponents == null)
            {
                return HttpNotFound();
            }
            return View(computerComponents);
        }

        // GET: ComputerComponents/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfSubassemblyId = new SelectList(computerComponentsManager.GetTypeOfSubassemblies(), "Id", "Name");
            return View();
        }

        // POST: ComputerComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatalogNumber,Name,TypeOfSubassemblyId,Model,Barcode")] ComputerComponents computerComponents)
        {
            if (ModelState.IsValid)
            {
                if (computerComponentsManager.Add(computerComponents) != null)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.TypeOfSubassemblyId = new SelectList(computerComponentsManager.GetTypeOfSubassemblies(), "Id", "Name", computerComponents.TypeOfSubassemblyId);
            return View(computerComponents);
        }

        // GET: ComputerComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var computerComponents = computerComponentsManager.GetById(Convert.ToInt32(id));
            if (computerComponents == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfSubassemblyId = new SelectList(computerComponentsManager.GetTypeOfSubassemblies(), "Id", "Name", computerComponents.TypeOfSubassemblyId);
            return View(computerComponents);
        }

        // POST: ComputerComponents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatalogNumber,Name,TypeOfSubassemblyId,Model,Barcode")] ComputerComponents computerComponents)
        {
            if (ModelState.IsValid)
            {
                computerComponentsManager.Modify(computerComponents);
                return RedirectToAction("Index");
            }
            ViewBag.TypeOfSubassemblyId = new SelectList(computerComponentsManager.GetTypeOfSubassemblies(), "Id", "Name", computerComponents.TypeOfSubassemblyId);
            return View(computerComponents);
        }

        // GET: ComputerComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var computerComponents = computerComponentsManager.GetById(Convert.ToInt32(id));
            if (computerComponents == null)
            {
                return HttpNotFound();
            }
            return View(computerComponents);
        }

        // POST: ComputerComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var computerComponents = computerComponentsManager.GetById(id);
            computerComponentsManager.Delete(computerComponents);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                computerComponentsManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
