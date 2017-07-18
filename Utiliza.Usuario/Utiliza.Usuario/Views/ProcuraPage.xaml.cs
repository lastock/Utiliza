using System;
using Utiliza.Usuario.ViewModels;
using Xamarin.Forms;
using Utiliza.Usuario.Model;
using Utiliza.Usuario.Servicos;

namespace Utiliza.Usuario.Views
{
    public partial class ProcuraPage : ContentPage
    {
        public ProcuraPage()
        {
            InitializeComponent();
        }
        void OnGotFocus(object sender, EventArgs e)
        {
            procura.Text = "";
            procura.TextColor = Color.Black;
        }
        void OnSliderValueChange(object sender, EventArgs e)
        {
            valorSlider.Text = $"Raio: {String.Format("{0:N0}", sliderSimples.Value)} Km";
        }
        void OnHabilitaProcuraPorDistanciaChanged(object sender, EventArgs e)
        {
            sliderSimples.IsEnabled = habilitaProcuraPorDistancia.IsToggled;

        }
        private void OnProcuraClicked(object sender, EventArgs e)
        {
            string _categoria = "";
            int selectedIndex = categoria.SelectedIndex;
            if (selectedIndex != -1)
            {
                _categoria = categoria.Items[selectedIndex];
            }
            var categ = new CategoriaService().GetCategoria(_categoria);
            Procura _procura = new Procura();
            _procura.IdCategoria = categ.IdCategoria;
            _procura.StringProcura = procura.Text;
            _procura.Distancia = (int)sliderSimples.Value;
            _procura.ProcuraPorDistancia = habilitaProcuraPorDistancia.IsToggled;
            ((ProcuraPageViewModel)this.BindingContext).ProcuraClickedCommand.Execute(_procura);
        }

    }
}
