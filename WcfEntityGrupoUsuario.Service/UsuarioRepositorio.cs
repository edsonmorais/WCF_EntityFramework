using FastMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfEntityGrupoUsuario.Entity;

namespace WcfEntityGrupoUsuario.Service
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void Atualizar(UsuarioModel usuario)
        {
            using (var db = new ProfileEntities())
            {
                try
                {



                    //Uma das formas de atualizar o registro é utilizando os métodos Attach e Entry, definindo o estado do objeto para "Modified"
                    //Mas esta forma pode dar erro caso o registro que se pretende atualizar tenha sido excluído
                    //É necessário fazer alguma validação antes de aplicar o "SaveChanges()"
                    var usuarioEntity = TypeAdapter.Adapt(usuario, new Usuario());
                    db.Usuario.Attach(usuarioEntity);
                    db.Entry(usuarioEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    //Outra forma é retornando o registro do Entity Model, editando e salvando as alterações
                    /*
                    var usuarioEntity = db.Usuario.SingleOrDefault(u => u.UsuarioId == usuario.UsuarioId);
                    if (usuarioEntity != null)
                    {
                        usuarioEntity.UsuarioLogin = usuario.UsuarioLogin;
                        usuarioEntity.UsuarioNome = usuario.UsuarioNome;
                        usuarioEntity.UsuarioSenha = usuario.UsuarioSenha;

                        db.SaveChanges();
                    }
                    */



                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public UsuarioModel Buscar(int usuarioId)
        {
            var usuario = new UsuarioModel();

            using (var db = new ProfileEntities())
            {
                try
                {
                    var usuarioEntity = db.Usuario.SingleOrDefault(u => u.UsuarioId == usuarioId);

                    if (usuarioEntity != null)
                    {
                        TypeAdapter.Adapt(usuarioEntity, usuario);
                    }
                    else
                        throw new Exception("Usuário não localizado");
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            return usuario;
        }

        public void Deletar(int usuarioId)
        {
            using (var db = new ProfileEntities())
            {
                try
                {
                    var usuarioEntity = db.Usuario.SingleOrDefault(u => u.UsuarioId == usuarioId);

                    if (usuarioEntity != null)
                    {
                        db.Usuario.Remove(usuarioEntity);

                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Inserir(UsuarioModel usuario)
        {

            using (var db = new ProfileEntities())
            {

                try
                {

                    var usuarioEntity = new Usuario();

                    TypeAdapter.Adapt(usuario, usuarioEntity);

                    if (usuarioEntity != null && !string.IsNullOrEmpty(usuarioEntity.UsuarioLogin))
                    {
                        db.Usuario.Add(usuarioEntity);
                        db.SaveChanges();
                    }


                }
                catch
                {
                    throw;
                }

            }

        }
    }
}
