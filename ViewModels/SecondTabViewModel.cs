using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui7.ViewModels
{
    public class SecondTabViewModel : ViewModelBase
    {
        public ObservableCollection<string> Items { get; } = new();
       
        public Command AddItemCommand
            => new Command(async () => await AddItem());

        private async Task AddItem()
        {
            Items.Add("Test");
           await Task.CompletedTask;
        }

        public SecondTabViewModel()
        {
            
        }
       
    }
}
