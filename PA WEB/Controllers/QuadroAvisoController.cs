
using PA.Web.Models;

using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class QuadroAvisoController : Controller
    {
        
        private List<QuadroAvisoVO> lstQuadroAviso = new List<QuadroAvisoVO>();
        private List<QuadroAvisoMOD> lstQuadroAvisoMOD = new List<QuadroAvisoMOD>();
        private QuadroAvisoMOD objQuadroAvisoMOD = new QuadroAvisoMOD();
        private QuadroAvisoVO objQuadroAvisoVO = new QuadroAvisoVO();
        private UsuarioVO objUsuario;

        public QuadroAvisoController()
        {


           
        }

      

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstQuadroAviso = new List<QuadroAvisoVO>();
            lstQuadroAvisoMOD = new List<QuadroAvisoMOD>();


            //lstQuadroAviso = Fachada.Instancia.ObterPorFiltro(new QuadroAvisoVO());

            foreach (var item in lstQuadroAviso)
            {
                objQuadroAvisoMOD = new QuadroAvisoMOD();
                objQuadroAvisoMOD.Id = item.Id;
                objQuadroAvisoMOD.Assunto = item.Assunto;
                objQuadroAvisoMOD.Conteudo = item.Conteudo;
                objQuadroAvisoMOD.Data = item.Data;
                objQuadroAvisoMOD.Usuario = item.Usuario;
              
               

                lstQuadroAvisoMOD.Add(objQuadroAvisoMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstQuadroAvisoMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(QuadroAvisoMOD dadosTela)
        {
            try
            {
                objQuadroAvisoVO = new QuadroAvisoVO();
                dadosTela.Id = GetHashCode();

                if (dadosTela != null)
                {
                    if (dadosTela.Assunto != null)
                    {
                        objQuadroAvisoVO.Assunto = dadosTela.Assunto;
                    }

                    if (dadosTela.Conteudo != null)
                    {
                        objQuadroAvisoVO.Conteudo = dadosTela.Conteudo;
                    }



                    objUsuario = new UsuarioVO();

                    objUsuario = (UsuarioVO)Session["UsuarioSession"];


                    if (objUsuario.Id > 0)
                    {
                        objQuadroAvisoVO.Usuario = Convert.ToInt32(objUsuario.Id);
                    }
                     
                    


                    if (dadosTela.Id > 0)
                    {
                        objQuadroAvisoVO.Id =  Convert.ToInt32(dadosTela.Id);
                    }




                    //Fachada.Instancia.Inserir(objQuadroAvisoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Comunicação inserido com sucesso");
                }
                else
                {
                    TempData.Add("ATENCAO",
            "Todos os campos devem está preenchidos!");
                }

            }
            catch (Exception erro )
            {
                TempData.Add("ERRO", erro.Message);
            }

            //Depois de cadastrar, enviamos o usuário
            //Novamente pra action Inserir (RECARREGAMOS
            //A View)
            //Response.Redirect
            return RedirectToAction("/Index");
        }


        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Editar(QuadroAvisoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(QuadroAvisoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objQuadroAvisoVO.Id = Int32.Parse(param1);

            //objQuadroAvisoVO = Fachada.Instancia.ObterPorPK(objQuadroAvisoVO);

            ViewBag.Id = objQuadroAvisoVO.Id;
            ViewBag.Assunto = objQuadroAvisoVO.Assunto;
            ViewBag.Conteudo = objQuadroAvisoVO.Conteudo;
            ViewBag.Data = objQuadroAvisoVO.Data;
            ViewBag.Usuario = objQuadroAvisoVO.Usuario;
         



            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(QuadroAvisoMOD dadosTela)
        {
            try
            {

                objQuadroAvisoVO = new QuadroAvisoVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Assunto != null)
                    {
                        objQuadroAvisoVO.Assunto = dadosTela.Assunto;
                    }

                    if (dadosTela.Conteudo != null)
                    {
                        objQuadroAvisoVO.Conteudo = dadosTela.Conteudo;
                    }


                    if (dadosTela.Usuario > 0)
                    {
                        objQuadroAvisoVO.Usuario = dadosTela.Usuario;
                    }
                   
                   
                    if (dadosTela.Id > 0)
                    {
                        objQuadroAvisoVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
             

                    //Fachada.Instancia.Alterar(objQuadroAvisoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Comunicação editado com sucesso");
                }
                else
                {
                    TempData.Add("ATENCAO",
            "Todos os campos devem está preenchidos!");
                }


            }
            catch (Exception erro)
            {
                TempData.Add("ERRO", erro.Message);
            }

            //Depois de cadastrar, enviamos o usuário
            //Novamente pra action Inserir (RECARREGAMOS
            //A View)
            //Response.Redirect
            return RedirectToAction("/Index");
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TDelete(QuadroAvisoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objQuadroAvisoVO.Id = Int32.Parse(param1);



            //objQuadroAvisoVO = Fachada.Instancia.ObterPorPK(objQuadroAvisoVO);

            objQuadroAvisoMOD.Id = objQuadroAvisoVO.Id;

            objQuadroAvisoMOD.Assunto = objQuadroAvisoVO.Assunto;

            ViewBag.Id = objQuadroAvisoVO.Id;
            ViewBag.Nome = objQuadroAvisoVO.Assunto;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(QuadroAvisoMOD dadosTela)
        {
            try
            {
                objQuadroAvisoVO = new QuadroAvisoVO();

                if (dadosTela.Id > 0)
                {
                    objQuadroAvisoVO.Id = Convert.ToInt32(dadosTela.Id);

                    objQuadroAvisoVO.Assunto = dadosTela.Assunto;

                    //Fachada.Instancia.Excluir(objQuadroAvisoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "QuadroAviso excluido com sucesso");
                }
                else
                {
                    TempData.Add("ATENCAO",
            "Todos os campos devem está preenchidos!");
                }


            }
            catch (Exception erro)
            {
                TempData.Add("ERRO", erro.Message);
            }

            //Depois de cadastrar, enviamos o usuário
            //Novamente pra action Inserir (RECARREGAMOS
            //A View)
            //Response.Redirect
            return RedirectToAction("/Index");
        }


        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Index()
        {
            if (Session["UsuarioSession"] == null)
            {
                return RedirectToAction("../");
            }


         

            lstQuadroAviso = new List<QuadroAvisoVO>();
            lstQuadroAvisoMOD = new List<QuadroAvisoMOD>();


            //lstQuadroAviso = Fachada.Instancia.ObterPorFiltro(new QuadroAvisoVO());

            foreach (var item in lstQuadroAviso)
            {
                objQuadroAvisoMOD = new QuadroAvisoMOD();
                objQuadroAvisoMOD.Id = item.Id;
                objQuadroAvisoMOD.Assunto = item.Assunto;
                objQuadroAvisoMOD.Conteudo = item.Conteudo;
                objQuadroAvisoMOD.Data = item.Data;
                objQuadroAvisoMOD.Usuario = item.Usuario;
                objUsuario = new UsuarioVO();
                objUsuario.Id  = item.Usuario;
                //objQuadroAvisoMOD.UsuarioNome = Fachada.Instancia.ObterPorPK(objUsuario).Nome;


                lstQuadroAvisoMOD.Add(objQuadroAvisoMOD);
            }
            objQuadroAvisoMOD = new QuadroAvisoMOD();
            objQuadroAvisoMOD.lstQuadroAvisoMOD = lstQuadroAvisoMOD;
            ViewBag.QuadroAviso = objQuadroAvisoMOD;

          
            return View(objQuadroAvisoMOD);
        }

     

    }
}
