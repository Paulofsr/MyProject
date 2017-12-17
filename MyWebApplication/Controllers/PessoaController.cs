using MyLibrary.DAO;
using MyLibrary.Entinty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            PessoaDAO dao = new PessoaDAO();
            return View(dao.GetAll());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(string id)
        {
            PessoaDAO dao = new PessoaDAO();
            return View(dao.GetById(new Guid(id)));
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View(new Pessoa());
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa obj)
        {
            try
            {
                // TODO: Add insert logic here

                PessoaDAO dao = new PessoaDAO();
                dao.Insert(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(string id)
        {

            PessoaDAO dao = new PessoaDAO();
            return View(dao.GetById(new Guid(id)));
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Pessoa collection)
        {
            try
            {
                // TODO: Add update logic here

                PessoaDAO dao = new PessoaDAO();
                dao.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(string id)
        {
            PessoaDAO dao = new PessoaDAO();
            return View(dao.GetById(new Guid(id)));
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Pessoa collection)
        {
            try
            {
                // TODO: Add delete logic here

                PessoaDAO dao = new PessoaDAO();
                dao.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
