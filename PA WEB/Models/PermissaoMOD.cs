using PA.Web.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class PermissaoMOD
    {
        /// <summary>
        /// Atríbuto id.
        /// </summary>
        public long Id { get; set; }



        /// <summary>
        /// Atríbuto lstGrupoUsuarioMod.
        /// </summary>
        public GrupoUsuarioVO GrupoUsuarioVO { get; set; }

        /// <summary>
        /// Atríbuto lstPermissaoMod.
        /// </summary>
        public List<PermissaoMOD> lstPermissaoMod { get; set; }

        /// <summary>
        /// Atríbuto MenuVO.
        /// </summary>
        public MenuVO MenuVO { get; set; }


    }
}