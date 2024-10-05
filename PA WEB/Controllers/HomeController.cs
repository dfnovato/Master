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
using System.Globalization;

namespace PA.Web.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioVO objUsuario;
        private List<UsuarioVO> lstUsuario;
        private StringBuilder conteudo;
        private List<VisitaVO> visitaVOs;

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


        public ActionResult Index()
        {

            if (Session["UsuarioSession"] == null)
            {
                return RedirectToAction("../");
            }

            MontarEvento();
            return View();
        }


        private void MontarEvento()
        {
             conteudo = new StringBuilder();


            visitaVOs = new List<VisitaVO>();

            visitaVOs =   new Infra.Rest.RestVisita().RestGet();

           int total = visitaVOs.Count;
            int countVisita = 0;
          

                foreach (var item in visitaVOs)
                {
                    if (countVisita < total)
                    {
                        conteudo.AppendLine("  {");
                    conteudo.AppendLine("   title: '" + item.Nome.ToString() + "',");
                    conteudo.AppendLine("  color: 'purple' ,");
                    conteudo.AppendLine("   start: '" + Convert.ToDateTime(item.Data).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "T" + Convert.ToDateTime(item.HorarioInicio).ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',");
                    conteudo.AppendLine("   end: '" + Convert.ToDateTime(item.Data).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "T" + Convert.ToDateTime(item.HorarioFinal).ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "'");
                    conteudo.AppendLine("  },");

                        countVisita++;
                    }

                     if (countVisita == total)
                    {
                        conteudo.AppendLine("  {");
                    conteudo.AppendLine("   title: '" + item.StatusVO.Nome.ToString() + "',");
                   conteudo.AppendLine("  color: 'green' ,");

                  
                    conteudo.AppendLine("   start: '" + Convert.ToDateTime(item.Data).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "T" + Convert.ToDateTime(item.HorarioInicio).ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "',");
                    conteudo.AppendLine("   end: '" + Convert.ToDateTime(item.Data).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "T" + Convert.ToDateTime(item.HorarioFinal).ToString("HH:mm:ss", CultureInfo.InvariantCulture) + "'");
                    conteudo.AppendLine("  }");

                        countVisita++;
                    }
                }
            if (total == 0)
            {
                conteudo.AppendLine("  {");

                conteudo.AppendLine("  }");
            }


            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'All Day Event',");
            //conteudo.AppendLine("                    start: '2019-06-01'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Long Event',");
            //conteudo.AppendLine("                    start: '2019-06-07',");
            //conteudo.AppendLine("                    end: '2019-06-10'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    groupId: 999,");
            //conteudo.AppendLine("                    title: 'Repeating Event',");
            //conteudo.AppendLine("                    start: '2019-06-09T16:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    groupId: 999,");
            //conteudo.AppendLine("                    title: 'Repeating Event',");
            //conteudo.AppendLine("                    start: '2019-06-16T16:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Conference',");
            //conteudo.AppendLine("                    start: '2019-06-11',");
            //conteudo.AppendLine("                    end: '2019-06-13'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Meeting',");
            //conteudo.AppendLine("                    start: '2019-06-12T10:30:00',");
            //conteudo.AppendLine("                    end: '2019-06-12T12:30:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Lunch',");
            //conteudo.AppendLine("                    start: '2019-06-12T12:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Meeting',");
            //conteudo.AppendLine("                    start: '2019-06-12T14:30:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Happy Hour',");
            //conteudo.AppendLine("                    start: '2019-06-12T17:30:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Dinner',");
            //conteudo.AppendLine("                    start: '2019-06-12T20:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Dinner 3',");
            //conteudo.AppendLine("                    start: '2019-06-12T22:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Dinner 2',");
            //conteudo.AppendLine("                    start: '2019-06-12T23:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Birthday Party',");
            //conteudo.AppendLine("                    start: '2019-06-13T07:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Birthday Party 2',");
            //conteudo.AppendLine("                    start: '2019-06-13T08:00:00'");
            //conteudo.AppendLine("                },");
            //conteudo.AppendLine("                {");
            //conteudo.AppendLine("                    title: 'Click for Google',");
            //conteudo.AppendLine("                    url: 'http://google.com/',");
            //conteudo.AppendLine("                    start: '2019-06-28'");
            //conteudo.AppendLine("                }");

            ViewBag.VISITA = conteudo.ToString();
        }

    }
}
