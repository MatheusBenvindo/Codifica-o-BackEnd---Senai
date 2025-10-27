using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;
        
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        // Método que já tínhamos (READ - Listar)
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        // NOVO MÉTODO (READ - Buscar por ID)
        public Projeto BuscarporId(int id)
        {
            // Usa o método Find para buscar um projeto pelo seu Id
            return _context.Projetos.Find(id);
        }

        // NOVO MÉTODO (CREATE - Cadastrar)
        public void Cadastrar(Projeto projeto)
        {
            // Adiciona o novo projeto ao contexto
            _context.Projetos.Add(projeto);
            
            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        // NOVO MÉTODO (UPDATE - Atualizar)
        public void Atualizar(int id, Projeto projeto)
        {
            // Busca o projeto existente no banco pelo id
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                // Atualiza os campos do projeto buscado com os
                // dados do projeto recebido como parâmetro
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;
            }

            // Adiciona o projeto atualizado ao contexto
            _context.Projetos.Update(projetoBuscado);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }

        // NOVO MÉTODO (DELETE - Deletar)
        public void Deletar(int id)
        {
            // Busca o projeto pelo id
            Projeto projetoBuscado = _context.Projetos.Find(id);

            // Remove o projeto do contexto
            _context.Projetos.Remove(projetoBuscado);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
    }
}