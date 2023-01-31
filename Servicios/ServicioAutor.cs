using ProyectoDefinitivoDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioAutor
    {
        public ObservableCollection<Articulo> ObtenerArticulosPublicados(ObservableCollection<Articulo> articulos)
        {
            ObservableCollection<Articulo> publicados = new ObservableCollection<Articulo>();
            foreach (Articulo articulo in articulos)
            {
                if (articulo.Publicado)
                {
                    publicados.Add(articulo);
                }
            }
            return publicados;
        }
        public ObservableCollection<Articulo> ObtenerArticulosSinPublicar(ObservableCollection<Articulo> articulos)
        {
            ObservableCollection<Articulo> sinPublicar = new ObservableCollection<Articulo>();
            foreach (Articulo articulo in articulos)
            {
                if (!articulo.Publicado)
                {
                    sinPublicar.Add(articulo);
                }
            }
            return sinPublicar;
        }

        public bool ContieneArticulo(Autor autor, Articulo articulo)
        {
            return autor.Articulos.Contains(articulo);
        }

        public void AddArticulo(Autor autor, Articulo articulo)
        {
            autor.Articulos.Add(articulo);
        }

        public void DeleteArticulo(Autor autor, Articulo articulo)
        {
            autor.Articulos.Remove(articulo);
        }
    }
}
