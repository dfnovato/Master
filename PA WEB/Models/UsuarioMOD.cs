using PA.Web.VO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;

namespace PA.Web.Models
{
    public class UsuarioMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o nome do usuário")]
        public string Nome { get; set; }


        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "CpfCnpj")]
        [Required(ErrorMessage = "Preencha o Cpf/Cnpj do usuário")]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Cep")]
        [Required(ErrorMessage = "Preencha o Cep do usuário")]
        public string Cep { get; set; }


        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "Preencha o Endereço do usuário")]
        public string Endereco { get; set; }



        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Preencha o Latitude do usuário")]
        public string Latitude { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Preencha o Longitude do usuário")]
        public string Longitude { get; set; }


        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Rg")]
        [Required(ErrorMessage = "Preencha o Rg do usuário")]
        public string Rg { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "Preencha a Data de Nascimento do usuário")]
        public string DataNascimento { get; set; }

        /// <summary>
        /// Atríbuto login.
        /// </summary>
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Preencha o login do usuário")]
        public string Login { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha o senha do usuário")]
        public string Senha { get; set; }

        /// <summary>
        /// Atríbuto flagAtivo.
        /// </summary>
        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "Selecione se o usuário está ativo.")]
        public bool FlagAtivo { get; set; }

        /// <summary>
        /// Atríbuto celular.
        /// </summary>
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Preencha o celular do usuário")]
        public string Celular { get; set; }

        /// <summary>
        /// Atríbuto celular.
        /// </summary>
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Preencha o Estado do usuário")]
        public string Estado { get; set; }


        /// <summary>
        /// Atríbuto Cidade.
        /// </summary>
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Preencha o Cidade do usuário")]
        public string Cidade { get; set; }



        /// <summary>
        /// Atríbuto Cidade.
        /// </summary>
        [Display(Name = "Idade")]
        [Required(ErrorMessage = "Preencha o Idade do usuário")]
        public string Idade { get; set; }

        /// <summary>
        /// Atríbuto email.
        /// </summary>
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o e-mail do usuário")]
        public string Email { get; set; }



        /// <summary>
        /// Atríbuto Bairro.
        /// </summary>
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Preencha o Bairro do usuário")]
        public string Bairro { get; set; }

        /// <summary>
        /// Atríbuto Pessoa para Contato.
        /// </summary>
        [Display(Name = "Pessoa para Contato")]
        [Required(ErrorMessage = "Preencha o Pessoa para Contato")]
        public string PessoaContato { get; set; }

        /// <summary>
        /// Atríbuto PlanoSaude.
        /// </summary>
        [Display(Name = "Plano Saude")]
        [Required(ErrorMessage = "Preencha o Plano Saude ")]
        public string PlanoSaude { get; set; }

        /// <summary>
        /// Atríbuto TipoSaude.
        /// </summary>
        [Display(Name = "Medico")]
        [Required(ErrorMessage = "Preencha o Medico ")]
        public string Medico { get; set; }

        /// <summary>
        /// Atríbuto TipoSaude.
        /// </summary>
        [Display(Name = "Tipo Saude")]
        [Required(ErrorMessage = "Preencha o Tipo Saude ")]
        public string TipoSaude { get; set; }

        /// <summary>
        /// Atríbuto TipoSaude.
        /// </summary>
        [Display(Name = "Telefone Medico")]
        [Required(ErrorMessage = "Preencha o telefone do Medico ")]
        public string MedicoTelefone { get; set; }


        /// <summary>
        /// Atríbuto Observacao.
        /// </summary>
        [Display(Name = "Observacao")]
        [Required(ErrorMessage = "Preencha o Observacao ")]
        public string Observacao { get; set; }


        /// <summary>
        /// Atríbuto MedicacaoDiaria.
        /// </summary>
        [Display(Name = "Medicacao Diaria")]
        [Required(ErrorMessage = "Preencha o Medicacao Diaria ")]
        public string MedicacaoDiaria { get; set; }

        /// <summary>
        /// Atríbuto procedimentorotina.
        /// </summary>
        [Display(Name = "Procedimento Rotina")]
        [Required(ErrorMessage = "Preencha o Procedimento Rotina ")]
        public string ProcedimentoRotina { get; set; }


        [Display(Name = "Condicoes do paciente")]
        [Required(ErrorMessage = "Selecione as condicoes")]
        public List<CondicaoVO> lstCondicaoVO { get; set; }

        /// <summary>
        /// Atríbuto grupoUsuario.
        /// </summary>
        [Display(Name = "grupoUsuario")]
        [Required(ErrorMessage = "Preencha o nome do usuário")]
        public GrupoUsuarioVO GrupoUsuario { get; set; }


        /// <summary>
        /// Atríbuto grupoUsuario.
        /// </summary>
        [Display(Name = "Condicao")]
        [Required(ErrorMessage = "Preencha o Condicao do paciente")]
        public CondicaoVO CondicaoVO { get; set; }

        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Selecione as especialidades")]
        public EspecialidadeVO Especialidade { get; set; }

        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Selecione as especialidades")]
        public EspecialidadeVO EspecialidadeAdicionado { get; set; }

        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Selecione as especialidades")]
        public List<string> EspecialidadeTratado { get; set; }

        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Selecione as especialidades")]
        public List<EspecialidadeVO> lstEspecialidadeTratado { get; set; }




        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Selecione as especialidades")]
        public List<EspecialidadeVO> listaEspecialidade{ get; set; }
        /// <summary>
        /// Atríbuto lstUsuarioMod.
        /// </summary>
        public List<UsuarioMOD> lstUsuarioMod { get; set; }


        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Selecione as fotos")]
        public string Foto { get;  set; }


        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}