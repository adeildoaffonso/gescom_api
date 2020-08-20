using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GESCOM_API.Models
{

    public partial class recibo_comissao_detalhe_tb
    {
        [Key]
        public int recibo_comissao_detalhe_id { get; set; }

        public int recibo_comissao_id { get; set; }

        public int corretor_id { get; set; }

        public DateTime data_pagamento { get; set; }

        public decimal valor_pagamento { get; set; }

        public decimal percentual_comissao { get; set; }

        public int? status_pagamento { get; set; }

        public virtual corretor_tb corretor_tb { get; set; }

        public virtual corretor_tb corretor_tb1 { get; set; }

        public virtual recibo_comissao_tb recibo_comissao_tb { get; set; }

        public virtual recibo_comissao_tb recibo_comissao_tb1 { get; set; }
    }
}
