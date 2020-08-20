using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class dados_bancarios_tb
    {
        [Key]
        public int dados_bancarios_id { get; set; }

        public long? codigo_banco { get; set; }

        public long? codigo_agencia { get; set; }

        public long? conta_corrente { get; set; }

        public int pessoa_id { get; set; }

        public virtual pessoa_tb pessoa_tb { get; set; }
    }
}
