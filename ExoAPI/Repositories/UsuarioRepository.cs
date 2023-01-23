using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ChapterContext _chapterContext;

        public UsuarioRepository(ChapterContext context)
        {
            _chapterContext = context;
        }



        public void Atualizar(int IdUsuario, Usuarios usuario)
        {
            Usuarios UsuarioBuscado = _chapterContext.USUARIOS.Find(IdUsuario);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.Email = usuario.Email;
                UsuarioBuscado.Senha = usuario.Senha;
                UsuarioBuscado.Tipo = usuario.Tipo;

                _chapterContext.USUARIOS.Update(UsuarioBuscado);
                _chapterContext.SaveChanges();

            }
        }

        public Usuarios BuscarPorId(int IdUsuario)
        {
            return _chapterContext.USUARIOS.Find(IdUsuario);
        }

        public void Cadastrar(Usuarios usuario)
        {
            _chapterContext.USUARIOS.Add(usuario);
            _chapterContext.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            Usuarios usuarioBuscado = _chapterContext.USUARIOS.Find(IdUsuario);
            _chapterContext.USUARIOS.Remove(usuarioBuscado);
            _chapterContext.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return _chapterContext.USUARIOS.ToList();
        }

        Usuarios IUsuario.Login(string Email, string Senha)
        {
            throw new NotImplementedException();
        }
    }
}
