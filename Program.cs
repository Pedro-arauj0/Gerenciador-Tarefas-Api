using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using GerenciadorTarefas.DTOs;
using GerenciadorTarefas.Enums;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tarefas.db"));

// Adicionar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Criar banco de dados automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// ====== ENDPOINTS ======

// GET: Página inicial
app.MapGet("/", () => "🚀 API Gerenciador de Tarefas - Desafio DIO .NET")
    .WithTags("Home");

// GET: Buscar todas as tarefas
app.MapGet("/tarefas", async (AppDbContext db) =>
{
    var tarefas = await db.Tarefas.ToListAsync();
    return Results.Ok(tarefas);
})
.WithName("ObterTodasTarefas")
.WithTags("Tarefas")
.Produces<List<Tarefa>>(200);

// GET: Buscar tarefa por ID
app.MapGet("/tarefas/{id}", async (int id, AppDbContext db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);
    
    if (tarefa == null)
        return Results.NotFound(new { Mensagem = $"Tarefa com ID {id} não encontrada" });
    
    return Results.Ok(tarefa);
})
.WithName("ObterTarefaPorId")
.WithTags("Tarefas")
.Produces<Tarefa>(200)
.Produces(404);

// GET: Buscar tarefas por status
app.MapGet("/tarefas/status/{status}", async (StatusTarefa status, AppDbContext db) =>
{
    var tarefas = await db.Tarefas
        .Where(t => t.Status == status)
        .ToListAsync();
    
    return Results.Ok(tarefas);
})
.WithName("ObterTarefasPorStatus")
.WithTags("Tarefas")
.Produces<List<Tarefa>>(200);

// POST: Criar nova tarefa
app.MapPost("/tarefas", async (TarefaDTO tarefaDto, AppDbContext db) =>
{
    var tarefa = new Tarefa
    {
        Titulo = tarefaDto.Titulo,
        Descricao = tarefaDto.Descricao,
        Status = tarefaDto.Status,
        DataCriacao = DateTime.Now
    };
    
    db.Tarefas.Add(tarefa);
    await db.SaveChangesAsync();
    
    return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
})
.WithName("CriarTarefa")
.WithTags("Tarefas")
.Produces<Tarefa>(201)
.Produces(400);

// PUT: Atualizar tarefa completa
app.MapPut("/tarefas/{id}", async (int id, TarefaDTO tarefaDto, AppDbContext db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);
    
    if (tarefa == null)
        return Results.NotFound(new { Mensagem = $"Tarefa com ID {id} não encontrada" });
    
    tarefa.Titulo = tarefaDto.Titulo;
    tarefa.Descricao = tarefaDto.Descricao;
    tarefa.Status = tarefaDto.Status;
    
    // Se marcou como concluída, registra a data
    if (tarefaDto.Status == StatusTarefa.Concluida && tarefa.DataConclusao == null)
        tarefa.DataConclusao = DateTime.Now;
    
    await db.SaveChangesAsync();
    
    return Results.Ok(tarefa);
})
.WithName("AtualizarTarefa")
.WithTags("Tarefas")
.Produces<Tarefa>(200)
.Produces(404);

// PATCH: Atualizar apenas o status
app.MapPatch("/tarefas/{id}/status", async (int id, StatusTarefa novoStatus, AppDbContext db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);
    
    if (tarefa == null)
        return Results.NotFound(new { Mensagem = $"Tarefa com ID {id} não encontrada" });
    
    tarefa.Status = novoStatus;
    
    if (novoStatus == StatusTarefa.Concluida && tarefa.DataConclusao == null)
        tarefa.DataConclusao = DateTime.Now;
    
    await db.SaveChangesAsync();
    
    return Results.Ok(tarefa);
})
.WithName("AtualizarStatusTarefa")
.WithTags("Tarefas")
.Produces<Tarefa>(200)
.Produces(404);

// DELETE: Remover tarefa
app.MapDelete("/tarefas/{id}", async (int id, AppDbContext db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);
    
    if (tarefa == null)
        return Results.NotFound(new { Mensagem = $"Tarefa com ID {id} não encontrada" });
    
    db.Tarefas.Remove(tarefa);
    await db.SaveChangesAsync();
    
    return Results.NoContent();
})
.WithName("DeletarTarefa")
.WithTags("Tarefas")
.Produces(204)
.Produces(404);

app.Run();