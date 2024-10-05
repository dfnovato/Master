using PA.Web.Domain;
using PA.Web.Models;

using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text;


namespace PA.Web.Controllers
{
    public class MenuController : Controller
    {
        private List<QuadroAvisoVO> lstQuadroAviso;


        // GET: Menu
        public ActionResult Index()
        {
            if (Session["UsuarioSession"] == null)
            {
                return RedirectToAction("../");
            }
            // ViewBag.QuadroAviso = new QuadroAvisoBO().ObterPorFiltro(new QuadroAvisoVO()).ToList().OrderByDescending(x => x.Id);

            //lstQuadroAviso = Fachada.Instancia.ObterPorFiltro(new QuadroAvisoVO()).Take(6).ToList();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlQuadroAviso = new StringBuilder();



           // foreach (var item in lstQuadroAviso)
           // {
           //     sql = new StringBuilder();
           //     sql.AppendLine("<li>");
           //     sql.AppendLine(" <a href='../QuadroAviso/Index'>");
           //     sql.AppendLine("<div>");
           //     sql.AppendLine("<i class='fa fa-comment fa-fw'></i> "+ item.Assunto + " ");
           //     sql.AppendLine("<span class='pull-right text-muted small'>" + item.Data + "</span>");
           //     sql.AppendLine("</div>");
           //     sql.AppendLine("</a>");
           //     sql.AppendLine("</li>");
           //     sql.AppendLine(" <li class='divider'></li>");

           //     sqlQuadroAviso.AppendLine(sql.ToString());
           // }

           // ViewBag.ProgramaAberto =  Fachada.Instancia.ObterIndicadoresProgramasAberto();
           // ViewBag.ProgramasCadastrado = Fachada.Instancia.ObterIndicadoresProgramasCadastrado();
           // ViewBag.ProgramasInativo = Fachada.Instancia.ObterIndicadoresProgramasInativo();
           // ViewBag.Propostas = Fachada.Instancia.ObterIndicadoresPropostas();

           // ViewBag.ProgramaAberto = CalcularPorcentagem(ViewBag.ProgramaAberto , ViewBag.Propostas);

           // ViewBag.ProgramasCadastrado = CalcularPorcentagem(ViewBag.ProgramasCadastrado, ViewBag.Propostas);


           // ViewBag.ProgramasInativo = CalcularPorcentagem(ViewBag.ProgramasInativo, ViewBag.Propostas);


           // string sqlProposta = "     <li>" +
           // "                        <a href=\"#\">" +
           // "                            <div>" +
           // "                                <p>" +
           // "                                    <strong>Programas Abertos</strong>" +
           // //"                                    <span class=\"pull-right text-muted\"> " + ViewBag.ProgramaAberto + " % Completo</span>" +
           // "                                </p>" +
           // "                                <div class=\"progress progress-striped active\">" +
           // "                                    <div class=\"progress-bar progress-bar-success\" role=\"progressbar\" aria-valuenow=\" " + ViewBag.ProgramaAberto + " \" aria-valuemin=\"0\" aria-valuemax=\"" + ViewBag.Propostas + "\" style=\"width: " + ViewBag.ProgramaAberto + "%  \">" +
           // "                                        <span class=\"sr-only\"> " + ViewBag.ProgramaAberto + " % Completo (successo)</span>" +
           // "                                    </div>" +
           // "                                </div>" +
           // "                            </div>" +
           // "                        </a>" +
           // "                    </li>" +
           //    "   <li class=\"divider\"></li>" +
           //    "     <li>" +
           // "                        <a href=\"#\">" +
           // "                            <div>" +
           // "                                <p>" +
           // "                                    <strong>Programas Cadastrados</strong>" +
           // //"                                    <span class=\"pull-right text-muted\"> " + ViewBag.ProgramaAberto + " % Completo</span>" +
           // "                                </p>" +
           // "                                <div class=\"progress progress-striped active\">" +
           // "                                    <div class=\"progress-bar progress-bar-warning\" role=\"progressbar\" aria-valuenow=\" " + ViewBag.ProgramasCadastrado + " \" aria-valuemin=\"0\" aria-valuemax=\"" + ViewBag.Propostas + "\" style=\"width: " + ViewBag.ProgramasCadastrado + "%  \">" +
           // "                                        <span class=\"sr-only\"> " + ViewBag.ProgramasCadastrado + " % Completo (warning)</span>" +
           // "                                    </div>" +
           // "                                </div>" +
           // "                            </div>" +
           // "                        </a>" +
           // "                    </li>" +
           //    "   <li class=\"divider\"></li>" +
           //    "     <li>" +
           // "                        <a href=\"#\">" +
           // "                            <div>" +
           // "                                <p>" +
           // "                                    <strong>Programas Inativos</strong>" +
           // //"                                    <span class=\"pull-right text-muted\"> " + ViewBag.ProgramaAberto + " % Completo</span>" +
           // "                                </p>" +
           // "                                <div class=\"progress progress-striped active\">" +
           // "                                    <div class=\"progress-bar progress-bar-danger\" role=\"progressbar\" aria-valuenow=\" " + ViewBag.ProgramasInativo + " \" aria-valuemin=\"0\" aria-valuemax=\"" + ViewBag.Propostas + "\" style=\"width: " + ViewBag.ProgramasInativo + "%  \">" +
           // "                                        <span class=\"sr-only\"> " + ViewBag.ProgramasInativo + " % Completo (danger)</span>" +
           // "                                    </div>" +
           // "                                </div>" +
           // "                            </div>" +
           // "                        </a>" +
           // "                    </li>" +
           //    "   <li class=\"divider\"></li>" 
           //;

           // ViewBag.Proposta = sqlProposta;


           // ViewBag.QuadroAviso = sqlQuadroAviso;
           // ViewBag.CountQuadroAviso = lstQuadroAviso.Count;
            ViewBag.Usuario = ((UsuarioVO)Session["UsuarioSession"]).Nome.ToString();
            Data data = new Data();




            return PartialView("_Menu", data.navbarItems().OrderBy(i => i.Id).ToList());



        }
        private int CalcularPorcentagem(Int32 intNum, Int32 intNumTotal)
        {
            if ((intNum > 0) && (intNumTotal > 0))
            {
                return intNum * 100 / intNumTotal;
            }
            else
            {
                return 0;
            }
           

        }
        public ActionResult Sair()
        {
            // ViewBag.QuadroAviso = new QuadroAvisoBO().ObterPorFiltro(new QuadroAvisoVO()).ToList().OrderByDescending(x => x.Id);


            Session["UsuarioSession"] = null;


            return RedirectToAction("../");

        }
    }
}