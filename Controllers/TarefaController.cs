using agendamentoTarefas.Enums;
using agendamentoTarefas.Models;
using agendamentoTarefas.Service.TarefasService;
using Microsoft.AspNetCore.Mvc;

namespace agendamentoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface  _tarefaInterface;
        public TarefaController(ITarefaInterface tarefaInterface) 
        {
            _tarefaInterface = tarefaInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> CreateTarefa(TarefaModel tarefa)
        {
            return Ok(await _tarefaInterface.CreateTarefa(tarefa));
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> GetTarefas()
        {
            return Ok(await _tarefaInterface.GetTarefas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TarefaModel>>> GetTarefaById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = await _tarefaInterface.GetTarefaById(id);
            return Ok(serviceResponse);
        }

        [HttpGet("ObterPorData")]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> GetTarefaByData(DateTime data)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.GetTarefaByData(data);

            return Ok(serviceResponse);
        }

        [HttpGet("ObterPorStatus")]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> GetTarefaByStatus(StatusTarefaEnum status)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.GetTarefaByStatus(status);
            return Ok(serviceResponse);
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<ActionResult<ServiceResponse<TarefaModel>>> GetTarefaByTitulo(string titulo)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.GetTarefaByTitulo(titulo);
            return Ok(serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> UpdateTarefa(int id, TarefaModel tarefaEditada)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.UpdateTarefa(id, tarefaEditada);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> DeleteTarefa(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.DeleteTarefa(id);
            return Ok(serviceResponse);
        }
    }
}
