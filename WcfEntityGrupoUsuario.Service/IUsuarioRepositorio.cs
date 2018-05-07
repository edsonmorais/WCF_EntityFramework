using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfEntityGrupoUsuario.Entity;

namespace WcfEntityGrupoUsuario.Service
{
    [ServiceContract]
    public interface IUsuarioRepositorio
    {
        [OperationContract]
        void Inserir(UsuarioModel usuario);
        [OperationContract]
        void Atualizar(UsuarioModel usuario);
        [OperationContract]
        void Deletar(int usuarioId);
        [OperationContract]
        UsuarioModel Buscar(int usuarioId);
    }
}
