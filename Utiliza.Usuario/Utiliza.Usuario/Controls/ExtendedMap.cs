using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace Utiliza.Usuario.Controls
{
    class ExtendedMap : Map
    {
        public ExtendedMap()
        {

        }

        private IList<Pin> _staticPins;
        public IList<Pin> StaticPins
        {
            get { return _staticPins; }
            set
            {
                _staticPins = value;
                foreach (var pin in value)
                {
                    this.Pins.Add(pin);
                }
            }
        }
    }
}
