using MicroRabbit.UI.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.UI.Services
{
    public class TransferServicecs : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferServicecs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDTO transferDTO)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var uri = "https://localhost:5001/Banking";
                    var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),
                                                                Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, transferContent);
                    response.EnsureSuccessStatusCode();
                }
            }

           
        }
    }
}
