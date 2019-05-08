using ProvaMundoMidia.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaMundoMidia.Controllers
{
    public class CarroController : Controller
    {
        private CarroDAO carroDAO;

        public CarroController()
        {
            carroDAO = new CarroDAO();
        }


        public ActionResult Index()
        {
            var carros = carroDAO.RetornarTodos();
            return View(carros);
        }
    }
}