using System.Collections.Generic;

namespace TesteDesenvolvedor.Domain
{
    public class Linha
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParadaId { get; set; }
        public List<Parada> Paradas { get; set; }
    }
}
