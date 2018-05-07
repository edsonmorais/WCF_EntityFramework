using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfEntityGrupoUsuario.Entity;
using FastMapper;

namespace WcfEntityGrupoUsuario.Service
{
    public class GrupoRepositorio : IGrupoRepositorio
    {

        
        public void Atualizar(GrupoModel grupo)
        {

            using (var db = new ProfileEntities())
            {
                var grupoEdit = db.Grupo.SingleOrDefault(g => g.GrupoId == grupo.GrupoId);

                if (grupoEdit != null)
                {
                    try
                    {
                        grupoEdit.GrupoNome = grupo.GrupoNome;

                        db.SaveChanges();

                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        }

        public GrupoModel Buscar(int grupoId)
        {
            var grupo = new GrupoModel();

            using (var db = new ProfileEntities())
            {
                if (db != null)
                {
                    try
                    {
                        var grupoEntity = db.Grupo.SingleOrDefault(g => g.GrupoId == grupoId);

                        if (grupoEntity != null)
                            TypeAdapter.Adapt(grupoEntity, grupo);
                    }
                    catch 
                    {
                        throw;
                    }
                }
            }

            return grupo;
        }

        public void Deletar(int grupoId)
        {
            using (var db = new ProfileEntities())
            {
                if (db != null)
                {
                    try
                    {
                        var grupo = db.Grupo.SingleOrDefault(g => g.GrupoId == grupoId);

                        db.Grupo.Remove(grupo);

                        db.SaveChanges();

                    }
                    catch 
                    {
                        throw;
                    }


                }
                
            }

        }

        public void Inserir(GrupoModel grupo)
        {
            var db = new ProfileEntities();

            try
            {
                db.Grupo.Add(new Grupo()
                {
                    GrupoNome = grupo.GrupoNome
                });

                db.SaveChanges();

            }
            catch 
            {
                throw;
            }

            
        }
    }
}
