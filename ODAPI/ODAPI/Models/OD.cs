using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODAPI.Models
{
    public enum StatusOD
    {
        Pendente    = 1,
        EmAndamento = 2,
        Concluida   = 3,
        Cancelada   = 4
    }

    [Table("OD")]
    public class OD
    {
        [Display(Name = "ID"), Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Cliente ID"), Column("ClienteId")]
        [Required(ErrorMessage = "O campo Cliente ID é obrigatório.")]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Display(Name = "Descrição"), Column("Descricao")]
        [StringLength(500, ErrorMessage = "O campo Descrição deve ter no máximo 500 caracteres.")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string? Descricao { get; set; }

        [Display(Name = "Valor"), Column("Valor")]
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Valor deve ser maior que zero.")]
        public double Valor { get; set; }

        [Display(Name = "Data de Solicitação"), Column("DataSolicitacao")]
        [Required(ErrorMessage = "O campo Data de Solicitação é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo Data de Solicitação deve ser uma data e hora válida.")]
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        [Display(Name = "Data de Conclusão"), Column("DataConclusao")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo Data de Conclusão deve ser uma data e hora válida.")]
        public DateTime? DataConclusao { get; set; }

        [Display(Name = "Status"), Column("Status")]
        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        [EnumDataType(typeof(StatusOD), ErrorMessage = "O campo Status deve ser um valor válido.")]
        public StatusOD Status { get; set; }

        [Display(Name = "Endereço"), Column("Endereco")]
        [StringLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        public string? Endereco { get; set; }
    }
}
