using ExoAPI.Models;

namespace ExoAPI.Interfaces
{
    public interface IProjetos
    {
        List<Projetos> Ler();
        void Cadastrar(Projetos projetos);
        void Atualizar(int IdProjeto, Projetos projetos);
        void Deletar(int IdProjeto);
        Projetos BuscarPorId(int IdProjeto);
    }
}
