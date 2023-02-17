using ProyectoDefinitivoDINT.Clases;
using ProyectoDefinitivoDINT.Servicios;
using ProyectoDefinitivoDINT.VistasModelo;
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
        private MainWindowVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
            /*ServicioAzure azure = new ServicioAzure();
            ServicioPdf pdf = new ServicioPdf();
            ServicioHtml html = new ServicioHtml();

            Autor autor1 = new Autor("Juan Pérez", "jperez", "avatar2.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor2 = new Autor("María Rodríguez", "mrodriguez", "avatar2.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor3 = new Autor("Pedro González", "pgonzalez", "avatar3.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor4 = new Autor("Ana López", "alopez", "image4.jpg", "avatar4.jpg", new ObservableCollection<Articulo>());
            Autor autor5 = new Autor("Luis Fernández", "lfernandez", "avatar5.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor6 = new Autor("José García", "jgarcia", "avatar6.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor7 = new Autor("Daniela Sánchez", "dsanchez", "avatar7.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor8 = new Autor("Carlos Martínez", "cmartinez", "avatar8.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor9 = new Autor("Isabel Díaz", "idiaz", "avatar9.jpg", "Instagram.png", new ObservableCollection<Articulo>());
            Autor autor10 = new Autor("Francisco Ruiz", "fruiz", "avatar10.jpg", "Instagram.png", new ObservableCollection<Articulo>());

            autor1.Image = azure.SubirFoto(autor1.Image);
            autor2.Image =  azure.SubirFoto(autor2.Image);
            autor3.Image =  azure.SubirFoto(autor3.Image);
            autor4.Image =  azure.SubirFoto(autor4.Image);
            autor5.Image =  azure.SubirFoto(autor5.Image);
            autor6.Image =  azure.SubirFoto(autor6.Image);
            autor7.Image =  azure.SubirFoto(autor7.Image);
            autor8.Image =  azure.SubirFoto(autor8.Image);
            autor9.Image =  azure.SubirFoto(autor9.Image);
            autor10.Image =  azure.SubirFoto(autor10.Image);

            ObservableCollection<Articulo> articulos = new ObservableCollection<Articulo>()
            {
                new Articulo("Artículo 1", "image1.jpg", "Texto del artículo 1", "Sección A", autor1, false, ""),
                new Articulo("Artículo 2", "image2.jpg", "Texto del artículo 2", "Sección B", autor1, false, ""),
                new Articulo("Artículo 3", "image3.jpg", "Texto del artículo 3", "Sección A", autor1, false, ""),
                new Articulo("Artículo 4", "image4.jpg", "Texto del artículo 4", "Sección B", autor1, false, ""),
                new Articulo("Artículo 5", "image5.jpg", "Texto del artículo 5", "Sección C", autor1, false, ""),
                new Articulo("Artículo 6", "image6.jpg", "Texto del artículo 6", "Sección C", autor1, false, ""),
                new Articulo("Artículo 7", "image7.jpg", "Texto del artículo 7", "Sección A", autor1, false, ""),
                new Articulo("Artículo 8", "image8.jpg", "Texto del artículo 8", "Sección B", autor1, false, ""),
                new Articulo("Artículo 9", "image9.jpg", "Texto del artículo 9", "Sección A", autor1, false, ""),
                new Articulo("Artículo 10", "image10.jpg", "Texto del artículo 10", "Sección B", autor1, false, ""),
            };

            foreach (Articulo art in articulos)
            {
                art.Imagen =  azure.SubirFoto(art.Imagen);
            }

            foreach (Articulo art in articulos)
            {
                art.Pdf = pdf.GenerarPDF(art);
                art.Pdf = azure.SubirPdf(art.Pdf);
            }
            html.GenerarHTML(articulos);*/


        }
    }
}
