using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExamenP2StevenCarrillo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            foreach (var child in radioGroupMontoRecarga.Children)
            {
                if (child is RadioButton rb)
                {
                    rb.CheckedChanged += OnMontoRecargaChanged;
                }
            }
        }

        void OnMontoRecargaChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                RadioButton rb = (RadioButton)sender;
                string montoRecarga = rb.Value.ToString();
                DisplayAlert("Recarga seleccionada", $"Ha seleccionado una recarga de: {montoRecarga} dólares", "OK");
            }
        }

        async void OnRecargaButtonClicked(object sender, EventArgs e)
        {
            string numeroCelular = entryNumeroCelular.Text;
            string operador = pickerOperador.SelectedItem.ToString();
            string montoRecarga = null;
            foreach (var child in radioGroupMontoRecarga.Children)
            {
                if (child is RadioButton rb && rb.IsChecked)
                {
                    montoRecarga = rb.Value.ToString();
                    break;
                }
            }

            string mensaje = $"Se hizo una recarga de {montoRecarga} dólares al número celular {numeroCelular}";
            File.WriteAllText($"{numeroCelular}.txt", mensaje);

            bool respuesta = await DisplayAlert("Confirmación", "¿Desea realizar la recarga?", "Sí", "No");
            if (respuesta)
            {
                await DisplayAlert("Recarga realizada", mensaje, "OK");
            }
        }
    }
}
