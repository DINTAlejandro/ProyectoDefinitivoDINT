using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioAzure
    {
        public ServicioAzure()
        {
        }

        public string SubirFoto(string foto)
        {
            
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialjuan;AccountKey=YYc+i4phslepOltC/RKHpuC4XljLcoqhd6PGVJQF0zj8hUBtAeItv3hhiJaruws/emXHUlcSF/3T+AStBxtOvg==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
            string nombreContenedorBlobs = "trivial"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure
            string rutaImagen = foto;

            //Obtenemos el cliente del contenedor
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            try
            {
                clienteContenedor.UploadBlob(nombreImagen, streamImagen);
            }
            catch(Azure.RequestFailedException)
            {
                //Capturar excepcion si ya esta guardada en azure
            }
            

            //Una vez subida, obtenemos la URL para referenciarla
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            streamImagen.Close();
            return urlImagen;
        }

        public string SubirPdf(string ruta)
        {
            string rutaazurepdf = SubirFoto(ruta);
            File.Delete(ruta);
            return rutaazurepdf;
        }

        public string DescargarFoto(string urlfoto)
        {
            string archivonombre = Path.GetFileName(new Uri(urlfoto).LocalPath);
            string ruta = "D"+archivonombre;

            using(WebClient cliente = new WebClient())
            {
                cliente.DownloadFile(urlfoto, ruta);
                return ruta;
            }
        }
    }
}
