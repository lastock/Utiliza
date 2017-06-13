using System;

namespace Utiliza.Usuario.Model
{
    public class Rotator
    {
        public Rotator(string imageString)
        {
            Image = imageString;
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
