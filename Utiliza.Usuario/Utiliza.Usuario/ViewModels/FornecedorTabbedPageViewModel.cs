using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Utiliza.Usuario.Eventos;

namespace Utiliza.Usuario.ViewModels
{

    public class FornecedorTabbedPageViewModel : BaseViewModel
    {
        //IEventAggregator _ea { get; }

        public FornecedorTabbedPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService)
        {
            //_ea = eventAggregator;
            Title = "Fornecedor";
        }
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (!parameters.ContainsKey("id")) return;

            var id = Int32.Parse(parameters.GetValue<string>("id"));

            //System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
            //_ea.GetEvent<InitializeTabbedChildrenEvent>().Publish(parameters);
        }

    }
}
