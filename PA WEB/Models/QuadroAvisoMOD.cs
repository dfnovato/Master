using PA.Web.VO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PA.Web.Models
{
    public class QuadroAvisoMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Assunto")]
        [Required(ErrorMessage = "Preencha o assunto")]
        public string Assunto { get; set; }

        /// <summary>
        /// Atríbuto login.
        /// </summary>
        [Display(Name = "Conteudo")]
        [Required(ErrorMessage = "Preencha o conteúdo")]
        public string Conteudo { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Preencha o data")]
        public string Data { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Preencha o usuario")]
        public int Usuario { get; set; }

        /// <summary>
        /// Atríbuto senha.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Preencha o usuario")]
        public string UsuarioNome { get; set; }
        /// <summary>
        /// Atríbuto lstUsuarioMod.
        /// </summary>
        public List<QuadroAvisoMOD> lstQuadroAvisoMOD { get; set; }
    }
}