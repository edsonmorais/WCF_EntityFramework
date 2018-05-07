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
    public interface IGrupoRepositorio
    {
        [OperationContract]
        void Inserir(GrupoModel grupo);
        [OperationContract]
        void Atualizar(GrupoModel grupo);
        [OperationContract]
        void Deletar(int grupoId);
        [OperationContract]
        GrupoModel Buscar(int grupoId);
    }
}
