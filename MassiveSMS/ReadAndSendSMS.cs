using System;
using Android.App;
using Android.OS;
using Android.Telephony;
using Android.Widget;
using com.devlab.massiveSMS.Resources;

namespace com.devlab.massiveSMS
{
    [Activity(Label = "ReadAndSendSMS")]
    public class ReadAndSendSMS : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SendSMS);

            var file = Intent.GetStringExtra("SelectedFile") ?? "Data not available";
            if (file != "NC")
            {
                var text = System.IO.File.ReadAllText(file);
                string[] lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);

                // Get a reference to the TextView
                var resultado = FindViewById<TextView>(Resource.Id.resultados);
                var resultadoForma = FindViewById<TextView>(Resource.Id.resultadosForma);
                var mensaje = FindViewById<EditText>(Resource.Id.txtMensaje);
                var enviar = FindViewById<Button>(Resource.Id.btnEnviar);
                var estado = FindViewById<TextView>(Resource.Id.txtEstado);

                enviar.Click += (s, e) =>
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var items = lines[i].Replace(System.Environment.NewLine, "").Split(',');
                        var phone = items[items.Length - 1].Replace("\r","");
                        var msg = string.Format(mensaje.Text, items);
                        SmsManager.Default.SendTextMessage(phone, null, msg, null, null);
                        estado.Text = $" Enviando mensaje {i} de {lines.Length} ";
                    }

                    Toast.MakeText(this, "Mensajes enviados", ToastLength.Short).Show();

                    estado.Text = $" {lines.Length}  Mensajes Enviados";
                };

                resultado.Text = "Archivo Cargado Correctamente.";
                estado.Text = " Preparado para enviar mensajes a " + lines.Length + " contactos";

                resultadoForma.Text = lines[0];
            }

        }
    }
}