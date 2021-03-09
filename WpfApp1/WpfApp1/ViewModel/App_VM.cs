using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewMoel
{
    using Model;
 
   public class App_VM : INotifyPropertyChanged
    {
        private App_Model model = new App_Model();
        
        public string Value_from_vm
        {
            get { return model.value; }
            set { 
                    model.value = value;
                    onPropertyChanged(nameof(Value_from_vm));
                    Console.WriteLine("ok");
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string name_of_value)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name_of_value));

           
            Console.WriteLine("OK");
        }
    }
}
