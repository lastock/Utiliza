using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    public class Localizacao
    {
        public int IdFornecedor { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Localizacao(int idFornecedor, double lat, double lng)
        {
            IdFornecedor = idFornecedor;
            Latitude = lat;
            Longitude = lng;
        }
    }
}
