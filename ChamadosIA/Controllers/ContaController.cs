using Microsoft.AspNetCore.Mvc;
using ChamadosIA.Data;
using ChamadosIA.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ChamadosIA.Controllers
{
    public class ContaController : Controller
    {
        private readonly AppDbContext _context;

        public ContaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login() => View();

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var senhaHash = GerarHash(senha);
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.SenhaHash == senhaHash);

            if (usuario != null)
            {
                // Autenticação (ex: cookie/session)
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Credenciais inválidas";
            return View();
        }

        // GET: Cadastro
        public IActionResult Cadastro() => View();

        // POST: Cadastro
        [HttpPost]
        public async Task<IActionResult> Cadastro(Usuario usuario)
        {
            usuario.SenhaHash = GerarHash(usuario.SenhaHash);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        private string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }
    }
}