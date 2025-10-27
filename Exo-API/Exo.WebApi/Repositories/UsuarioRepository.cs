using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        // READ - Listar
        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        // CREATE - Cadastrar
        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        // READ - Buscar por ID
        public Usuario BuscarporId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        // UPDATE - Atualizar
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Tipo = usuario.Tipo;
            }
            _context.Usuarios.Update(usuarioBuscado);
            _context.SaveChanges();
        }

        // DELETE - Deletar
        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioBuscado);
            _context.SaveChanges();
        }
    }
}