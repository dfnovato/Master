using PA.Web.Models;

using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class GrupoUsuarioController : Controller
    {
        private List<GrupoUsuarioVO> lstGrupoUsuario = new List<GrupoUsuarioVO>();
        private List<GrupoUsuarioMOD> lstGrupoUsuarioMOD = new List<GrupoUsuarioMOD>();
        private GrupoUsuarioMOD objGrupoUsuarioMOD = new GrupoUsuarioMOD();
        private GrupoUsuarioVO objGrupoUsuarioVO = new GrupoUsuarioVO();


        public GrupoUsuarioController()
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

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstGrupoUsuario = new List<GrupoUsuarioVO>();
            lstGrupoUsuarioMOD = new List<GrupoUsuarioMOD>();


            lstGrupoUsuario = new Infra.Rest.RestGrupoUsuario().RestGet();

            foreach (var item in lstGrupoUsuario)
            {
                objGrupoUsuarioMOD = new GrupoUsuarioMOD();
                objGrupoUsuarioMOD.Id = item.Id;
                objGrupoUsuarioMOD.Descricao = item.Descricao;



                lstGrupoUsuarioMOD.Add(objGrupoUsuarioMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstGrupoUsuarioMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(GrupoUsuarioMOD dadosTela)
        {
            try
            {
                objGrupoUsuarioVO = new GrupoUsuarioVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Descricao != null)
                    {
                        objGrupoUsuarioVO.Id = GetHashCode();
                        objGrupoUsuarioVO.Descricao = dadosTela.Descricao;
                    }


                    new Infra.Rest.RestGrupoUsuario().RestPost(objGrupoUsuarioVO);

           


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "GrupoUsuario inserido com sucesso");
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
        public ActionResult Editar(GrupoUsuarioMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(GrupoUsuarioMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objGrupoUsuarioVO.Id = Int32.Parse(param1);

            objGrupoUsuarioVO = new Infra.Rest.RestGrupoUsuario().RestGetID(objGrupoUsuarioVO);

            ViewBag.Id = objGrupoUsuarioVO.Id;
            ViewBag.Descricao = objGrupoUsuarioVO.Descricao;

            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(GrupoUsuarioMOD dadosTela)
        {
            try
            {

                objGrupoUsuarioVO = new GrupoUsuarioVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Descricao != null)
                    {
                        objGrupoUsuarioVO.Descricao = dadosTela.Descricao;
                    }

                    if (dadosTela.Id > 0)
                    {
                        objGrupoUsuarioVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
            
                    new Infra.Rest.RestGrupoUsuario().RestUpdate(objGrupoUsuarioVO.Id , objGrupoUsuarioVO);

                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "GrupoUsuario editado com sucesso");
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
        public ActionResult TDelete(GrupoUsuarioMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objGrupoUsuarioVO.Id = Int32.Parse(param1);

          

            objGrupoUsuarioVO = new Infra.Rest.RestGrupoUsuario().RestGetID(objGrupoUsuarioVO);

            objGrupoUsuarioMOD.Id = objGrupoUsuarioVO.Id;

            objGrupoUsuarioMOD.Descricao = objGrupoUsuarioVO.Descricao;

            ViewBag.Id = objGrupoUsuarioVO.Id;
            ViewBag.Descricao = objGrupoUsuarioVO.Descricao;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(GrupoUsuarioMOD dadosTela)
        {
            try
            {
                objGrupoUsuarioVO = new GrupoUsuarioVO();

                if (dadosTela.Id > 0)
                {
                    objGrupoUsuarioVO.Id =  Convert.ToInt32(dadosTela.Id);

                    objGrupoUsuarioVO.Descricao = dadosTela.Descricao;

                    new Infra.Rest.RestGrupoUsuario().RestDelete(objGrupoUsuarioVO);
                   


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "GrupoUsuario excluido com sucesso");
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

            lstGrupoUsuario = new List<GrupoUsuarioVO>();
            lstGrupoUsuarioMOD = new List<GrupoUsuarioMOD>();
        

            lstGrupoUsuario = new Infra.Rest.RestGrupoUsuario().RestGet();

            foreach (var item in lstGrupoUsuario)
            {
                objGrupoUsuarioMOD = new GrupoUsuarioMOD();
                objGrupoUsuarioMOD.Id = item.Id;
                objGrupoUsuarioMOD.Descricao = item.Descricao;


                lstGrupoUsuarioMOD.Add(objGrupoUsuarioMOD);
            }
            objGrupoUsuarioMOD = new GrupoUsuarioMOD();
            ViewBag.GrupoUsuario = objGrupoUsuarioMOD;
            objGrupoUsuarioMOD.lstGrupoUsuarioMod = lstGrupoUsuarioMOD;

            return View(objGrupoUsuarioMOD);
        }



    }
}
