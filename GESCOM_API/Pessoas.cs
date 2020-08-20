namespace GESCOM_API
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pessoas
    {
        [Key]
        public int PessoaID { get; set; }

        public string Nome { get; set; }

        public string cpf_cnpj { get; set; }

        public int Tipo_Pessoa { get; set; }
    }
}
