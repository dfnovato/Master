using PA.Web.VO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PA.Web.Models
{
    public class EspecialidadeMOD
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
        /// Atríbuto lstEspecialidadeMod.
        /// </summary>
        public List<EspecialidadeMOD> lstEspecialidadeMod { get; set; }
    }
}