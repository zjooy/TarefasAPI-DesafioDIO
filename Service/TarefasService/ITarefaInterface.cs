using agendamentoTarefas.Enums;
using agendamentoTarefas.Models;

namespace agendamentoTarefas.Service.TarefasService
{
    public interface ITarefaInterface
    {
        Task<ServiceResponse<TarefaModel>> GetTarefaById(int id);
        Task<ServiceResponse<List<TarefaModel>>> UpdateTarefa(int id, TarefaModel tarefaEditada);
        Task<ServiceResponse<List<TarefaModel>>> DeleteTarefa(int id);
        Task<ServiceResponse<List<TarefaModel>>> GetTarefas();
        Task<ServiceResponse<List<TarefaModel>>> GetTarefaByTitulo(string titulo);
        Task<ServiceResponse<List<TarefaModel>>> GetTarefaByData(DateTime data);
        Task<ServiceResponse<List<TarefaModel>>> GetTarefaByStatus(StatusTarefaEnum status);
        Task<ServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel tarefa);
    }
}

