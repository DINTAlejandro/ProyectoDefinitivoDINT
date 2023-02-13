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
using System.Windows.Shapes;

namespace ProyectoDefinitivoDINT.Ventanas
{
    /// <summary>
    /// Lógica de interacción para NuevoAutorVentana.xaml
    /// </summary>
    public partial class NuevoAutorVentana : Window
    {
        NuevoAutorVM vm;
        public NuevoAutorVentana()
        {
            InitializeComponent();
            vm = new NuevoAutorVM();
            this.DataContext = vm;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
