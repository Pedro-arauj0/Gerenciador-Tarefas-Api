using System.ComponentModel.DataAnnotations;
using GerenciadorTarefas.Enums;

namespace GerenciadorTarefas.DTOs;

public class TarefaDTO
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres")]
    public string Titulo { get; set; } = string.Empty;
    
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
    public string? Descricao { get; set; }
    
    public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
}