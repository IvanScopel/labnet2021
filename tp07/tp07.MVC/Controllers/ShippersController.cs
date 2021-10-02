using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp04.Logic;
using tp07.MVC.Models;
using tp04.Data;
using tp04.Entities;

namespace tp07.MVC.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        ShippersLogic shippersLogic = new ShippersLogic();

        public ActionResult Index()
        {
            List<tp04.Entities.Shippers> shippers = shippersLogic.GetAll();

            List<ShippersView> shippersViews = shippers.Select(s => new ShippersView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone

            }).ToList();
            return View(shippersViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ShippersView shippersView)
        {
            Shippers shippersEnt = new Shippers
            {
                ShipperID = shippersView.ShipperID,
                CompanyName = shippersView.CompanyName,
                Phone = shippersView.Phone
            };

            if (shippersView.ShipperID == 0)
            {

                try
                {
                    shippersLogic.Add(shippersEnt);

                }
                catch (Exception e)
                {

                    ModelState.AddModelError("", e);
                    return View("Error");
                }



            }
            else
            {
                try
                {
                    shippersLogic.Update(shippersEnt);
                }
                catch (Exception e)
                {

                    ModelState.AddModelError("", e);
                    return View("Error");
                }
            }
            

            return RedirectToAction("Index");
        }




        public ActionResult Modify(int id)
        {
            Shippers shippers = shippersLogic.Search(id);

            if (shippers == null)
                return HttpNotFound();

            ShippersView shippersView = new ShippersView
            {
                ShipperID = shippers.ShipperID,
                CompanyName = shippers.CompanyName,
                Phone = shippers.Phone
            };
            return View("Insert", shippersView);
        }

        public ActionResult Delete(int id)
        {
            shippersLogic.Delete(id);

            return RedirectToAction("Index");
        }
    }



}