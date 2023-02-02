using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Clases
{
    class Autor : ObservableObject
    {
        private string nombre;
        private string nickname;
        private string image;
        private string imagenRedSocial;
        private ObservableCollection<Articulo> articulos;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }
        public string Nickname
        {
            get { return nickname; }
            set { SetProperty(ref nickname, value); }
        }
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }
        public string ImagenRedSocial
        {
            get { return imagenRedSocial; }
            set { SetProperty(ref imagenRedSocial, value); }
        }
        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
        }

        public Autor()
        {
        }

        public Autor(string nombre, string nickname, string image, string imagenRedSocial, ObservableCollection<Articulo> articulos)
        {
            this.nombre = nombre;
            this.nickname = nickname;
            this.image = image;
            this.imagenRedSocial = imagenRedSocial;
            this.articulos = articulos;
        }

        public Autor(string nombre, string nickname, string image, string imagenRedSocial)
        {
            this.nombre = nombre;
            this.nickname = nickname;
            this.image = image;
            this.imagenRedSocial = imagenRedSocial;
            this.articulos = null;
        }
    }
}
