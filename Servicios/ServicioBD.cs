using Microsoft.Data.Sqlite;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoDefinitivoDINT
{
    class ServicioBD
    {
        public ServicioBD()
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");

            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"CREATE TABLE IF NOT EXISTS Autores 
                                    (id integer primary key AUTOINCREMENT, nombre varchar(20), nickname varchar(20) DEFAULT NULL, 
                                     imagen varchar(20) DEFAULT NULL, imagenRed varchar(20) DEFAULT NULL)";

            comando.ExecuteNonQuery();

            comando.CommandText = @"CREATE TABLE IF NOT EXISTS Articulos 
                                    (id integer primary key AUTOINCREMENT, titulo varchar(20), imagen varchar(100) DEFAULT NULL, 
                                     texto varchar(200) DEFAULT NULL, seccion varchar(20) DEFAULT NULL,
                                     autorId integer DEFAULT NULL, publicado BIT DEFAULT NULL, 
                                     FOREIGN KEY (autorId) REFERENCES Autores(id), FOREIGN KEY (seccion) REFERENCES Secciones(name))";

            comando.ExecuteNonQuery();

            comando.CommandText = @"CREATE TABLE IF NOT EXISTS Secciones 
                                    (name varchar(20) primary key)";

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public List<Autor> GetAutors()
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT * FROM Autores";
            SqliteDataReader lector = comando.ExecuteReader();

            List<Autor> AllAutor = new List<Autor>();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Autor aut = new Autor();
                    aut.Id = lector.GetInt32(0);
                    aut.Nombre = lector.GetString(1);
                    aut.Nickname = lector.GetString(2);
                    aut.Image = lector.GetString(3);
                    aut.ImagenRedSocial = lector.GetString(4);
                    AllAutor.Add(aut);
                }
            }

            lector.Close();
            conexion.Close();

            return AllAutor;
        }

        public List<Articulo> GetArticulos()
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT * FROM Articulos";
            SqliteDataReader lector = comando.ExecuteReader();

            List<Articulo> AllArticles = new List<Articulo>();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = lector.GetInt32(0);
                    art.Titulo = lector.GetString(1);
                    art.Imagen = lector.GetString(2);
                    art.Texto = lector.GetString(3);
                    art.Seccion = lector.GetString(4);
                    art.Autor = GetAutorById(lector.GetInt32(5));
                    art.Publicado = lector.GetBoolean(6);
                    AllArticles.Add(art);
                }
            }

            lector.Close();
            conexion.Close();

            return AllArticles;
        }

        public List<string> GetSecciones()
        {

            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT * FROM Secciones";
            SqliteDataReader lector = comando.ExecuteReader();

            List<string> AllSeccion = new List<string>();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    AllSeccion.Add(lector.GetString(0));
                }
            }

            lector.Close();
            conexion.Close();

            return AllSeccion;
        }

        public Autor GetAutorById(int id)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT * FROM Autores WHERE id = @id";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@id"].Value = id;
            SqliteDataReader lector = comando.ExecuteReader();

            Autor TheAutor = new Autor();

            if (lector.HasRows)
            {
                lector.Read();
                TheAutor.Id = lector.GetInt32(0);
                TheAutor.Nombre = lector.GetString(1);
                TheAutor.Nickname = lector.GetString(2);
                TheAutor.Image = lector.GetString(3);
                TheAutor.ImagenRedSocial = lector.GetString(4);
            }

            lector.Close();
            conexion.Close();

            return TheAutor;
        }

        public Articulo GetArticuloById(int id)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT * FROM Articulos WHERE id = @id";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@id"].Value = id;
            SqliteDataReader lector = comando.ExecuteReader();

            Articulo TheArticle = new Articulo();

            if (lector.HasRows)
            {
                lector.Read();
                TheArticle.Id = lector.GetInt32(0);
                TheArticle.Titulo = lector.GetString(1);
                TheArticle.Imagen = lector.GetString(2);
                TheArticle.Texto = lector.GetString(3);
                TheArticle.Seccion = lector.GetString(4);
                TheArticle.Autor = GetAutorById(lector.GetInt32(5));
                TheArticle.Publicado = lector.GetBoolean(6);
            }

            lector.Close();
            conexion.Close();

            return TheArticle;
        }

        public void InsertAutor(Autor aut)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO Autores (nombre,nickname,imagen,imagenRed) VALUES (@nombre,@nickname,@imagen,@imagenRed)";
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@nickname", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@imagenRed", SqliteType.Text);
            comando.Parameters["@nombre"].Value = aut.Nombre;
            comando.Parameters["@nickname"].Value = aut.Nickname;
            comando.Parameters["@imagen"].Value = aut.Image;
            comando.Parameters["@imagenRed"].Value = aut.ImagenRedSocial;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void InsertArticles(Articulo art)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO Articulos (titulo,imagen,texto,seccion,autorId,publicado) VALUES (@titulo,@imagen,@texto,@seccion,@autor,@publicado)";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@texto", SqliteType.Text);
            comando.Parameters.Add("@seccion", SqliteType.Text);
            comando.Parameters.Add("@autor", SqliteType.Integer);
            comando.Parameters.Add("@publicado", SqliteType.Integer);
            comando.Parameters["@titulo"].Value = art.Titulo;
            comando.Parameters["@imagen"].Value = art.Imagen;
            comando.Parameters["@texto"].Value = art.Texto;
            comando.Parameters["@seccion"].Value = art.Seccion;
            comando.Parameters["@autor"].Value = art.Autor.Id;
            comando.Parameters["@publicado"].Value = art.Publicado;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void InsertSecciones(string SeccionName)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO Secciones VALUES (@name)";
            comando.Parameters.Add("@name", SqliteType.Text);
            comando.Parameters["@name"].Value = SeccionName;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void DeleteAutor(Autor aut)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM Autores WHERE id = @Id";
            comando.Parameters.Add("@Id", SqliteType.Integer);
            comando.Parameters["@Id"].Value = aut.Id;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void DeleteArticulo(Articulo art)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM Articulos WHERE id = @Id";
            comando.Parameters.Add("@Id", SqliteType.Integer);
            comando.Parameters["@Id"].Value = art.Id;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void UpdateAutor(Autor aut)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=RevistaAutores.db");
            conexion.Open();
            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "UPDATE autores SET nombre = @name, nickname = @nickname, imagen = @imagen, imagenRed = @imagenRed WHERE id = @Id";
            comando.Parameters.Add("@Id", SqliteType.Integer);
            comando.Parameters.Add("@name", SqliteType.Text);
            comando.Parameters.Add("@nickname", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@imagenRed", SqliteType.Text);
            comando.Parameters["@Id"].Value = aut.Id;
            comando.Parameters["@name"].Value = aut.Nombre;
            comando.Parameters["@nickname"].Value = aut.Nickname;
            comando.Parameters["@imagen"].Value = aut.Image;
            comando.Parameters["@imagenRed"].Value = aut.ImagenRedSocial;

            int filas_afectadas = comando.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
