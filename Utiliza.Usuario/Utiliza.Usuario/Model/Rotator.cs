using System;

namespace Utiliza.Usuario.Model
{
    public class Rotator
    {
        public Rotator(string imageString)
        {
            Image = imageString;
        }
        private String _image;
        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
