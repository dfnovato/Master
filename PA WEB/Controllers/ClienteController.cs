
using PA.Web.Models;

using PA.Web.VO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PA.Web.Controllers
{
    public class ClienteController : Controller
    {
        private static List<EspecialidadeVO> constanteEspecialidade;

        private List<UsuarioVO> lstUsuario = new List<UsuarioVO>();
        private List<UsuarioMOD> lstUsuarioMOD = new List<UsuarioMOD>();
        private List<EspecialidadeVO> listaEspecialidade;
        private List<string> listaEspecialidadeAdicionado;
        private UsuarioMOD objUsuarioMOD = new UsuarioMOD();
        private UsuarioVO objUsuarioVO = new UsuarioVO();
        private List<GrupoUsuarioVO> lstGrupoUsuarioVO = new List<GrupoUsuarioVO>();
        private List<CondicaoVO> lstCondicaoVO = new List<CondicaoVO>();
        private List<EspecialidadeVO> lstEspecialidadeVO;
        private List<GrupoUsuarioVO> lstGrupoUsuarioTratadoVO;
        private List<string> lstEspecialidadeTratadoVO;
        private List<EspecialidadeUsuarioVO> lstUsuarioEspecialidade;
        private EspecialidadeVO objEspecialidadeVO;
        private HttpPostedFileBase file;
        private EspecialidadeUsuarioVO objUsuarioEspecialidade;
        private List<string> lstEspecialidadesNaoAdicionada;
        private List<string> lstEspecialidadesAdicionada;
        private UsuarioVO objUsuarioVOTratado;
        private bool boolFoto;

        public static List<EspecialidadeVO> ConstanteEspecialidade { get => constanteEspecialidade; set => constanteEspecialidade = value; }

        public ClienteController()
        {



        }

        private void bindDropDownList()
        {
            lstGrupoUsuarioVO = new List<GrupoUsuarioVO>();
            lstGrupoUsuarioVO = new Infra.Rest.RestGrupoUsuario().RestGet().ToList();

            lstCondicaoVO = new List<CondicaoVO>();
            lstCondicaoVO = new Infra.Rest.RestCondicao().RestGet().ToList();


            lstEspecialidadeVO = new List<EspecialidadeVO>();
            lstEspecialidadeVO = new Infra.Rest.RestEspecialidade().RestGet().ToList();
            lstEspecialidadesAdicionada = new List<string>();
            lstEspecialidadesNaoAdicionada = new List<string>();
            lstEspecialidadeTratadoVO = new List<string>();

        }

        //Criamos uma ação pra abrir uma tela de LISTAR
        public ActionResult Listar()
        {
            lstUsuario = new List<UsuarioVO>();
            lstUsuarioMOD = new List<UsuarioMOD>();


            lstUsuario = new Infra.Rest.RestUsuario().RestGet().ToList();

            foreach (var item in lstUsuario)
            {
                objUsuarioMOD = new UsuarioMOD();
                objUsuarioMOD.Id = item.Id;
                objUsuarioMOD.Celular = item.Celular;
                objUsuarioMOD.Email = item.Email;
                if (item.Flag_ativo == 0)
                {
                    objUsuarioMOD.FlagAtivo = false;
                }

                else
                {
                    objUsuarioMOD.FlagAtivo = true;
                }

                objUsuarioMOD.GrupoUsuario = new Infra.Rest.RestGrupoUsuario().RestGet().Where(i => i.Id == item.Grupo_usuario_id).ToList().First();

                objUsuarioMOD.Login = item.Login;
                objUsuarioMOD.Nome = item.Nome;
                objUsuarioMOD.Senha = item.Senha;
                objUsuarioMOD.Foto = item.Foto;

                lstUsuarioMOD.Add(objUsuarioMOD);
            }

            //É nesse momento que subimos a tela pra
            //Memória quando escrevemos return View
            //Carregamos uma página com o mesmo nome
            //Da action
            return View(lstUsuarioMOD);
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioMOD dadosTela)
        {
            try
            {
                objUsuarioVO = new UsuarioVO();
                dadosTela.Id = GetHashCode();

                if (dadosTela != null)
                {
                    if (dadosTela.Celular != null)
                    {
                        objUsuarioVO.Celular = dadosTela.Celular;
                    }

                    if (dadosTela.Email != null)
                    {
                        objUsuarioVO.Email = dadosTela.Email;
                    }
                    if (!dadosTela.FlagAtivo.Equals(null))
                    {
                        if (objUsuarioVO.Flag_ativo == 1)
                        {
                            objUsuarioVO.Flag_ativo = 1;
                        }

                        else
                        {
                            objUsuarioVO.Flag_ativo = 0;
                        }


                    }
                    if (dadosTela.GrupoUsuario != null)
                    {
                        objUsuarioVO.Grupo_usuario_id = dadosTela.GrupoUsuario.Id;
                    }



                    if (dadosTela.Login != null)
                    {
                        objUsuarioVO.Login = dadosTela.Login;
                    }
                    if (dadosTela.Id > 0)
                    {
                        objUsuarioVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objUsuarioVO.Nome = dadosTela.Nome;
                    }
                    if (dadosTela.Senha != null)
                    {
                        objUsuarioVO.Senha = dadosTela.Senha;
                    }
                    if (dadosTela.File != null)
                    {
                        objUsuarioVO.Foto = dadosTela.File.FileName;
                    }

                    if (dadosTela.Cidade != null)
                    {
                        objUsuarioVO.Cidade = dadosTela.Cidade;
                    }
                    if (dadosTela.Estado != null)
                    {
                        objUsuarioVO.Estado = dadosTela.Estado;
                    }

                    if (dadosTela.CpfCnpj != null)
                    {
                        objUsuarioVO.CpfCnpj = dadosTela.CpfCnpj;
                    }


                    if (dadosTela.Endereco != null)
                    {
                        objUsuarioVO.Endereco = dadosTela.Endereco;
                    }

                    if (dadosTela.Idade != null)
                    {
                        objUsuarioVO.Idade = dadosTela.Idade;
                    }


                    if (dadosTela.Latitude != null)
                    {
                        objUsuarioVO.Latitude = dadosTela.Latitude;
                    }

                    if (dadosTela.Longitude != null)
                    {
                        objUsuarioVO.Longitude = dadosTela.Longitude;
                    }


                    if (dadosTela.Rg != null)
                    {
                        objUsuarioVO.Rg = dadosTela.Rg;
                    }

                    if (dadosTela.Cep != null)
                    {
                        objUsuarioVO.Cep = dadosTela.Cep;
                    }


                    if (dadosTela.EspecialidadeTratado.Count > 0)
                    {
                        foreach (var item in dadosTela.EspecialidadeTratado)
                        {
                            objUsuarioEspecialidade = new EspecialidadeUsuarioVO();


                            objUsuarioEspecialidade.Codigo = new Random().Next();

                            objUsuarioEspecialidade.Especialidade = item.ToString();
                            objUsuarioEspecialidade.Usuario = objUsuarioVO.Id.ToString();

                            new Infra.Rest.RestEspecialidadeUsuario().RestPost(objUsuarioEspecialidade);
                        }
                    }





                    Upload(dadosTela);

                    new Infra.Rest.RestUsuario().RestPost(objUsuarioVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Usuario inserido com sucesso");
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



        [HttpPost]
        public ActionResult Index(UsuarioMOD model)
        {

            HttpPostedFileBase myfile = Request.Files[0];

            if (model.File.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(model.File.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                model.File.SaveAs(path);
            }

            /*process the file without uploading*/
            return Json(new { status = "success", message = "Encrypted!" });
        }


        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult Editar(UsuarioMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];


            objUsuarioVO.Id = Int32.Parse(param1);

            new Infra.Rest.RestUsuario().RestUpdate(objUsuarioVO.Id, objUsuarioVO);
            return View();
        }
        [HttpPost]
        public void Upload(UsuarioMOD model)
        {



            if (model.File.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(model.File.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                model.File.SaveAs(path);
            }
        }


        public void UploadEditar(UsuarioMOD model)
        {



            if (model.Foto != null)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(model.Foto);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                model.File.SaveAs(path);
            }
        }
        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TEdit(UsuarioMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];
            listaEspecialidade = new List<EspecialidadeVO>();
            listaEspecialidadeAdicionado = new List<string>();


            listaEspecialidade = new Infra.Rest.RestEspecialidade().RestGet();

            ViewBag.listaEspecialidade = listaEspecialidade;

            bindDropDownList();
            objUsuarioVO.Id = Int32.Parse(param1);
            bindDropDownList();
            objUsuarioVO = new Infra.Rest.RestUsuario().RestGetID(objUsuarioVO);

            ViewBag.Id = objUsuarioVO.Id;
            ViewBag.Celular = objUsuarioVO.Celular;
            ViewBag.Email = objUsuarioVO.Email;
            ViewBag.FlagAtivo = objUsuarioVO.Flag_ativo;
            ViewBag.Login = objUsuarioVO.Login;
            ViewBag.Nome = objUsuarioVO.Nome;
            ViewBag.Senha = objUsuarioVO.Senha;
            ViewBag.Cidade = objUsuarioVO.Cidade;
            ViewBag.Estado = objUsuarioVO.Estado;
            ViewBag.CpfCnpj = objUsuarioVO.CpfCnpj;
            ViewBag.Endereco = objUsuarioVO.Endereco;
            ViewBag.Cep = objUsuarioVO.Cep;
            ViewBag.Idade = objUsuarioVO.Idade;
            ViewBag.Latitude = objUsuarioVO.Latitude;
            ViewBag.Longitude = objUsuarioVO.Longitude;

            ViewBag.Rg = objUsuarioVO.Rg;



            if (dadosTela.Rg != null)
            {
                objUsuarioVO.Rg = dadosTela.Rg;
            }




            if (objUsuarioVO.Foto == null)
            {

                ViewBag.Foto = "user60.png";
            }
            else
            {
                ViewBag.Foto = objUsuarioVO.Foto;
            }

            lstGrupoUsuarioTratadoVO = new List<GrupoUsuarioVO>();
            lstGrupoUsuarioTratadoVO.AddRange(lstGrupoUsuarioVO.Where(m => m.Id == objUsuarioVO.Grupo_usuario_id));
            lstGrupoUsuarioTratadoVO.AddRange(lstGrupoUsuarioVO);

            ViewBag.GrupoUsuario = new SelectList
                  (
                      lstGrupoUsuarioTratadoVO,
                        "id",
                      "descricao"
                  );


            objUsuarioMOD = new UsuarioMOD();
            objUsuarioMOD.Id = objUsuarioVO.Id;
            objUsuarioMOD.Celular = objUsuarioVO.Celular;
            objUsuarioMOD.Email = objUsuarioVO.Email;
            if (objUsuarioVO.Flag_ativo == 0)
            {
                objUsuarioMOD.FlagAtivo = false;
            }

            else
            {
                objUsuarioMOD.FlagAtivo = true;
            }
            objUsuarioMOD.GrupoUsuario = new Infra.Rest.RestGrupoUsuario().RestGet().Where(i => i.Id == objUsuarioVO.Grupo_usuario_id).ToList().First();

            lstUsuarioEspecialidade = new List<EspecialidadeUsuarioVO>();
            /// Continuar aqui
            lstUsuarioEspecialidade = new Infra.Rest.RestEspecialidadeUsuario().RestGet();

            lstEspecialidadeVO = new List<EspecialidadeVO>();

            lstEspecialidadeVO = new Infra.Rest.RestEspecialidade().RestGet().ToList();

            lstEspecialidadeTratadoVO = new List<string>();

            foreach (var item in lstUsuarioEspecialidade.Where(i => i.Usuario == objUsuarioVO.Id.ToString()).ToList())
            {
                objEspecialidadeVO = new EspecialidadeVO();

                objEspecialidadeVO.Id = Convert.ToInt32(item.Especialidade);

                objEspecialidadeVO = new Infra.Rest.RestEspecialidade().RestGetID(objEspecialidadeVO);


                listaEspecialidadeAdicionado.Add(objEspecialidadeVO.Nome);

                ViewBag.listaEspecialidadeAdicionado = listaEspecialidadeAdicionado;


            }

            objUsuarioMOD.EspecialidadeTratado = listaEspecialidadeAdicionado;

            // objUsuarioMOD.Especialidade = new Infra.Rest.RestEspecialidade().RestGet().Where(i => i.Id == item.Grupo_usuario_id).ToList().First();
            objUsuarioMOD.Login = objUsuarioVO.Login;
            objUsuarioMOD.Nome = objUsuarioVO.Nome;
            objUsuarioMOD.Senha = objUsuarioVO.Senha;
            objUsuarioMOD.Foto = objUsuarioVO.Foto;


            bindViewBagDropDownlist();

            return View(objUsuarioMOD);
        }

        private bool ListCheck<T>(IEnumerable<T> l1, IEnumerable<T> l2)
        {
            // TODO: Null parm checks
            if (l1.Intersect(l2).Any())
            {
                Console.WriteLine("matched");
                return true;
            }
            else
            {
                Console.WriteLine("not matched");
                return false;
            }
        }
        [HttpPost]
        public ActionResult Atualizar(UsuarioMOD dadosTela)
        {
            try
            {

                objUsuarioVO = new UsuarioVO();
                if (dadosTela != null)
                {
                    if (dadosTela.Celular != null)
                    {
                        objUsuarioVO.Celular = dadosTela.Celular;
                    }

                    if (dadosTela.Email != null)
                    {
                        objUsuarioVO.Email = dadosTela.Email;
                    }

                    if (!dadosTela.FlagAtivo.Equals(null))
                    {
                        if (dadosTela.FlagAtivo)
                        {
                            objUsuarioVO.Flag_ativo = 1;
                        }

                        else
                        {
                            objUsuarioVO.Flag_ativo = 0;
                        }

                    }
                    if (dadosTela.GrupoUsuario != null)
                    {
                        objUsuarioVO.Grupo_usuario_id = dadosTela.GrupoUsuario.Id;
                    }

                    if (dadosTela.Login != null)
                    {
                        objUsuarioVO.Login = dadosTela.Login;
                    }
                    if (dadosTela.Id > 0)
                    {
                        objUsuarioVO.Id = Convert.ToInt32(dadosTela.Id);
                    }
                    if (dadosTela.Nome != null)
                    {
                        objUsuarioVO.Nome = dadosTela.Nome;
                    }
                    if (dadosTela.Senha != null)
                    {
                        objUsuarioVO.Senha = dadosTela.Senha;
                    }


                    if (dadosTela.Cidade != null)
                    {
                        objUsuarioVO.Cidade = dadosTela.Cidade;
                    }
                    if (dadosTela.Estado != null)
                    {
                        objUsuarioVO.Estado = dadosTela.Estado;
                    }

                    if (dadosTela.CpfCnpj != null)
                    {
                        objUsuarioVO.CpfCnpj = dadosTela.CpfCnpj;
                    }


                    if (dadosTela.Endereco != null)
                    {
                        objUsuarioVO.Endereco = dadosTela.Endereco;
                    }

                    if (dadosTela.Idade != null)
                    {
                        objUsuarioVO.Idade = dadosTela.Idade;
                    }


                    if (dadosTela.Latitude != null)
                    {
                        objUsuarioVO.Latitude = dadosTela.Latitude;
                    }

                    if (dadosTela.Longitude != null)
                    {
                        objUsuarioVO.Longitude = dadosTela.Longitude;
                    }


                    if (dadosTela.Rg != null)
                    {
                        objUsuarioVO.Rg = dadosTela.Rg;
                    }

                    if (dadosTela.Cep != null)
                    {
                        objUsuarioVO.Cep = dadosTela.Cep;
                    }

                    boolFoto = true;


                    if (dadosTela.File != null)
                    {


                        Upload(dadosTela);
                        objUsuarioVO.Foto = dadosTela.File.FileName;
                        boolFoto = false;


                    }


                    if (boolFoto)
                    {
                        objUsuarioVOTratado = new UsuarioVO();

                        objUsuarioVOTratado.Id = Int32.Parse(dadosTela.Id.ToString());

                        objUsuarioVOTratado = new Infra.Rest.RestUsuario().RestGetID(objUsuarioVOTratado);


                        if (objUsuarioVOTratado.Foto == null)
                        {

                            objUsuarioVO.Foto = "user60.png";
                        }
                        else
                        {
                            objUsuarioVO.Foto = objUsuarioVOTratado.Foto;
                        }



                    }

                    if (dadosTela.EspecialidadeTratado != null)
                    {
                        if (dadosTela.EspecialidadeTratado.Count > 0)
                        {


                            foreach (var item2 in new Infra.Rest.RestEspecialidadeUsuario().RestGet())
                            {
                                if (item2.Usuario == objUsuarioVO.Id.ToString())
                                {
                                    new Infra.Rest.RestEspecialidadeUsuario().RestDelete(item2);
                                }

                            }


                            foreach (var item in dadosTela.EspecialidadeTratado)
                            {
                                objUsuarioEspecialidade = new EspecialidadeUsuarioVO();



                                objUsuarioEspecialidade.Codigo = new Random().Next();

                                objUsuarioEspecialidade.Especialidade = item.ToString();
                                objUsuarioEspecialidade.Usuario = objUsuarioVO.Id.ToString();

                                new Infra.Rest.RestEspecialidadeUsuario().RestPost(objUsuarioEspecialidade);


                            }
                        }
                    }



                    new Infra.Rest.RestUsuario().RestUpdate(objUsuarioVO.Id, objUsuarioVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Usuario editado com sucesso.");
                }
                else
                {
                    TempData.Add("ATENCAO",
            "Todos os campos devem está preenchidos! ");
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
            return RedirectToAction("../Cuidador/Index");
        }

        //Criamos uma ação (ACTION) para abrir a tela
        //De cadastro de contatos
        public ActionResult TDelete(UsuarioMOD dadosTela)
        {
            string param1 = Request.QueryString["id"];


            objUsuarioVO.Id = Int32.Parse(param1);

            objUsuarioVO = new Infra.Rest.RestUsuario().RestGetID(objUsuarioVO);

            objUsuarioMOD.Id = objUsuarioVO.Id;

            objUsuarioMOD.Nome = objUsuarioVO.Nome;

            ViewBag.Id = objUsuarioVO.Id;
            ViewBag.Nome = objUsuarioVO.Nome;

            return View();
        }
        [HttpPost]
        public ActionResult Deletar(UsuarioMOD dadosTela)
        {
            try
            {
                objUsuarioVO = new UsuarioVO();

                if (dadosTela.Id > 0)
                {
                    objUsuarioVO.Id = Convert.ToInt32(dadosTela.Id);

                    objUsuarioVO.Nome = dadosTela.Nome;

                    new Infra.Rest.RestUsuario().RestDelete(objUsuarioVO);


                    //Depois de cadastrar o contato na tabela
                    //Enviamos uma mensagem de sucesso pra tela
                    TempData.Add("SUCESSO",
                                "Usuario excluido com sucesso..");
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


            bindDropDownList();

            lstUsuario = new List<UsuarioVO>();
            lstUsuarioMOD = new List<UsuarioMOD>();
            listaEspecialidade = new List<EspecialidadeVO>();
            listaEspecialidadeAdicionado = new List<string>();
            lstUsuario = new Infra.Rest.RestUsuario().RestGet().Where(i => i.Grupo_usuario_id == 19793832).ToList();

            foreach (var item in lstUsuario)
            {
                objUsuarioMOD = new UsuarioMOD();
                objUsuarioMOD.Id = item.Id;
                objUsuarioMOD.Celular = item.Celular;
                objUsuarioMOD.Email = item.Email;
                if (item.Flag_ativo == 0)
                {
                    objUsuarioMOD.FlagAtivo = false;
                }

                else
                {
                    objUsuarioMOD.FlagAtivo = true;
                }
                objUsuarioMOD.GrupoUsuario = new Infra.Rest.RestGrupoUsuario().RestGet().Where(i => i.Id == item.Grupo_usuario_id).ToList().First();

                //objUsuarioMOD.Especialidade = new Infra.Rest.RestEspecialidade().RestGet().Where(i => i.Id == item.Grupo_usuario_id).ToList().First();
                objUsuarioMOD.Login = item.Login;
                objUsuarioMOD.Nome = item.Nome;
                objUsuarioMOD.Senha = item.Senha;
                objUsuarioMOD.Foto = item.Foto;

                objUsuarioMOD.Latitude = item.Latitude;
                objUsuarioMOD.Longitude = item.Longitude;



                objUsuarioMOD.Cep = item.Cep;
                objUsuarioMOD.Nome = item.Nome;
                objUsuarioMOD.Senha = item.Senha;
                objUsuarioMOD.Foto = item.Foto;

                lstUsuarioMOD.Add(objUsuarioMOD);
            }
            objUsuarioMOD = new UsuarioMOD();
            objUsuarioMOD.lstUsuarioMod = lstUsuarioMOD;
            ViewBag.Usuario = objUsuarioMOD;

            bindViewBagDropDownlist();
            objUsuarioMOD.lstCondicaoVO = new Infra.Rest.RestCondicao().RestGet().ToList();
            objUsuarioMOD.FlagAtivo = true;
            return View(objUsuarioMOD);
        }

        private void bindViewBagDropDownlist()
        {
            ViewBag.GrupoUsuario = new SelectList
           (
               lstGrupoUsuarioVO,
               "id",
               "descricao"
           );
            ViewBag.CondicaoVO = new SelectList
          (
              lstCondicaoVO,
             "id",
             "nome" ,
               "ativo"
                   );

            ViewBag.Especialidade = new SelectList
                   (
                       lstEspecialidadeVO,
                       "id",
                       "nome"
                   );



            ViewBag.EspecialidadeTratado = new SelectList
                   (
                       lstEspecialidadeTratadoVO,
                       "id",
                       "nome"
                   );

            ViewBag.EspecialidadesAdicionada = new SelectList
            (
                lstEspecialidadesAdicionada,
                       "id",
                       "nome"
                   );


            ViewBag.lstEspecialidadesNaoAdicionada = new SelectList
                  (
                      lstEspecialidadesNaoAdicionada,
                       "id",
                       "nome"
                   );


            ViewBag.listaEspecialidade = new SelectList
          (
              listaEspecialidade,
                     "id",
                     "nome"
                 );


            ViewBag.listaEspecialidadeAdicionado = new SelectList
                  (
                      listaEspecialidadeAdicionado
                   );

        }
    }
}
