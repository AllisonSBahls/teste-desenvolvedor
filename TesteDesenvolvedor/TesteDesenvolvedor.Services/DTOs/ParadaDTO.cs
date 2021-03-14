using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class ParadaDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }

    }

}
