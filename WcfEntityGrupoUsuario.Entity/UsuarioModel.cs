using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfEntityGrupoUsuario.Entity
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string UsuarioLogin { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSenha { get; set; }
    }
}
