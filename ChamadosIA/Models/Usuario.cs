using System.ComponentModel.DataAnnotations;

namespace ChamadosIA.Models
{
    public class Usuario
{
    public int ID_Usuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;

}
    /*(public class Usuario ///////// EM TESTE PARA DAR STOP NO ERRO WARNIG CS8618
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }*/
}
