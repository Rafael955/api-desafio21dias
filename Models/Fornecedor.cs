using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
     [Table("f_cli_for")]
    public partial class Fornecedor
    {   
        #region propriedades

        [Key]
        [Column("cod_cfo")]
        public int Id { get; set; }
        
        [Column("nome_fantasia")]
        [Required]
        public string Nome { get; set; }
        
        [Column("razao")]
        [Required]
        public string Razao { get; set; }

        [Column("cpf_cnpj")]
        [Required]
        public string Cpf_Cnpj { get; set; }

        [NotMapped]
        public string CPF { get { return this.Cpf_Cnpj; } set { this.Cpf_Cnpj = value; } }

        [NotMapped]
        public string CNPJ { get { return this.Cpf_Cnpj; } set { this.Cpf_Cnpj = value; } }

        [Column("endereco")]
        [Required]
        public string Endereco { get; set; }

        #endregion
    }
}