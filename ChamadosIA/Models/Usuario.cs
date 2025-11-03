using System.ComponentModel.DataAnnotations;

namespace ChamadosIA.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Setor { get; set; }
        public string Tipo { get; set; } = "Cliente"; // ou "Tecnico"
        public string SenhaHash { get; set; } = string.Empty;

        // Campos temporários para atualização
        public string NovaSenha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
    /*(public class Usuario ///////// EM TESTE PARA DAR STOP NO ERRO WARNIG CS8618
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }*/

