﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Herupu.DAO.Entidades
{
    public class AtividadeItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAtividadeItem { get; set; }

        [Required(ErrorMessage = "Pergunta obrigatória!")]
        [StringLength(500, ErrorMessage = "A pergunta da atividade deve ter no máximo 500 caracteres")]
        [Display(Name = "Pergunta:")]
        [Column("PERGUNTA_ITEM")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage = "Resposta obrigatória!")]
        [StringLength(500, ErrorMessage = "A Resposta da atividade deve ter no máximo 500 caracteres")]
        [Display(Name = "Resposta:")]
        [Column("RESPOSTA_ITEM")]
        public string Resposta { get; set; }

        [StringLength(500, ErrorMessage = "O detalhe da atividade deve ter no máximo 500 caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Detalhe:")]
        [Column("DETALHE_RESP_ITEM")]
        public string? Detalhe { get; set; }

        public Atividade? Atividade { get; set; }

        [Required(ErrorMessage = "Atividade obrigatória!")]
        [Display(Name = "Atividade:")]
        public int IdAtividade { get; set; }

        [JsonIgnore]
        [NotMapped]
        public ICollection<HistoricoAluno>? HistoricoAlunos { get; set; }
    }
}
