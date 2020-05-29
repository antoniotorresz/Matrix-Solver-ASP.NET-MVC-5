using Matrix_Solver.Models;
using Matrix_Solver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matrix_Solver.Controllers
{
    public class ResistenciaController : Controller
    {
        // GET: Resistencia
        public ActionResult Index()
        {
            UResistencia ur = new UResistencia();
            ViewBag.resistencias = ur.ObtenerActivas();
            return View();
        }

        // GET: Resistencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resistencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resistencia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Resistencia r = new Resistencia();
                Random rnd = new Random();

                r.Id = "R" + rnd.Next(2000) + DateTime.Now.ToString("HHmmss") + rnd.Next(10);

                r.Banda1 = Convert.ToString(collection["Banda1"]);
                r.Banda2 = Convert.ToString(collection["Banda2"]);
                r.Banda3 = Convert.ToString(collection["Banda3"]);
                r.Tolerancia = Convert.ToString(collection["Tolerancia"]);

                UResistencia ur = new UResistencia();
                ur.GuardarResistencia(r);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resistencia/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            UResistencia ur = new UResistencia();
            List<Resistencia> resistencias = ur.ObtenerActivas();
            Resistencia item = resistencias.SingleOrDefault(x => x.Id == id);

            return View(item);
        }

        // POST: Resistencia/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (id != null)
                {
                    UResistencia ur = new UResistencia();
                    List<Resistencia> resistencias = ur.ObtenerActivas();

                    int index = resistencias.FindIndex(r => r.Id == id);
                    Resistencia item = resistencias.ElementAt(index);

                    item.Banda1 = Convert.ToString(collection["Banda1"]);
                    item.Banda2 = Convert.ToString(collection["Banda2"]);
                    item.Banda3 = Convert.ToString(collection["Banda3"]);
                    item.Tolerancia = Convert.ToString(collection["Tolerancia"]);

                    resistencias[index] = item;

                    ur.ActualizarTxt(resistencias);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resistencia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id != null)
            {
                UResistencia ur = new UResistencia();
                List<Resistencia> resistencias = ur.ObtenerActivas();
                var item = resistencias.SingleOrDefault(x => x.Id == id);
                resistencias.Remove(item);
                ur.ActualizarTxt(resistencias);
                ViewBag.resistencias = ur.ObtenerActivas();
            }
            return RedirectToAction("Index");
        }
    }
}
