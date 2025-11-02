using Microsoft.AspNetCore.Mvc;
using ChamadosIA.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChamadosIA.Controllers
{
    public class ChamadoController : Controller
    {
        // Simulação de banco de dados em memória
        private static List<Chamado> chamados = new();

        public IActionResult Abrir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Abrir(Chamado chamado)
        {
            chamado.ID_Chamado = chamados.Count + 1;
            chamados.Add(chamado);
            return RedirectToAction("MeusChamados");
        }

        public IActionResult MeusChamados()
        {
            var lista = chamados.Where(c => c.ClienteEmail == "cliente@email.com").ToList(); // Simulação
            return View(lista);
        }

        public IActionResult Fila()
        {
            var fila = chamados.Where(c => c.Status == StatusChamado.EmAberto).ToList();
            return View(fila);
        }

        public IActionResult Atendimento()
        {
            var emAtendimento = chamados.Where(c => c.Status == StatusChamado.EmAtendimento).ToList();
            return View(emAtendimento);
        }

        public IActionResult Resolvidos()
        {
            var resolvidos = chamados.Where(c => c.Status == StatusChamado.Resolvido).ToList();
            return View(resolvidos);
        }

        public IActionResult Editar(int id)
        {
            var chamado = chamados.FirstOrDefault(c => c.ID_Chamado == id);
            return View(chamado);
        }

        [HttpPost]
        public IActionResult Editar(Chamado chamadoAtualizado)
        {
            var chamado = chamados.FirstOrDefault(c => c.ID_Chamado == chamadoAtualizado.ID_Chamado);
            if (chamado != null)
            {
                chamado.Observacoes = chamadoAtualizado.Observacoes;
                chamado.TelefoneContato = chamadoAtualizado.TelefoneContato;
                chamado.EnderecoAtendimento = chamadoAtualizado.EnderecoAtendimento;
            }
            return RedirectToAction("MeusChamados");
        }

        public IActionResult Cancelar(int id)
        {
            var chamado = chamados.FirstOrDefault(c => c.ID_Chamado == id);
            if (chamado != null)
            {
                chamado.Status = StatusChamado.Fechado;
            }
            return RedirectToAction("MeusChamados");
        }
    }
}