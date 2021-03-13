using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class LinhaDTO
    {   
        public long Id { get; set; }
        public string Name { get; set; }

    }


    public class LinhaParadasDTO
    {   
        public long Id { get; set; }

        public string Name { get; set; }
        public List<VeiculoDTO> Veiculos { get; set; }

    } 

}
