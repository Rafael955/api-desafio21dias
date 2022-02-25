using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{

    [Table("tb_alunos")]
    public partial class Aluno
    {
        #region "Propriedades"
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Column("matricula", TypeName = "varchar")]
        [Required]
        [MaxLength(8)]
        public string Matricula { get; set; }
        
        [Column("notas", TypeName = "text")]
        [Required]
        public string Notas { get; set; }

        #endregion
    }
}