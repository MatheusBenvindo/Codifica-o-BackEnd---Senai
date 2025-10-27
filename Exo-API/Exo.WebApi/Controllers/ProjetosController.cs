using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController: ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;
        
        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        // Endpoint que já tínhamos (GET /api/projetos)
        [HttpGet]
        public IActionResult Listar()
        {
            // Chama o método Listar do repositório
            return Ok(_projetoRepository.Listar());
        }

        // NOVO ENDPOINT (GET /api/projetos/{id})
        [HttpGet("{id}")] // Define que a rota receberá um ID
        public IActionResult BuscarporId(int id)
        {
            // Busca o projeto no repositório
            Projeto projeto = _projetoRepository.BuscarporId(id);
            if (projeto == null)
            {
                // Retorna 404 Not Found se o projeto não existir
                return NotFound();
            }
            // Retorna 200 OK com o projeto encontrado
            return Ok(projeto);
        }

        // NOVO ENDPOINT (POST /api/projetos)
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            // Chama o método Cadastrar do repositório
            _projetoRepository.Cadastrar(projeto);
            
            // Retorna 201 Created (sucesso ao criar)
            return StatusCode(201);
        }

        // NOVO ENDPOINT (PUT /api/projetos/{id})
        [HttpPut("{id}")] // Define que a rota receberá um ID
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            // Chama o método Atualizar do repositório
            _projetoRepository.Atualizar(id, projeto);
            
            // Retorna 204 No Content (sucesso na atualização)
            return StatusCode(204);
        }

        // NOVO ENDPOINT (DELETE /api/projetos/{id})
        [HttpDelete("{id}")] // Define que a rota receberá um ID
        public IActionResult Deletar(int id)
        {
            try
            {
                // Tenta deletar o projeto
                _projetoRepository.Deletar(id);
                
                // Retorna 204 No Content (sucesso na deleção)
                return StatusCode(204);
            }
            catch (Exception)
            {
                // Retorna um erro caso algo dê errado
                return BadRequest();
            }
        }
    }
}