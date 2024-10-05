
using PA.Web.Models;

using PA.Web.VO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class CondicaoController : Controller
    {
        
        private List<CondicaoVO> lstCondicao = new List<CondicaoVO>();
        private List<CondicaoMOD> lstCondicaoMOD = new List<CondicaoMOD>();
        private CondicaoMOD objCondicaoMOD = new CondicaoMOD();
        private CondicaoVO objCondicaoVO = new CondicaoVO();


    

        public CondicaoController()
        {


           
        }

        private void bindDropDownList()
        {
           

        }

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstCondicao = new List<CondicaoVO>();
            lstCondicaoMOD = new List<CondicaoMOD>();


            lstCondicao =  new Infra.Rest.RestCondicao().RestGet().ToList();

            foreach (var item in lstCondicao)
            {
                objCondicaoMOD = new CondicaoMOD();
                objCondicaoMOD.Id = item.Id;
              
                objCondicaoMOD.Nome = item.Nome;
           
               

                lstCondicaoMOD.Add(objCondicaoMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstCondicaoMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CondicaoMOD dadosTela)
        {
            try
            {
                objCondicaoVO = new CondicaoVO();
                dadosTela.Id = GetHashCode();

                if (dadosTela != null)
                {
                    
                    if (dadosTela.Id > 0)
                    {
                        objCondicaoVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objCondicaoVO.Nome = dadosTela.Nome;
                    }
                   
                    

                     new Infra.Rest.RestCondicao().RestPost(objCondicaoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Condicao inserido com sucesso");
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
        public ActionResult Editar(CondicaoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(CondicaoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objCondicaoVO.Id = Int32.Parse(param1);
            bindDropDownList();
            objCondicaoVO = new Infra.Rest.RestCondicao().RestGetID(objCondicaoVO);
    
            ViewBag.Id = objCondicaoVO.Id;
        
            ViewBag.Nome = objCondicaoVO.Nome;
          


            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(CondicaoMOD dadosTela)
        {
            try
            {

                objCondicaoVO = new CondicaoVO();
                if (dadosTela != null)
                {
                
                    
                    if (dadosTela.Id > 0)
                    {
                        objCondicaoVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objCondicaoVO.Nome = dadosTela.Nome;
                    }
               

                     new Infra.Rest.RestCondicao().RestUpdate(objCondicaoVO.Id ,objCondicaoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Condicao editado com sucesso");
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
        public ActionResult TDelete(CondicaoMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objCondicaoVO.Id = Int32.Parse(param1);

            objCondicaoVO = new Infra.Rest.RestCondicao().RestGetID(objCondicaoVO);

            objCondicaoMOD.Id = objCondicaoVO.Id;

            objCondicaoMOD.Nome = objCondicaoVO.Nome;

            ViewBag.Id = objCondicaoVO.Id;
            ViewBag.Nome = objCondicaoVO.Nome;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(CondicaoMOD dadosTela)
        {
            try
            {
                objCondicaoVO = new CondicaoVO();

                if (dadosTela.Id > 0)
                {
                    objCondicaoVO.Id = Convert.ToInt32(dadosTela.Id);

                    objCondicaoVO.Nome = dadosTela.Nome;

                    new Infra.Rest.RestCondicao().RestDelete(objCondicaoVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Condicao excluido com sucesso");
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

            lstCondicao = new List<CondicaoVO>();
            lstCondicaoMOD = new List<CondicaoMOD>();


            lstCondicao = new Infra.Rest.RestCondicao().RestGet();

            foreach (var item in lstCondicao)
            {
                objCondicaoMOD = new CondicaoMOD();
                objCondicaoMOD.Id = item.Id;
              
                objCondicaoMOD.Nome = item.Nome;
              

                lstCondicaoMOD.Add(objCondicaoMOD);
            }
            objCondicaoMOD = new CondicaoMOD();
            objCondicaoMOD.lstCondicaoMOD = lstCondicaoMOD;
            ViewBag.Condicao = objCondicaoMOD;

            this.bindViewBagDropDownlist();

            return View(objCondicaoMOD);
        }

        private void bindViewBagDropDownlist()
        {
          
       


        }

    }
}
