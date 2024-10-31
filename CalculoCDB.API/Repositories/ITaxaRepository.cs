namespace CalculoCDB.API.Repositories;

public interface ITaxaRepository
{
    int TB { get; }
    decimal CDI { get; }

    decimal GetAliquotaIR(short prazo);
}
