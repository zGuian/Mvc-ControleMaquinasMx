using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebMvc_Utilities.HttpConfiguration
{
    public static class HttpExtensionsConfig
    {
        private readonly static MediaTypeHeaderValue _contentType = new("application/json");

        public static async Task<T> LerJsonAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Algo deu errado! {response.ReasonPhrase}");
            }
            var conteudoJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(conteudoJson);
            if (result == null)
            {
                throw new ApplicationException("Erro");
            }
            return result;
        }

        public static Task<HttpResponseMessage> EscreveJsonAsync<T>(this HttpClient httpClient, string url, T dados)
        {
            var dadosViraString = JsonConvert.SerializeObject(dados);
            var conteudo = new StringContent(dadosViraString);
            conteudo.Headers.ContentType = _contentType;
            return httpClient.PostAsync(url, conteudo);
        }

        public static Task<HttpResponseMessage> AttJsonAsync<T>(this HttpClient httpClient, string url, T dados)
        {
            var dadosViraString = JsonConvert.SerializeObject(dados);
            var conteudo = new StringContent(dadosViraString);
            conteudo.Headers.ContentType = _contentType;
            return httpClient.PutAsync(url, conteudo);
        }
    }
}
