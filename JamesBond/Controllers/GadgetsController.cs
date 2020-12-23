using JamesBond.Data;
using JamesBond.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JamesBond.Controllers
{
    public class GadgetsController : Controller
    {
        public IActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();
            //
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.fetchAll();
            return View("Index",gadgets);
        }
        public IActionResult Details(int id)
        {
            GadgetModel gadget = new GadgetModel();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadget = gadgetDAO.fetchById(id);
            return View("Details", gadget);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GadgetModel newModel)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Create(newModel);
            return View("Details", newModel);
        }

        public IActionResult Edit(int id)
        {
            GadgetModel gadget = new GadgetModel();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadget = gadgetDAO.fetchById(id);
            return View("Edit", gadget);
        }
        [HttpPost]
        public IActionResult Update(GadgetModel updateModel)
        {
            //GadgetModel gadget = new GadgetModel();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Update(updateModel);
            return View("Details", updateModel);
        }
        public IActionResult Delete(int id)
        {
            GadgetDAO gadgetDao = new GadgetDAO();
            gadgetDao.Delete(id);
            return Redirect("/gadgets");
        }
        public IActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public IActionResult SearchName(string Name)
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.SearchName(Name);
            return View("Index", gadgets);
        }
        public IActionResult SearchDescription(string Description)
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.SearchDescription(Description);
            return View("Index", gadgets);
        }
    }
}
