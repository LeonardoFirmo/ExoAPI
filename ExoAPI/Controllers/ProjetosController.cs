using ExoAPI.Interfaces;
using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")] 
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetos _iprojeto;
        public ProjetosController(IProjetos projeto)
        {
            _iprojeto = projeto;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iprojeto.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Projetos projetos)
        {
            try
            {
                _iprojeto.Cadastrar(projetos);
                return Ok(projetos);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut]

        public IActionResult Atualizar(int IdProjeto, Projetos projetos)
        {
            try
            {
                _iprojeto.Atualizar(IdProjeto, projetos);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpGet("{IdProjeto}")]
        public IActionResult GetById(int IdProjeto)
        {
            try
            {
                Projetos projetos = _iprojeto.BuscarPorId(IdProjeto);

                if (projetos == null)
                {
                    return NotFound();
                }
                return Ok(projetos);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{IdProjeto}")]
        public IActionResult Remove(int IdProjeto)
        {
            try
            {
                Projetos projetos = _iprojeto.BuscarPorId(IdProjeto);
                _iprojeto.Deletar(IdProjeto);
                return StatusCode(204);


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }

}
