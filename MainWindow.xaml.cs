using ProyectoDefinitivoDINT.Clases;
using ProyectoDefinitivoDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProyectoDefinitivoDINT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
            ObservableCollection<Articulo> articulos = new ObservableCollection<Articulo>();
            Autor autor = new Autor("Juan","_juanMateo","autor1.jpg","",articulos);
            Articulo articulo = new Articulo("Prueba", "prueba2bin.jpg", "Texto prueba", "Seccion 3", autor, false);
            ServicioPdf pdf = new ServicioPdf();
            pdf.GenerarPDF(articulo);
        }
    }
}
