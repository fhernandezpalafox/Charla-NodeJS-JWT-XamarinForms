using System;

using Xamarin.Forms;

namespace appDemoApiRestNodeJS
{
    public class DetalleUsuario : ContentPage
    {
        public DetalleUsuario(Usuario _objUsuario)
        {

            Button boton = new Button {
                Text =  "Salir",
                FontSize = 20,
                Padding= 5,
                BackgroundColor = Color.FromHex("#2196F3"),
                TextColor= Color.White,
                HorizontalOptions= LayoutOptions.Center,
                WidthRequest=150
            };
            boton.Clicked += Boton_ClickedAsync;

            Label label = new Label
            {
                Text = "Detalle",
                FontSize = 25,
                TextColor = Color.White,
                Padding = new Thickness(10, 30, 10, 5),
                HorizontalTextAlignment = TextAlignment.Center
            };

            Frame frame = new Frame
            {
                BackgroundColor = Color.FromHex("#2196F3"),
                Padding = 20,
                CornerRadius = 0,
                Content = label
            };
            
           
            Content = new StackLayout
            {

                Children = {
                    frame,
                    new StackLayout {
                        Padding=30,
                        Children = {
                            new Label { Text = string.Format("{0} {1}",Iconfont.MailAlt,_objUsuario.correo), FontFamily="Fontello", FontSize=25},
                            new Label { Text = string.Format("{0} {1}",Iconfont.User,_objUsuario.nombre), FontFamily="Fontello", FontSize=25},
                        }
                    },
                    boton                   
                }


            };
        }

        private async void Boton_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}

