using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class GrupoUsuarioMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto nome.
        /// </summary>
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Preencha o nome do usuário")]
        public string Descricao { get; set; }



        /// <summary>
        /// Atríbuto lstGrupoUsuarioMod.
        /// </summary>
        public List<GrupoUsuarioMOD> lstGrupoUsuarioMod { get; set; }
    }
}