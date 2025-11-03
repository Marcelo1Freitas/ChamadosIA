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
        // Simulação de usuário logado em memória
        private static Usuario usuarioLogado = new Usuario
        {
            Id = 1,
            Email = "teste@cati.com",
            Telefone = "11999999999",
            Setor = "Suporte",
            Tipo = "Tecnico",
            SenhaHash = GerarHash("123456")
        };

        // GET: Login
        public IActionResult Login() => View();

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var senhaHash = GerarHash(senha);

            if (email == usuarioLogado.Email && senhaHash == usuarioLogado.SenhaHash)
            {
                TempData["UsuarioId"] = usuarioLogado.Id;
                return RedirectToAction("Dashboard", usuarioLogado.Tipo == "Tecnico" ? "Tecnico" : "Cliente");
            }

            ViewBag.Erro = "Credenciais inválidas";
            return View();
        }

        // GET: AtualizarConta
        [HttpGet]
public IActionResult AtualizarConta()
{
    if (TempData["UsuarioId"] is not int id || id != usuarioLogado.Id)
        return RedirectToAction("Login");

    var modelo = new Usuario
    {
        Email = usuarioLogado.Email,
        Telefone = usuarioLogado.Telefone,
        Setor = usuarioLogado.Setor
    };

    return View(modelo);
}


        // POST: AtualizarConta
        [HttpPost]
public IActionResult AtualizarConta(Usuario dados)
{
    if (TempData["UsuarioId"] is not int id || id != usuarioLogado.Id)
        return RedirectToAction("Login");

    if (!string.IsNullOrEmpty(dados.NovaSenha))
    {
        if (dados.NovaSenha != dados.ConfirmarSenha)
        {
            TempData["Erro"] = "❌ As senhas não coincidem.";
            return View(dados);
        }

        usuarioLogado.SenhaHash = GerarHash(dados.NovaSenha);
    }

    usuarioLogado.Email = dados.Email;
    usuarioLogado.Telefone = dados.Telefone;
    usuarioLogado.Setor = dados.Setor;

    TempData["Sucesso"] = "✅ Dados atualizados com sucesso!";
    return RedirectToAction("Confirmacao");
}

        public IActionResult Confirmacao()
        {
            ViewBag.Mensagem = TempData["Sucesso"] ?? TempData["Erro"];
            return View();
        }

        private static string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes);
        }
    }
}
