using PA.Web.VO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PA.Web.Models
{
    public class CondicaoMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha a condicao do paciente")]
        public string Nome { get; set; }

    

       /// <summary>
        /// Atríbuto lstStatusMod.
        /// </summary>
        public List<CondicaoMOD> lstCondicaoMOD { get; set; }
    }
}