using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolaChat
{
    public class signalRConnection
    {
        public async void Start()
        {
            //var url = "https://localhost:44300/chatHub";
            var url = "https://signarexampleazure.azurewebsites.net/chatHub";

            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            connection.On<Mensaje>("RecibirMensaje", (message) => OnReceiveMessage(message));

            var t = connection.StartAsync().ContinueWith(async task=>
            {
                if (task.IsFaulted)
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                else 
                { 
                    Console.WriteLine("Connected");

                    //var cancellationTokenSource = new CancellationTokenSource();
                    //var stream = connection.StreamAsync<int>("Counter");

                    //await foreach(var count in stream)
                    //{
                    //    Console.WriteLine($"{count}");
                    //}
                    

                }

            });
            
            t.Wait();
        }

        private void OnReceiveMessage(Mensaje mensaje)
        {
            Console.WriteLine($"{mensaje.usuario}: {mensaje.contenido}");
        }

    }

}
