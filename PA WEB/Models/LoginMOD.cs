using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class LoginMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto Descricao.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Usuário obrigatório")]
        public string Usuario { get; set; }

        /// <summary>
        /// Atríbuto Descricao.
        /// </summary>
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha obrigatório")]
        public string Senha { get; set; }
        /// <summary>
        /// Atríbuto Descricao.
        /// </summary>
        [Display(Name = "SenhaAtual")]
        [Required(ErrorMessage = "Senha obrigatório")]
        public string SenhaAtual { get; set; }
        /// <summary>
        /// Atríbuto Descricao.
        /// </summary>
        [Display(Name = "Senha Confirmação")]
        [Required(ErrorMessage = "Confirmação Senha obrigatório")]
        public string SenhaConfirmacao { get; set; }

        /// <summary>
        /// Atríbuto Descricao.
        /// </summary>
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }


        /// <summary>
        /// Atríbuto lstUfMod.
        /// </summary>
        public List<LoginMOD> lstLoginMOD { get; set; }
    }
}