using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class CargaMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Carga")]
        [Required(ErrorMessage = "Preencha o Carga do usuário")]
        public string Carga { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Preencha o Valor do usuário")]
        public string Valor { get; set; }


        /// <summary>
        /// Atríbuto lstCargaMod.
        /// </summary>
        public List<CargaMOD> lstCargaMod { get; set; }
    }
}