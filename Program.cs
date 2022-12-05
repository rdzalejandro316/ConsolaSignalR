using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ConsolaChat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var signalRConnection = new signalRConnection();
                signalRConnection.Start();
                Console.Read();

            }
            catch (Exception w)
            {
                Console.WriteLine("error:" + w);
            }     
        }


        


    }
}
