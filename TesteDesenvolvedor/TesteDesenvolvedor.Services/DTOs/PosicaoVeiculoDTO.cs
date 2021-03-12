using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class PosicaoVeiculoDTO
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Required (ErrorMessage="O ID do Veiculo é obrigatório")]
        public long VeiculoID { get; set; }
    }
}
