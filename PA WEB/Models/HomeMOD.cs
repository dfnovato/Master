using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class HomeMOD
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


        public string Title { get; set; }


        public string Description { get; set; }


        public string Link { get; set; }



        /// <summary>
        /// Atríbuto lstUsuarioMod.
        /// </summary>
        //public List<RssReader> lstRssReader { get; set; }
        /// <summary>
        /// Atríbuto lstUfMod.
        /// </summary>
        public List<LoginMOD> lstLoginMOD { get; set; }
    }
}