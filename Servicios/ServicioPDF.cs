using ProyectoDefinitivoDINT.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioPdf
    {


        public void GenerarPDF(Articulo articulo)
        {
            // Sustituir los campos de ejemplo por los del articulo

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

                            x.Item().Image(articulo.Imagen);
                            x.Item().Text(articulo.Texto);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(articulo.Autor.Nombre);
                });
            })
            .GeneratePdf("output.pdf");
        }

    }
}
