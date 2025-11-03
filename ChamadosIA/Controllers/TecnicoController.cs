using Microsoft.AspNetCore.Mvc;
using ChamadosIA.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChamadosIA.Controllers
{
    public class TecnicoController : Controller
    {
    public IActionResult Dashboard()
{
    return View("DashboardTecnico"); // ← chama Views/Tecnico/DashboardTecnico.cshtml
}

        public IActionResult Estatisticas(string status)
        {
            // Simulação: acessando a lista de chamados do ChamadoController
            var chamadosFiltrados = DataStore.Chamados
                .Where(c => string.IsNullOrEmpty(status) || c.Status.ToString() == status)
                .ToList();

            ViewBag.TotalAtendidos = chamadosFiltrados.Count(c => c.Status == StatusChamado.Resolvido || c.Status == StatusChamado.Fechado);
            ViewBag.EmAtendimento = chamadosFiltrados.Count(c => c.Status == StatusChamado.EmAtendimento);
            ViewBag.TempoMedio = "45 min"; // Simulação
            ViewBag.Resolvidos = chamadosFiltrados.Count(c => c.Status == StatusChamado.Resolvido);

            ViewBag.Chamados = chamadosFiltrados;
            return View();
        }
    }
}