using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvedor.Domain
{
    public class Linha
    {   
        [Required]
        public long Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }
        public List<LinhaParada> LinhasParadas { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
