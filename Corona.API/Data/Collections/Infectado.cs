using Corona.API.Enums;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace Corona.API.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, EGenero sexo, double latitude, double longitude)
        {
            Id = Guid.NewGuid();
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public Guid Id { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public EGenero Sexo { get; private set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; private set; }
    }
}
