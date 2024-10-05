using PA.Web.Infra.Rest;
using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PA.Web.Controllers
{
    public class MapaClienteController : Controller
    {
        private StringBuilder conteudo;
        private List<UsuarioVO> usuarioVOs;
        private StringBuilder cuidador;

        // GET: MapaCliente
        public ActionResult Index()
        {



            this.CarregaMapaCliente();
            return View();
        }

        private void CarregaMapaCliente()
        {
            conteudo = new StringBuilder();
            cuidador = new StringBuilder();


            cuidador.AppendLine("    <div class=\"img-perfil\">");
            cuidador.AppendLine("    <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p1.png\" title=\"Aisha\" alt=\"foto-perfil\"></div>");
            cuidador.AppendLine("    <h1>Aisha</h1>");
            //cuidador.AppendLine("    <p>Project Manager</p>");
            //cuidador.AppendLine("    <hr>");
            //cuidador.AppendLine("    <h3>Activity Level : 85%</h3>");
            //cuidador.AppendLine("    <p>Lorem ipsum dolor sit amet consectetur</p>");
            //cuidador.AppendLine("    <div class=\"caja-gris\">");
            //cuidador.AppendLine("       <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/msg.png\">");
            //cuidador.AppendLine("        <p>1086</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("      <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p2.png\">");
            //cuidador.AppendLine("        <p>1582</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("      <div class=\"sobre\">");
            //cuidador.AppendLine("           <img src=\"https://p.w3layouts.com/demos/june-2016/01-06-2016/model_profile_widget/web/images/p3.png\">");
            //cuidador.AppendLine("        <p>1468</p> ");
            //cuidador.AppendLine("      </div>");
            //cuidador.AppendLine("    </div> ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("      <div class=\"redes face\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes twitter\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes instagram\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("      <div class=\"redes youtube\"><a href=\"#\"></a></div>");
            //cuidador.AppendLine("     <div class=\"boton\">");
            //cuidador.AppendLine("					<a href=\"#\">Follow</a>");
            //cuidador.AppendLine("				</div> ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("    ");
            //cuidador.AppendLine("    ");
            usuarioVOs = new List<UsuarioVO>();

            usuarioVOs = new RestUsuario().RestGet().ToList().Where(i => i.Grupo_usuario_id == 19793832).ToList();

            int total = usuarioVOs.Count;
            int countVisita = 0;


            foreach (var item in usuarioVOs)
            {
                if (countVisita <= total)
                {
                    conteudo.AppendLine("  ['<div style=\"width:200px;margin:0 auto; color:#4E1361;\"><h4><b>" + item.Nome + "</b></h4><br>" + item.Endereco + "<br> <br><img   style=\"width:200px;margin:0 auto; color:#4E1361;\" src=\"../Content/Uploads/" + item.Foto + "\" title=\"" + item.Nome + "\" alt=\"foto-perfil\" ><br> "+ CarregaRanking(item.Ranking.ToString()) + " </div>', " + item.Latitude 
                        
                        + ", " + item.Longitude + "],");
                }
                
              

                ViewBag.MAP = conteudo;

               

            }
        }


        public string CarregaRanking(string strRanking)
        {
         
            if (strRanking == "1")
            {
                return "<br><img style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
            }

            if (strRanking == "2")
            {
                return "<br><img style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
            }

            if (strRanking == "3")
            {
                return "<br><img style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
            }

            if (strRanking == "4")
            {
                return "<br><img style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
            }

            if (strRanking == "5")
            {
                return "<br><img  style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
            }

            return "<br><img style=\"width:198px;margin:0 auto; color:#4E1361;\" src=\"../Content/Images/ranking" + strRanking.ToString() + ".png\" title=\"" + strRanking.ToString() + " Pontuação\" alt=\"foto-perfil\" ><br> ";
        }
    }
}

    
