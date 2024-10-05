using PA.Web.Models;
using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA.Web.Domain;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;
using System.Text;


namespace PA.Web.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioVO objUsuario;
        private List<UsuarioVO> lstUsuario;
        //private List<RssReader> lstRssReader;
        //private List<UFChart> lstChartTotal;

        public HomeController()
        {
         
        }

        public UsuarioVO UsuarioSession
        {
            get
            {
                return (UsuarioVO)Session["UsuarioSession"];
            }
            set
            {
                Session["UsuarioSession"] = value;
            }
        }

        //public List<RssReader> LstRssReader
        //{
        //    get
        //    {
        //        return lstRssReader;
        //    }

        //    set
        //    {
        //        lstRssReader = value;
        //    }
        //}

        private string ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("http://sampathloku.blogspot.com/feeds/posts/default?alt=rss");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a><br>" + description);
            }

            // Return the string that contain the RSS items
            return rssContent.ToString();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        //public ActionResult TPartialRSS(RssReader dadosTela)
        //{
     
        //    return View();
        //}

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Index()
        {

            if (Session["UsuarioSession"] == null)
            {
                return RedirectToAction("../");
            }
            ViewBag.CUIDADORES = new Infra.Rest.RestUsuario().RestGet().Where(i => i.Grupo_usuario_id == 51470639).ToList().Count;
            ViewBag.CLIENTES = new Infra.Rest.RestUsuario().RestGet().Where(i => i.Grupo_usuario_id == 19793832).ToList().Count;
            ViewBag.VISITAS_COMPLETOS = new Infra.Rest.RestVisita().RestGet().Where(i => i.Status_id == 1).ToList().Count;
            ViewBag.VISITAS_EMCAMINHO = new Infra.Rest.RestVisita().RestGet().Where(i => i.Status_id == 3).ToList().Count;
         

            //StringBuilder sql = new StringBuilder();

            //sql.AppendLine("         Morris.Bar({");
            //sql.AppendLine("                element: 'bar-example',");
            //sql.AppendLine("                    data: [");
            //lstChartTotal = new List<UFChart>();
            //lstChartTotal = Fachada.Instancia.ObterChartArea();
            //int intTotalChart = lstChartTotal.Count;
            //foreach (var item in lstChartTotal) 
            //{
            //    sql.AppendLine("                      { y: '"+ item.Descricao + "', a: " + item.Count + " },");
            //}
            //sql.AppendLine("                      { y: ' ', a: 0}");
            //    sql.AppendLine("                    ],");
            //    sql.AppendLine("                    xkey: 'y',");
            //    sql.AppendLine("                    ykeys: ['a'],");
            //    sql.AppendLine("                    labels: ['Propostas', 'Porcentagem']");
            //    sql.AppendLine("                });");


            //ViewBag.AreaChart = sql.ToString();



            return View();
        }
        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        [HttpPost]
        public ActionResult ConsultaEstado()

        {
           

            return RedirectToAction("Index", "Login");
        }
        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        [HttpPost]
        public ActionResult Logar(LoginMOD dadosTela)
        {
            objUsuario = new UsuarioVO();
            Session["UsuarioSession"] = new UsuarioVO();
            lstUsuario = new List<UsuarioVO>();
            objUsuario.Login = dadosTela.Usuario;

            objUsuario.Senha = dadosTela.Senha;

            objUsuario = new  Infra.Rest.RestUsuario().RestGet().Where(i => (i.Login == objUsuario.Login) && (i.Senha == objUsuario.Senha)).ToList().First();

            if (objUsuario != null)
            {

                Session["UsuarioSession"] = objUsuario;
                return RedirectToAction("Index", "PageRank");

            }
            else
            {
                TempData.Add("ERRO",
         "Login incorreto!");
                return RedirectToAction("Index", "Login");
            }


        }


    }
}
