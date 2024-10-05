using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PA.Web.Models
{
    public class MenuMOD
    {
        public long Id { get; set; }

        /// <summary>
        /// Atríbuto controller.
        /// </summary>
        [Display(Name = "nameOption")]
        [Required(ErrorMessage = "nameOption")]
        public string nameOption { get; set; }

        /// <summary>
        /// Atríbuto controller.
        /// </summary>
        [Display(Name = "controller")]
        [Required(ErrorMessage = "controller")]
        public string controller { get; set; }

        /// <summary>
        /// Atríbuto action.
        /// </summary>
        [Display(Name = "action")]
        [Required(ErrorMessage = "action")]
        public string action { get; set; }

        /// <summary>
        /// Atríbuto area.
        /// </summary>
        [Display(Name = "area")]
        [Required(ErrorMessage = "area")]
        public string area { get; set; }

        /// <summary>
        /// Atríbuto imageClass.
        /// </summary>
        [Display(Name = "imageClass")]
        [Required(ErrorMessage = "imageClass")]
        public string imageClass { get; set; }

        /// <summary>
        /// Atríbuto activeli.
        /// </summary>
        [Display(Name = "activeli")]
        [Required(ErrorMessage = "activeli")]
        public string activeli { get; set; }

        /// <summary>
        /// Atríbuto status.
        /// </summary>
        [Display(Name = "status")]
        [Required(ErrorMessage = "status")]
        public bool status { get; set; }
     
        
        /// <summary>
        /// Atríbuto isParent.
        /// </summary>
        [Display(Name = "parentId")]
        [Required(ErrorMessage = "parentId")]
        public int parentId { get; set; }
 
        /// <summary>
        /// Atríbuto isParent.
        /// </summary>
        [Display(Name = "isParent")]
        [Required(ErrorMessage = "isParent")]
        public bool isParent { get; set; }


        /// <summary>
        /// Atríbuto lstMapaMOD.
        /// </summary>
        public List<MenuMOD> lstMenuMOD { get; set; }
    }
}