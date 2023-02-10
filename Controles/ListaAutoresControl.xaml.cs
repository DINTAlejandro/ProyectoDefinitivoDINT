using ProyectoDefinitivoDINT.VistasModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoDefinitivoDINT.Controles
{
    public partial class ListaAutoresControl : UserControl
    {
        ListaAutoresControlVM vm;
        public ListaAutoresControl()
        {
            InitializeComponent();
            vm = new ListaAutoresControlVM();
            this.DataContext = vm;
        }
    }
}
