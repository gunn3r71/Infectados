using Corona.API.Enums;
using System;

namespace Corona.API.Models
{
    public class InfectadoDTO
    {
        public DateTime DataNascimento { get; set; }
        public EGenero Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
