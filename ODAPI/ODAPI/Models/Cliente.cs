using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODAPI.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Display(Name = "ID"), Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Nome"), Column("Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [Display(Name = "Email"), Column("Email")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        [StringLength(100, ErrorMessage = "O campo Email deve ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        [Display(Name = "Telefone"), Column("Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Phone(ErrorMessage = "O campo Telefone deve ser um número de telefone válido.")]
        [StringLength(15, ErrorMessage = "O campo Telefone deve ter no máximo 15 caracteres.")]
        public string? Telefone { get; set; }

        [Display(Name = "Endereço"), Column("Endereco")]
        [StringLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
        public string? Endereco { get; set; }

        [Display(Name = "CPF"), Column("CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo CPF deve ter exatamente 11 caracteres.")]
        public string? CPF { get; set; }
    }
}
