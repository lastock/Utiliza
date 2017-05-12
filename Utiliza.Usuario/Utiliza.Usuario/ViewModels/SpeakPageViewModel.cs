using Prism.Commands;
using Prism.Mvvm;


namespace Utiliza.Usuario.ViewModels
{
    public class SpeakPageViewModel : BindableBase
    {
        private string _textToSay = "Hello Prism";
        public string TextToSay
        {
            get { return _textToSay; }
            set { SetProperty(ref _textToSay, value); }
        }

        public DelegateCommand SpeakCommand { get; set; }

        public SpeakPageViewModel()
        {
            SpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            //TODO: call service
        }
    }
}