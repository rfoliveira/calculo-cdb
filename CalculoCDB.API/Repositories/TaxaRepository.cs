namespace CalculoCDB.API.Repositories;

public class TaxaRepository : ITaxaRepository
{
    public int TB => 108;
    public decimal CDI => 0.9m;

    public decimal GetAliquotaIR(short prazo) 
        => prazo switch
        {
            <= 6 => 22.5m,
            >= 6 and <= 12 => 20,
            >= 12 and <= 24 => 17.5m,
            _ => 15m
        };
}
