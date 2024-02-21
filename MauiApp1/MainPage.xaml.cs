using MauiApp1.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPesquisarClicked(object sender, EventArgs e)
        {
            
            CEP cep = new CEP();
                        
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {                
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://viacep.com.br/ws/" + TxtCEP.Text + "/json")

            };

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {

                cep = JsonConvert.DeserializeObject<CEP>(await response.Content.ReadAsStringAsync());                

                TxtRua.Text = cep.logradouro;
                TxtBairro.Text = cep.bairro;
                TxtCidade.Text = cep.localidade;
                TxtUF.Text = cep.uf;
                
            }
          
        }

        private void OnLimparClicked(object sender, EventArgs e)
        {
            TxtRua.Text = string.Empty;
            TxtBairro.Text = string.Empty;
            TxtCidade.Text = string.Empty;
            TxtUF.Text = string.Empty;
        }

    }

}
