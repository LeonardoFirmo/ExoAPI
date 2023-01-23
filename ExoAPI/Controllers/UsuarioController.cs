using ExoAPI.Interfaces;
using ExoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Http;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _iusuario;
        public UsuarioController(IUsuario iusuario)
        {
            _iusuario = iusuario;
        }

        [HttpGet]
        public IActionResult ListarUsuario()
        {
            try
            {
                return Ok(_iusuario.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{IdUsuario}")]
        public IActionResult GetById(int IdUsuario)
        {
            try
            {
                Usuarios usuarioBusacado = _iusuario.BuscarPorId(IdUsuario);

                if (usuarioBusacado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioBusacado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult CadastarUsuario(Usuarios usuarios)
        {
            try
            {
                _iusuario.Cadastrar(usuarios);
                return StatusCode(201);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{IdUsuario}")]
        public IActionResult AtualizarUsario(int IdUsuario, Usuarios usuarios)

        {
            try
            {
                _iusuario.Atualizar(IdUsuario, usuarios);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }

        [HttpDelete("{IdUsuario}")]
        public IActionResult DeletarUsuario(int IdUsuario)
        {
            try
            {
                _iusuario.Deletar(IdUsuario);
                return Ok("Usuario Excluido");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }




    }
}
