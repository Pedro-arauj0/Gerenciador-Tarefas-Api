using System.ComponentModel.DataAnnotations;
using GerenciadorTarefas.Enums;

namespace GerenciadorTarefas.Models;

public class Tarefa
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
    public string Titulo { get; set; } = string.Empty;
    
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
    public string? Descricao { get; set; }
    
    [Required]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    public DateTime? DataConclusao { get; set; }
    
    [Required]
    public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
}