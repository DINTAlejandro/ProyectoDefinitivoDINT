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
    /// Lógica de interacción para NuevaCategoria.xaml
    /// </summary>
    public partial class NuevaCategoria : Window
    {
        private NuevaCategoriaVM vm;
        public NuevaCategoria()
        {
            InitializeComponent();
            vm = new NuevaCategoriaVM();
            this.DataContext = vm;
        }
    }
}
