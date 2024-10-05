using PA.Web.Models;

using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class CargaController : Controller
    {
        private List<CargaVO> lstCarga = new List<CargaVO>();
        private List<CargaMOD> lstCargaMOD = new List<CargaMOD>();
        private CargaMOD objCargaMOD = new CargaMOD();
        private CargaVO objCargaVO = new CargaVO();


        public CargaController()
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
            lstCarga = new List<CargaVO>();
            lstCargaMOD = new List<CargaMOD>();


            lstCarga = new Infra.Rest.RestCarga().RestGet();

            foreach (var item in lstCarga)
            {
                objCargaMOD = new CargaMOD();
                objCargaMOD.Id = item.Id;
                objCargaMOD.Carga = item.Carga;
                objCargaMOD.Valor = item.Valor;


                lstCargaMOD.Add(objCargaMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstCargaMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CargaMOD dadosTela)
        {
            try
            {
                objCargaVO = new CargaVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Carga != null)
                    {
                        objCargaVO.Id = GetHashCode();
                        objCargaVO.Carga = dadosTela.Carga;
                        objCargaVO.Valor = dadosTela.Valor;
                    }


                    new Infra.Rest.RestCarga().RestPost(objCargaVO);

           


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Carga inserido com sucesso");
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
        public ActionResult Editar(CargaMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(CargaMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];

            objCargaVO.Id = Int32.Parse(param1);

            objCargaVO = new Infra.Rest.RestCarga().RestGetID(objCargaVO);

            ViewBag.Id = objCargaVO.Id;
            ViewBag.Carga = objCargaVO.Carga;
            ViewBag.Valor = objCargaVO.Valor;

            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(CargaMOD dadosTela)
        {
            try
            {

                objCargaVO = new CargaVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Carga != null)
                    {
                        objCargaVO.Carga = dadosTela.Carga;
                    }


                    if (dadosTela.Valor != null)
                    {
                        objCargaVO.Valor = dadosTela.Valor;
                    }


                    if (dadosTela.Id > 0)
                    {
                        objCargaVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
            
                    new Infra.Rest.RestCarga().RestUpdate(objCargaVO.Id , objCargaVO);

                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Carga editado com sucesso");
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
        public ActionResult TDelete(CargaMOD dadosTela)
        {
            string param1 = this.Request.QueryString["id"];


            objCargaVO.Id = Int32.Parse(param1);

          

            objCargaVO = new Infra.Rest.RestCarga().RestGetID(objCargaVO);

            objCargaMOD.Id = objCargaVO.Id;

            objCargaMOD.Carga = objCargaVO.Carga;

            objCargaMOD.Valor = objCargaVO.Valor;

            ViewBag.Id = objCargaVO.Id;
            ViewBag.Carga = objCargaVO.Carga;
            ViewBag.Valor = objCargaVO.Valor;
            return View();
        }
        [HttpPost]
        public ActionResult Deletar(CargaMOD dadosTela)
        {
            try
            {
                objCargaVO = new CargaVO();

                if (dadosTela.Id > 0)
                {
                    objCargaVO.Id =  Convert.ToInt32(dadosTela.Id);

                    objCargaVO.Carga = dadosTela.Carga;

                    objCargaVO.Valor = dadosTela.Valor;

                    new Infra.Rest.RestCarga().RestDelete(objCargaVO);
                   


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Carga excluido com sucesso");
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

            lstCarga = new List<CargaVO>();
            lstCargaMOD = new List<CargaMOD>();
        

            lstCarga = new Infra.Rest.RestCarga().RestGet();

            foreach (var item in lstCarga)
            {
                objCargaMOD = new CargaMOD();
                objCargaMOD.Id = item.Id;
                objCargaMOD.Carga = item.Carga;
                objCargaMOD.Valor = item.Valor;

                lstCargaMOD.Add(objCargaMOD);
            }
            objCargaMOD = new CargaMOD();
            ViewBag.Carga = objCargaMOD;
            objCargaMOD.lstCargaMod = lstCargaMOD;

            return View(objCargaMOD);
        }



    }
}
