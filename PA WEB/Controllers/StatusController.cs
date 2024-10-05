
using PA.Web.Models;

using PA.Web.VO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class StatusController : Controller
    {
        
        private List<StatusVO> lstStatus = new List<StatusVO>();
        private List<StatusMOD> lstStatusMOD = new List<StatusMOD>();
        private StatusMOD objStatusMOD = new StatusMOD();
        private StatusVO objStatusVO = new StatusVO();


    

        public StatusController()
        {


           
        }

        private void bindDropDownList()
        {
           

        }

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstStatus = new List<StatusVO>();
            lstStatusMOD = new List<StatusMOD>();


            lstStatus =  new Infra.Rest.RestStatus().RestGet().ToList();

            foreach (var item in lstStatus)
            {
                objStatusMOD = new StatusMOD();
                objStatusMOD.Id = item.Id;
              
                objStatusMOD.Nome = item.Nome;
           
               

                lstStatusMOD.Add(objStatusMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstStatusMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(StatusMOD dadosTela)
        {
            try
            {
                objStatusVO = new StatusVO();
                dadosTela.Id = GetHashCode();

                if (dadosTela != null)
                {
                    
                    if (dadosTela.Id > 0)
                    {
                        objStatusVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objStatusVO.Nome = dadosTela.Nome;
                    }
                   
                    

                     new Infra.Rest.RestStatus().RestPost(objStatusVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Status inserido com sucesso");
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
        public ActionResult Editar(StatusMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(StatusMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objStatusVO.Id = Int32.Parse(param1);
            bindDropDownList();
            objStatusVO = new Infra.Rest.RestStatus().RestGetID(objStatusVO);
    
            ViewBag.Id = objStatusVO.Id;
        
            ViewBag.Nome = objStatusVO.Nome;
          


            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(StatusMOD dadosTela)
        {
            try
            {

                objStatusVO = new StatusVO();
                if (dadosTela != null)
                {
                
                    
                    if (dadosTela.Id > 0)
                    {
                        objStatusVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objStatusVO.Nome = dadosTela.Nome;
                    }
               

                     new Infra.Rest.RestStatus().RestUpdate(objStatusVO.Id ,objStatusVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Status editado com sucesso");
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
        public ActionResult TDelete(StatusMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objStatusVO.Id = Int32.Parse(param1);

            objStatusVO = new Infra.Rest.RestStatus().RestGetID(objStatusVO);

            objStatusMOD.Id = objStatusVO.Id;

            objStatusMOD.Nome = objStatusVO.Nome;

            ViewBag.Id = objStatusVO.Id;
            ViewBag.Nome = objStatusVO.Nome;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(StatusMOD dadosTela)
        {
            try
            {
                objStatusVO = new StatusVO();

                if (dadosTela.Id > 0)
                {
                    objStatusVO.Id = Convert.ToInt32(dadosTela.Id);

                    objStatusVO.Nome = dadosTela.Nome;

                    new Infra.Rest.RestStatus().RestDelete(objStatusVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Status excluido com sucesso");
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


            this.bindDropDownList();

            lstStatus = new List<StatusVO>();
            lstStatusMOD = new List<StatusMOD>();


            lstStatus = new Infra.Rest.RestStatus().RestGet();

            foreach (var item in lstStatus)
            {
                objStatusMOD = new StatusMOD();
                objStatusMOD.Id = item.Id;
              
                objStatusMOD.Nome = item.Nome;
              

                lstStatusMOD.Add(objStatusMOD);
            }
            objStatusMOD = new StatusMOD();
            objStatusMOD.lstStatusMod = lstStatusMOD;
            ViewBag.Status = objStatusMOD;

            this.bindViewBagDropDownlist();

            return View(objStatusMOD);
        }

        private void bindViewBagDropDownlist()
        {
          
       


        }

    }
}
