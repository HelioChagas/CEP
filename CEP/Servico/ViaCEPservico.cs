using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using CEP.Servico.Modelo;
using Newtonsoft.Json;

namespace CEPse.Servico
{
    public class ViaCEPservico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";


        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
