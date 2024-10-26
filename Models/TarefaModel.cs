using agendamentoTarefas.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;

namespace agendamentoTarefas.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now.ToLocalTime();
        public StatusTarefaEnum Status { get; set; }
    }
}
