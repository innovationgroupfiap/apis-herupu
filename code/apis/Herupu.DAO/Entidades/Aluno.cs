using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Herupu.DAO.Entidades
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Nome do aluno obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome do aluno deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome:")]
        [Column("NM_ALUNO")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data Nascimento obrigatória!")]
        [Display(Name = "Data Nascimento:")]
        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Nome do responsável obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome do reponsável deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome Responsável:")]
        [Column("NM_RESPONSAVEL")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "CPF do responsável obrigatório!")]
        [StringLength(14, ErrorMessage = "O CPF do reponsável deve ter no máximo 14 números")]
        [Display(Name = "CPF Responsável:")]
        [Column("CPF_RESPONSAVEL")]
        public string CpfResponsavel { get; set; }


        [Required(ErrorMessage = "Email do responsável obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "O email do reponsável deve ter no máximo 100 caracteres")]
        [Display(Name = "Email Responsável:")]
        [Column("EMAIL_RESPONSAVEL")]
        public string EmailResponsavel { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "O telefone do reponsável deve ter no máximo 11 números")]
        [Display(Name = "Telefone Responsável:")]
        [Column("TEL_RESPONSAVEL")]
        public string? TelefoneResponsavel { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Celular do responsável obrigatório!")]
        [StringLength(11, ErrorMessage = "O email do reponsável deve ter no máximo 11 números")]
        [Display(Name = "Celular Responsável:")]
        [Column("CEL_RESPONSAVEL")]
        public string CelularResponsavel { get; set; }

        [Display(Name = "Código Escola:")]
        [Column("COD_ESCOLA")]
        public decimal? CodigoEscola { get; set; }


        [Display(Name = "Matrícula Aluno:")]
        [Column("NUM_MATRICULA")]
        public decimal? MatriculaAluno { get; set; }


        [JsonIgnore]
        [NotMapped]
        public ICollection<HistoricoAluno>? HistoricoAlunos { get; set; }
    }
}
