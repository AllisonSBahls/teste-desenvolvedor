using System.Collections.Generic;

namespace TesteDesenvolvedor.Domain
{
    public class Linha
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<LinhaParada> LinhasParadas { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
