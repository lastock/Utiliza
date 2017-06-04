using System;
using System.Diagnostics;
using Prism.Services;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class MainPage : ContentPage
    {
        private IPageDialogService _dialogService;

        public MainPage(IPageDialogService dialogService)
        {
            InitializeComponent();
            _dialogService = dialogService;

            rotator.SelectedIndexChanged += (object sender, Syncfusion.SfRotator.XForms.SelectedIndexChangedEventArgs e) =>
            {
                isHandled = false;
            };


        }

        bool isHandled = true;
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (isHandled)
            {
                Image imagem = (Image)sender;
                var source = (FileImageSource)imagem.Source;
                string fileName = source.File;
                int id = fileName.IndexOf("_", StringComparison.Ordinal)+1;
                string sid = fileName.Substring(id, fileName.Length - id - 4);

                //_dialogService.DisplayAlertAsync("Id da Empresa", sid, "OK");

                ((MainPageViewModel)this.BindingContext).ImageTappedCommand.Execute(sid);

                //Debug.WriteLine($"Tapped Event Called Sender = {sender.ToString()}");
                //Debug.WriteLine(e.ToString());
            }
            else
            {
                isHandled = true;
            }
        }


    }
}
