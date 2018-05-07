using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WcfEntityGrupoUsuario.Entity
{
    [DataContract]
    public class GrupoModel
    {
        [DataMember]
        [Display(Name = "GRUPO_ID")]
        public int GrupoId { get; set; }

        [DataMember]
        [Display(Name = "GRUPO_NOME")]
        public string GrupoNome { get; set; }
    }
}
