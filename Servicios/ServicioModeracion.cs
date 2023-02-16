using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDefinitivoDINT.Servicios
{
    class ServicioModeracion
    {
        //Se le manda un texto y devuelve una observable collection de elementos los cuales no estan bien en el texto o no deben estar.
        public IRestResponse PostText(string Texto)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("contentmoderator/moderate/v1.0/ProcessText/Screen", Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", Texto, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        public ObservableCollection<string> ShowBadWords(IRestResponse response)
        {
            ObservableCollection<string> BadWords = new ObservableCollection<string>();
            RootCheck answer = JsonConvert.DeserializeObject<RootCheck>(response.Content);
            foreach (Termino t in answer.Terms)
            {
                BadWords.Add(t.Term);
            }
            return BadWords;
        }

        //Elementos y métodos que van en relación a los terminos de las listas
        public void AddTerm(string palabra)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("/contentmoderator/lists/v1.0/termlists/{idlist}/terms/{term}", Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", "2150");
            request.AddUrlSegment("term", palabra);
            request.AddParameter("language", "spa", ParameterType.QueryString);
            var response = client.Execute(request);
        }

        public void DeleteTerm(string palabra)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("/contentmoderator/lists/v1.0/termlists/{idlist}/terms/{term}", Method.DELETE);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", "2150");
            request.AddUrlSegment("term", palabra);
            request.AddParameter("language", "spa", ParameterType.QueryString);
            var response = client.Execute(request);
        }

        public void DeleteAllTerm(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("/contentmoderator/lists/v1.0/termlists/{idlist}/terms", Method.DELETE);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", "2150");
            request.AddParameter("language", "spa", ParameterType.QueryString);
            var response = client.Execute(request);
        }

        public IRestResponse ShowTerms(int IdList)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("/contentmoderator/lists/v1.0/termlists/{idlist}/terms", Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", IdList);
            request.AddParameter("language", "spa", ParameterType.QueryString);
            var response = client.Execute(request);
            return response;
        }

        public ObservableCollection<string> ShowAllTerms(IRestResponse response)
        {
            ObservableCollection<string> TermWords = new ObservableCollection<string>();
            RootShow answer = JsonConvert.DeserializeObject<RootShow>(response.Content);
            foreach (Terminos t in answer.Data.Terms)
            {
                TermWords.Add(t.Term);
            }
            return TermWords;
        }

        //Elementos relazionados con listas
        public void CreateList(string nameList, string descList)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("contentmoderator/lists/v1.0/termlists", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddJsonBody("{'Name': '" + nameList + "', 'Description': '" + descList + "'}");
            var response = client.Execute(request);
        }

        public void DeleteList(int IdList)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("contentmoderator/lists/v1.0/termlists/{idlist}", Method.DELETE);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", IdList);
            var response = client.Execute(request);
        }

        public IRestResponse AllList()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("contentmoderator/lists/v1.0/termlists", Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            var response = client.Execute(request);
            return response;
        }

        public ObservableCollection<IdentificadorListas> ShowAllList(IRestResponse response)
        {
            ObservableCollection<IdentificadorListas> ListIdent = new ObservableCollection<IdentificadorListas>();
            List<RootLists> answer = JsonConvert.DeserializeObject<List<RootLists>>(response.Content);
            IdentificadorListas referenceList = new IdentificadorListas();
            foreach (RootLists headList in answer)
            {
                referenceList.idList = headList.Id;
                referenceList.nameList = headList.Name;
                ListIdent.Add(referenceList);
            }
            return ListIdent;
        }

        //ESTE METODO SE TIENE QUE REALIZAR SIEMPRE QUE TENGA ALGO RELACIÓN A AÑADIR O ELIMINAR TERMINOS DE UNA LISTA, CON QUE SE PONDRA ESTE METODO SEGUIDO A LOS OTROS
        public void RefreshIndex(int IdList)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("contentmoderator/lists/v1.0/termlists/{idlist}/RefreshIndex", Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", "c32542144bf94f80a24f1ccd404af7df");
            request.AddUrlSegment("idlist", IdList);
            request.AddParameter("language", "spa", ParameterType.QueryString);
            var response = client.Execute(request);
        }

        //Clases para deserializar elementos de un texto moderado
        public class RootCheck
        {
            public string OriginalText { get; set; }
            public string NormalizedText { get; set; }
            public object Misrepresentation { get; set; }
            public string Language { get; set; }
            public List<Termino> Terms { get; set; }
            public Status Status { get; set; }
            public string TrackingId { get; set; }
        }

        public class Status
        {
            public int Code { get; set; }
            public string Description { get; set; }
            public object Exception { get; set; }
        }

        public class Termino
        {
            public int Index { get; set; }
            public int OriginalIndex { get; set; }
            public int ListId { get; set; }
            public string Term { get; set; }
        }

        //A partir de aqui son las clases para deserializar el mostrar los terminos
        public class Data
        {
            public string Language { get; set; }
            public List<Terminos> Terms { get; set; }
            public Status Status { get; set; }
            public string TrackingId { get; set; }
        }

        public class Paging
        {
            public int Total { get; set; }
            public int Limit { get; set; }
            public int Offset { get; set; }
            public int Returned { get; set; }
        }

        public class RootShow
        {
            public Data Data { get; set; }
            public Paging Paging { get; set; }
        }

        public class Terminos
        {
            public string Term { get; set; }
        }

        //Clases relacionadas con las listas
        public class IdentificadorListas
        {
            public int idList { get; set; }
            public string nameList { get; set; }
        }

        public class Metadata
        {
        }

        public class RootLists
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Metadata Metadata { get; set; }
        }
    }
}
