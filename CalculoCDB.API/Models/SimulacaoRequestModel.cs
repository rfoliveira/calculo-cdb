using CalculoCDB.API.Validators;
using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.API.Models
{
    public class SimulacaoRequestModel
    {
        [Required]
        [GreaterThan(0)]
        public decimal VlInicial { get; set; }

        [Required]
        [GreaterThan(1)]
        public short QtdMeses { get; set; }
    }
}