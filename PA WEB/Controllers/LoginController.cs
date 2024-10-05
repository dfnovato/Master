using PA.Web.Models;
using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA.Web.Domain;


namespace PA.Web.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioVO objUsuario;
        private List<UsuarioVO> lstUsuario;

        public LoginController()
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
    




    //Criamos uma ação (ACTION) para abrir a tela
    //De cadastro de contatos
    public ActionResult Index()
        {


            return View();
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

            try
            {
                objUsuario = new Infra.Rest.RestUsuario().RestGet().Where(i => (i.Login == objUsuario.Login) && (i.Senha == objUsuario.Senha)).ToList().First();
            }
            catch (Exception)
            {
                TempData.Add("ERRO",
             "Login incorreto!");
                return RedirectToAction("Index", "Login");
            } 

            if (objUsuario != null)
            {

                Session["UsuarioSession"] = objUsuario;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData.Add("ERRO",
         "Login incorreto!");
                return RedirectToAction("Index", "Login");
            }


        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        [HttpPost]
        public ActionResult EnviarEmail(LoginMOD dadosTela)
        {

         //   EmailVO objEmailVO = new EmailVO();
         //   objEmailVO.From = "contatogesconv@gmail.com";


  

          
         //   objEmailVO.Subject = "GESCONV - Redefinir Senha!";
         //   objEmailVO.To = dadosTela.Email;


         //   if (Util.EnviarEmailRecuperacao(objEmailVO))
         //   {

         //       Session["UsuarioSession"] = objUsuario;
         //       return RedirectToAction("Index", "Login");

         //   }
         //   else
         //   {
         //       TempData.Add("ERRO",
         //"Login incorreto!");
                return RedirectToAction("Index", "Login");
            //}


        }

     
        public ActionResult TEsqueceuSenha()
        {


            return View();
        }


    }
}
