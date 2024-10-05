using PA.Web.Models;
using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class PermissaoController : Controller
    {
        private List<PermissaoVO> lstPermissao = new List<PermissaoVO>();
        private List<PermissaoMOD> lstPermissaoMOD = new List<PermissaoMOD>();
        private PermissaoMOD objPermissaoMOD = new PermissaoMOD();
        private PermissaoVO objPermissaoVO = new PermissaoVO();
        private List<GrupoUsuarioVO> lstGrupoUsuarioVO;
        private List<MenuVO> lstMenuVO;

        public PermissaoController()
        {
            //this.Index();


        }



        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstPermissao = new List<PermissaoVO>();
            lstPermissaoMOD = new List<PermissaoMOD>();


            lstPermissao = new Infra.Rest.RestPermissao().RestGet();

            foreach (var item in lstPermissao)
            {
                objPermissaoMOD = new PermissaoMOD();
                objPermissaoMOD.Id = item.Id;
                objPermissaoMOD.GrupoUsuarioVO.Descricao = new Infra.Rest.RestGrupoUsuario().RestGet().Where(i => i.Id == item.GrupoUsuario_id).First().Descricao;



                lstPermissaoMOD.Add(objPermissaoMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo GrupoUsuarioVO.Descricao
            //Da action

            return View(lstPermissaoMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(PermissaoMOD dadosTela)
        {
            try
            {
                objPermissaoVO = new PermissaoVO();
                if (dadosTela != null)
                {
                    objPermissaoVO.Id = GetHashCode();
                    if (dadosTela.GrupoUsuarioVO != null)
                    {

                        objPermissaoVO.GrupoUsuario_id = dadosTela.GrupoUsuarioVO.Id;

                    }

                    if (dadosTela.MenuVO != null)
                    {

                        objPermissaoVO.Menu_id = dadosTela.MenuVO.Id;
                    }




                    new Infra.Rest.RestPermissao().RestPost(objPermissaoVO);



                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Permissao inserido com sucesso");
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
        public ActionResult Editar(PermissaoMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];

            return View();
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(PermissaoMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];

            objPermissaoVO.Id = Int32.Parse(param1);

            objPermissaoVO = new Infra.Rest.RestPermissao().RestGetID(objPermissaoVO);

            ViewBag.Id = objPermissaoVO.Id;

            //ViewBag.GrupoUsuarioVO.Id = objPermissaoVO.GrupoUsuario.Id;



            //ViewBag.MenuVO.Id = objPermissaoVO.Menu.Id;

            return View();
        }


        [HttpPost]
        public ActionResult Atualizar(PermissaoMOD dadosTela)
        {
            try
            {

                objPermissaoVO = new PermissaoVO();
                if (dadosTela != null)
                {
                    objPermissaoVO.Id = Convert.ToInt32(dadosTela.Id);
                    if (dadosTela.GrupoUsuarioVO != null)
                    {

                        objPermissaoVO.GrupoUsuario_id = dadosTela.GrupoUsuarioVO.Id;
                    }

                    if (dadosTela.Id > 0)
                    {

                        objPermissaoVO.Menu_id = dadosTela.MenuVO.Id;
                    }


                    new Infra.Rest.RestPermissao().RestUpdate(objPermissaoVO.Id, objPermissaoVO);
                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Permissao editado com sucesso");
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
        public ActionResult TDelete(PermissaoMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];


            objPermissaoVO.Id = Int32.Parse(param1);



            objPermissaoVO = new Infra.Rest.RestPermissao().RestGetID(objPermissaoVO);

            objPermissaoMOD.Id = objPermissaoVO.Id;



            ViewBag.Id = objPermissaoVO.Id;


            return View();
        }
        [HttpPost]
        public ActionResult Deletar(PermissaoMOD dadosTela)
        {
            try
            {
                objPermissaoVO = new PermissaoVO();

                if (dadosTela.Id > 0)
                {
                    objPermissaoVO.Id = Convert.ToInt32(dadosTela.Id);

                    new Infra.Rest.RestPermissao().RestDelete(objPermissaoVO);



                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Permissao excluido com sucesso");
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
            lstPermissao = new List<PermissaoVO>();
            lstPermissaoMOD = new List<PermissaoMOD>();

  
            lstPermissao = new Infra.Rest.RestPermissao().RestGet();

            foreach (var item in lstPermissao)
            {
                objPermissaoMOD = new PermissaoMOD();
                objPermissaoMOD.Id = item.Id;

                GrupoUsuarioVO grupoUsuarioVO = new GrupoUsuarioVO();
                grupoUsuarioVO.Id = item.GrupoUsuario_id;
                objPermissaoMOD.GrupoUsuarioVO = new Infra.Rest.RestGrupoUsuario().RestGetID(grupoUsuarioVO) ;
                objPermissaoMOD.MenuVO.Id = item.Menu_id;

                lstPermissaoMOD.Add(objPermissaoMOD);
            }
            objPermissaoMOD = new PermissaoMOD();
            ViewBag.Permissao = objPermissaoMOD;
            objPermissaoMOD.lstPermissaoMod = lstPermissaoMOD;
            lstGrupoUsuarioVO = new Infra.Rest.RestGrupoUsuario().RestGet();
            lstMenuVO =  new Infra.Rest.RestMenu().RestGet();

            ViewBag.GrupoUsuarioVO = new SelectList
                  (
                      lstGrupoUsuarioVO,
                        "id",
                      "descricao"
                  );

            ViewBag.MenuVO = new SelectList
            (
                lstMenuVO,
                  "id",
                "nameOption"
            );

            return View(objPermissaoMOD);


        }



    }
}
