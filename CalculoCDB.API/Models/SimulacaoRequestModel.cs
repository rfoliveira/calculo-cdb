using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.API.Models
{
    public class SimulacaoRequestModel
    {
        [Required]
        public decimal VlInicial { get; set; }

        [Required]
        public short QtdMeses { get; set; }
    }
}