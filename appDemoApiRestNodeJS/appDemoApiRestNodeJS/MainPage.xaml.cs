using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace appDemoApiRestNodeJS
{
    public partial class MainPage : ContentPage
    {
        private const string url = "https://appxamarinnodejs.herokuapp.com/usuarios";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Usuario> _usuarios;

        public MainPage()
        {
            InitializeComponent();

            MiLista.Scrolled += OnListViewScrolled;
        }

        private void OnListViewScrolled(object sender, ScrolledEventArgs e)
        {
            _ = consultaApiRestAsync();
        }

        protected override  void OnAppearing()
        {
            _ = consultaApiRestAsync();

            base.OnAppearing();
        }

        private async Task consultaApiRestAsync() {

            string contenido = await client.GetStringAsync(url);
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(contenido);

            _usuarios = new ObservableCollection<Usuario>(usuarios);

            MiLista.EndRefresh();

            MiLista.ItemsSource = _usuarios;
        }

        void MiLista_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var entidadSeleccionada = e.Item as Usuario;
            //Console.WriteLine(entidadSeleccionada.nombre);
            //itemLista(entidadSeleccionada);
            //NavigationPage(new DetalleUsuario());

            Navigation.PushModalAsync(new DetalleUsuario(entidadSeleccionada));
            //Navigation.PushAsync(new  NavigationPage(new DetalleUsuario(entidadSeleccionada)));
        }
    }
}
