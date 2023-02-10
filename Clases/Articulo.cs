using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Clases
{
    class Articulo : ObservableObject
    {
        private string titulo;
        private int id;
        private string imagen;
        private string texto;
        private string seccion;
        private Autor autor;
        private bool publicado;
        private string pdf;

        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }
        public string Pdf
        {
            get { return pdf; }
            set { SetProperty(ref pdf, value); }
        }
        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }
        public string Seccion
        {
            get { return seccion; }
            set { SetProperty(ref seccion, value); }
        }

        public Autor Autor
        {
            get { return autor; }
            set { SetProperty(ref autor, value); }
        }

        public bool Publicado
        {
            get { return publicado; }
            set { SetProperty(ref publicado, value); }
        }
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public Articulo()
        {
        }

        public Articulo(string titulo, string imagen, string texto, string seccion, Autor autor, bool publicado, string pdf)
        {
            this.titulo = titulo;
            this.imagen = imagen;
            this.texto = texto;
            this.seccion = seccion;
            this.autor = autor;
            this.publicado = publicado;
            this.pdf = pdf;
        }
    }
}
