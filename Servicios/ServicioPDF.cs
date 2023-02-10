using ProyectoDefinitivoDINT.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Threading;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioPdf
    {


        public string GenerarPDF(Articulo articulo)
        {
            // Sustituir los campos de ejemplo por los del articulo
            ServicioAzure azure = new ServicioAzure();
            string fotoAutor = azure.DescargarFoto(articulo.Autor.Image);
            string fotoArticulo = azure.DescargarFoto(articulo.Imagen);
            string nombrepdf = articulo.Autor.Nombre + articulo.Titulo + ".pdf";
            var streamautor = new FileStream(fotoAutor, FileMode.Open);
            var streamarticulo = new FileStream(fotoArticulo, FileMode.Open);



            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(50, Unit.Point);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(14));

                    page.Header()
                        .Text(articulo.Titulo)
                        .SemiBold().FontSize(24).FontColor(Colors.Black);

                    page.Content()
                        .PaddingVertical(25, Unit.Point)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Image(streamarticulo);
                            x.Item().Text(articulo.Texto);
                            x.Item().Row(y =>
                            {
                                y.AutoItem().PaddingHorizontal(150);
                                y.AutoItem().Width(1, Unit.Centimetre).Image(streamautor);
                                y.AutoItem().Text(articulo.Autor.Nombre);
                                y.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor(Colors.Grey.Medium);
                                y.AutoItem().Width(1, Unit.Centimetre).Image("Instagram.png");
                                y.AutoItem().Text(articulo.Autor.Nickname);
                            });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text("Articulo.pdf");
                });
            })
            .GeneratePdf(nombrepdf);
            streamarticulo.Close();
            streamautor.Close();
            File.Delete(fotoAutor);
            File.Delete(fotoArticulo);
            return nombrepdf;
        }

    }
}
