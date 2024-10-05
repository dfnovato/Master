
using PA.Web.Models;

using PA.Web.VO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class EspecialidadeController : Controller
    {
        
        private List<EspecialidadeVO> lstEspecialidade = new List<EspecialidadeVO>();
        private List<EspecialidadeMOD> lstEspecialidadeMOD = new List<EspecialidadeMOD>();
        private EspecialidadeMOD objEspecialidadeMOD = new EspecialidadeMOD();
        private EspecialidadeVO objEspecialidadeVO = new EspecialidadeVO();


    

        public EspecialidadeController()
        {


           
        }

        private void bindDropDownList()
        {
           

        }

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstEspecialidade = new List<EspecialidadeVO>();
            lstEspecialidadeMOD = new List<EspecialidadeMOD>();


            lstEspecialidade =  new Infra.Rest.RestEspecialidade().RestGet().ToList();

            foreach (var item in lstEspecialidade)
            {
                objEspecialidadeMOD = new EspecialidadeMOD();
                objEspecialidadeMOD.Id = item.Id;
              
                objEspecialidadeMOD.Nome = item.Nome;
           
               

                lstEspecialidadeMOD.Add(objEspecialidadeMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstEspecialidadeMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(EspecialidadeMOD dadosTela)
        {
            try
            {
                objEspecialidadeVO = new EspecialidadeVO();
                dadosTela.Id = GetHashCode();

                if (dadosTela != null)
                {
                    
                    if (dadosTela.Id > 0)
                    {
                        objEspecialidadeVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objEspecialidadeVO.Nome = dadosTela.Nome;
                    }
                   
                    

                     new Infra.Rest.RestEspecialidade().RestPost(objEspecialidadeVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Especialidade inserido com sucesso");
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
        public ActionResult Editar(EspecialidadeMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(EspecialidadeMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objEspecialidadeVO.Id = Int32.Parse(param1);
            bindDropDownList();
            objEspecialidadeVO = new Infra.Rest.RestEspecialidade().RestGetID(objEspecialidadeVO);
    
            ViewBag.Id = objEspecialidadeVO.Id;
        
            ViewBag.Nome = objEspecialidadeVO.Nome;
          


            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(EspecialidadeMOD dadosTela)
        {
            try
            {

                objEspecialidadeVO = new EspecialidadeVO();
                if (dadosTela != null)
                {
                
                    
                    if (dadosTela.Id > 0)
                    {
                        objEspecialidadeVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objEspecialidadeVO.Nome = dadosTela.Nome;
                    }
               

                     new Infra.Rest.RestEspecialidade().RestUpdate(objEspecialidadeVO.Id ,objEspecialidadeVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Especialidade editado com sucesso");
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
        public ActionResult TDelete(EspecialidadeMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objEspecialidadeVO.Id = Int32.Parse(param1);

            objEspecialidadeVO = new Infra.Rest.RestEspecialidade().RestGetID(objEspecialidadeVO);

            objEspecialidadeMOD.Id = objEspecialidadeVO.Id;

            objEspecialidadeMOD.Nome = objEspecialidadeVO.Nome;

            ViewBag.Id = objEspecialidadeVO.Id;
            ViewBag.Nome = objEspecialidadeVO.Nome;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(EspecialidadeMOD dadosTela)
        {
            try
            {
                objEspecialidadeVO = new EspecialidadeVO();

                if (dadosTela.Id > 0)
                {
                    objEspecialidadeVO.Id = Convert.ToInt32(dadosTela.Id);

                    objEspecialidadeVO.Nome = dadosTela.Nome;

                    new Infra.Rest.RestEspecialidade().RestDelete(objEspecialidadeVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Especialidade excluido com sucesso");
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

            lstEspecialidade = new List<EspecialidadeVO>();
            lstEspecialidadeMOD = new List<EspecialidadeMOD>();


            lstEspecialidade = new Infra.Rest.RestEspecialidade().RestGet();

            foreach (var item in lstEspecialidade)
            {
                objEspecialidadeMOD = new EspecialidadeMOD();
                objEspecialidadeMOD.Id = item.Id;
              
                objEspecialidadeMOD.Nome = item.Nome;
              

                lstEspecialidadeMOD.Add(objEspecialidadeMOD);
            }
            objEspecialidadeMOD = new EspecialidadeMOD();
            objEspecialidadeMOD.lstEspecialidadeMod = lstEspecialidadeMOD;
            ViewBag.Especialidade = objEspecialidadeMOD;

            this.bindViewBagDropDownlist();

            return View(objEspecialidadeMOD);
        }

        private void bindViewBagDropDownlist()
        {
          
       


        }

    }
}
