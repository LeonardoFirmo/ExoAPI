using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public class ProjetoRepository : IProjetos
    {
        private readonly ChapterContext _chapterContext;
        public ProjetoRepository(ChapterContext context)
        {
            _chapterContext = context;
        }

        public void Atualizar(int IdProjeto, Projetos projetos)
        {
            Projetos projetoBuscado = _chapterContext.PROJETOS.Find(IdProjeto);

            if (projetoBuscado != null)
            {
                projetoBuscado.Titulo = projetos.Titulo;
                projetoBuscado.Situacao = projetos.Situacao;
                projetoBuscado.DataInicio = projetos.DataInicio;
                projetoBuscado.Tecnologia = projetos.Tecnologia;
                projetoBuscado.Requisitos = projetos.Requisitos;
                projetoBuscado.Area = projetos.Area;
            }

            _chapterContext.PROJETOS.Update(projetoBuscado);
            _chapterContext.SaveChanges();

        }

        public Projetos BuscarPorId(int IdProjeto)
        {
            return _chapterContext.PROJETOS.Find(IdProjeto);
        }

        public void Cadastrar(Projetos projetos)
        {
            _chapterContext.PROJETOS.Add(projetos);
            _chapterContext.SaveChanges();
        }

        public void Deletar(int IdProjeto)
        {
            Projetos protejos = _chapterContext.PROJETOS.Find(IdProjeto);
            _chapterContext.PROJETOS.Remove(protejos);
            _chapterContext.SaveChanges();
        }

        public List<Projetos> Ler()
        {
            return _chapterContext.PROJETOS.ToList();
        }
    }
}
