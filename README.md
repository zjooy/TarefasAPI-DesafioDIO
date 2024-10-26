# Desafio .NET - API e Entity Framework

## Contexto
Esta API foi desenvolvida como parte de um desafio proposto pela DIO, utilizando .NET e Entity Framework para a implementação. O projeto segue o padrão de design Repository Pattern, promovendo uma estrutura modular e de fácil manutenção para a comunicação com o banco de dados.

Sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

**Swagger**

![image](https://github.com/user-attachments/assets/6b8a725e-2e55-4de3-b8a7-d281d37c4b6d)

**Endpoints**

| Verbo  | Endpoint                | Parâmetro |
|--------|-------------------------|-----------|
| GET    | /Tarefa/{id}            | id        |
| PUT    | /Tarefa/{id}            | id        |
| DELETE | /Tarefa/{id}            | id        |
| GET    | /Tarefa/ObterTodos      | N/A       |
| GET    | /Tarefa/ObterPorTitulo  | titulo    |
| GET    | /Tarefa/ObterPorData    | data      |
| GET    | /Tarefa/ObterPorStatus  | status    |
| POST   | /Tarefa                 | N/A       |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem
```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2024-10-26T01:31:07.056Z",
  "status": "Finalizado"
}
```


## Tecnologias Utilizadas
.NET 6 -
Entity Framework Core -
Repository Pattern para abstração de acesso a dados
