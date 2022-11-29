using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CEP.Servico.Modelo;
using CEP.Servico;
namespace CEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        
        }

        private void BuscarCEP(object sender, EventArgs args)
        {


            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = CEPse.Servico.ViaCEPservico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} {3} {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else 
                    {
                        DisplayAlert("ERRO","O endereço não foi encontrado para o CEP informado:"+CEP,"OK");
                    }

                }
                catch (Exception e) 
                {
                    DisplayAlert("ERRO CRITICO",e.Message,"ok");
                }
            }
            
        }
        private bool isValidCEP(string cep) 
        {

            bool valido = true;

            if (cep.Length != 8) 
            {
                DisplayAlert("ERRO","CEP invalido! o CEP deve conter 8 caracteres","OK");

                valido = false;
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP)) 
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve ser composto apenas por numeros", "OK");

                valido = false;
            }

            return valido;
        }

    }
}
