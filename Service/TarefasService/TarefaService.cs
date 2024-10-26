using agendamentoTarefas.DataContext;
using agendamentoTarefas.Enums;
using agendamentoTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace agendamentoTarefas.Service.TarefasService
{
    public class TarefaService : ITarefaInterface
    {
        private readonly ApplicationDbContext _context;
        public TarefaService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel tarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Preencha os dados para prosseguir!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(tarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> DeleteTarefa(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>> ();

            try
            {
                TarefaModel tarefa = _context.Tarefas.SingleOrDefault(t => t.Id == id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();
                serviceResponse.Mensagem = "Tarefa excluida";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefaByData(DateTime data)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                var tarefas = await _context.Tarefas
                                            .Where(t => t.Data.Date == data.Date) 
                                            .ToListAsync();

                if (tarefas.Count() == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhuma tarefa encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = tarefas;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TarefaModel>> GetTarefaById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = new ServiceResponse<TarefaModel>();

            try
            {
                TarefaModel tarefa = _context.Tarefas.SingleOrDefault(t => t.Id == id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não encontrada";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = tarefa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefaByStatus(StatusTarefaEnum status)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                var tarefa = _context.Tarefas.Where(t => t.Status == status).ToList(); 

                if (tarefa.Count() == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = $"Nenhuma tarefa com o status {status}";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = tarefa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefaByTitulo(string titulo)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                var tarefa = _context.Tarefas.Where(t => t.Titulo == titulo).ToList(); 

                if (tarefa.Count() == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = $"Nenhuma tarefa com o titulo {titulo}";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = tarefa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefas()
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                serviceResponse.Dados = _context.Tarefas.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }

                serviceResponse.Mensagem = "Tarefas localizadas com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> UpdateTarefa(int id, TarefaModel tarefaEditada)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                TarefaModel tarefa = _context.Tarefas.AsNoTracking().SingleOrDefault(t => t.Id == id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhuma tarefa encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                tarefa.Titulo = tarefaEditada.Titulo;
                tarefa.Descricao = tarefaEditada.Descricao;
                tarefa.Data = tarefaEditada.Data;
                tarefa.Status = tarefaEditada.Status;

                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
