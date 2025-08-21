using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODAPI.Models
{
    [Table("Tecnico")]
    public class Tecnico
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

        [Display(Name = "Área de Atuação"), Column("AreaDeAtuacao")]
        [Required(ErrorMessage = "O campo Área de Atuação é obrigatório.")]
        public string? AreaAtuacao { get; set; }
    }
}
