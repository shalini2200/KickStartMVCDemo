using KickStartMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KickStartMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
          {
            BusinessLogic businessLogic = new BusinessLogic();
            var childrenList = businessLogic.Children;
            return View(childrenList);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Children children)
        {
            if (ModelState.IsValid)
            {
                BusinessLogic businessLogic = new BusinessLogic();

                businessLogic.AddChildren(children);
                return RedirectToAction("Index");
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            Children children = businessLogic.Children.Single(child => child.ID == ID);
            return View(children);
        }
        [HttpPost]
        public ActionResult Edit(Children children)
        {
            if (ModelState.IsValid)
            {
                BusinessLogic businessLogic = new BusinessLogic();
                businessLogic.SaveChild(children);

                return RedirectToAction("Index");
            }
            return View(children);
        }
       [HttpPost]
        public ActionResult Delete(int id)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            businessLogic.DeleteChild(id);
            return RedirectToAction("Index");
        }
    }
}