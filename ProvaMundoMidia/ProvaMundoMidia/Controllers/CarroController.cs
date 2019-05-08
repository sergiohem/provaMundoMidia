using ProvaMundoMidia.DAOs;
using ProvaMundoMidia.Models;
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

        public PartialViewResult ObterModalCadastroEdicaoDeCarro(int idCarro, string acao = "CadastrarCarro")
        {
            ViewBag.Acao = acao;
            ViewBag.TituloModal = "Cadastrar Carro";
            Carro carro = new Carro();

            if (acao == "EditarCarro" && idCarro != 0)
            {
                carro = carroDAO.BuscarCarroPorId(idCarro);
                ViewBag.TituloModal = "Editar Carro";
            }

            return PartialView("_ModalCadastroEdicaoDeCarros", carro);
        }

        public ActionResult SalvarCarro(Carro carro, string acao)
        {
            Notificacao notif = new Notificacao();
            try
            {
                if (carro.IdCarro == 0)
                {
                    carroDAO.Inserir(carro);
                    List<Carro> listaDeCarrosAtualizada = new CarroDAO().RetornarTodos();
                    return PartialView("~/Views/Carro/_TabelaCarros.cshtml", listaDeCarrosAtualizada);
                }
                else
                {
                    Carro carroNoBanco = carroDAO.BuscarCarroPorId(carro.IdCarro);
                    if (carroNoBanco != null)
                    {
                        carroDAO.Alterar(carro);

                        notif.Mensagem = "Carro editado com sucesso!";
                        notif.Tipo = TipoNotificacao.SumirSozinha;
                        notif.Tema = TemaNotificacao.Sucesso;

                        return Json(notif, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        notif.Mensagem = "Carro não encontrado!";
                        notif.Tipo = TipoNotificacao.SumirSozinha;
                        notif.Tema = TemaNotificacao.Erro;

                        return Json(notif, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                notif.Mensagem = acao == "CadastrarCarro" ? "Erro ao salvar carro!" : "Erro ao editar carro!";
                notif.Tipo = TipoNotificacao.SumirSozinha;
                notif.Tema = TemaNotificacao.Erro;

                return Json(notif, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult ObterLinhaTabelaCarro(int idCarroEditado)
        {
            Carro carro = carroDAO.BuscarCarroPorId(idCarroEditado);
            if (carro != null)
            {
                return PartialView("~/Views/Carro/_LinhaTabelaCarros.cshtml", carro);
            }
            return null;
        }
    }
}