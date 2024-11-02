using System.Collections.Generic;
using System.Linq;

namespace CalculoCDB.API.Repositories
{
    public class TaxaRepository : ITaxaRepository
    {
        public int TB => 108;
        public decimal CDI => 0.9m;

        public decimal GetAliquotaIR(short prazo)
        {
            var aliquotas = new Dictionary<short, decimal>
            {
                {6, 22.5m },
                {12, 20m },
                {24, 17.5m },
            };

            foreach (var key in aliquotas.Keys.OrderBy(k => k))
            {
                if (prazo <= key)
                    return aliquotas[key];   
            }

            return 15m;
        }
    }
}