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
    /// <summary>
    /// Lógica de interacción para ListaArticulosControl.xaml
    /// </summary>
    public partial class ListaArticulosControl : UserControl
    {
        private ListaArticulosControlVM vm;
        public ListaArticulosControl()
        {
            InitializeComponent();
            vm = new ListaArticulosControlVM();
            this.DataContext = vm;
        }
    }
}
