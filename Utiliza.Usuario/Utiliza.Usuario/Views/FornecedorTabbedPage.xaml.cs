using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace Utiliza.Usuario.Views
{
    public partial class FornecedorTabbedPage : TabbedPage, INavigatingAware
    {
        public FornecedorTabbedPage()
        {
            InitializeComponent();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            foreach (var child in Children)
            {
                (child as INavigatingAware)?.OnNavigatingTo(parameters);
                (child?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);
            }
        }
    }
}
