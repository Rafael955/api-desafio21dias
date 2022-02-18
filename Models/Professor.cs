using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{

    [Table("tb_professores")]
    public partial class Professor
    {   
        #region propriedades

        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome", TypeName = "varchar")]
        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Nome { get; set; }

        [Required]
        [Column("salario", TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        [NotMapped]
        public virtual List<string> Turmas { get; set; }

        #endregion
    }
}