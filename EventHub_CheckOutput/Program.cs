using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus.Messaging;
using System.Threading.Tasks;

namespace EventHub_CheckOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = "Endpoint=sb://tolldata9373470623.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=AOZ9dEfH6ItUqN7M1EvGj7zzMaGVCIYGTNLwQUfafxU=";
            string eventHubName = "entry";


            string storageAccountName = "tolldata9373470623";
            string storageAccountKey = "TQ+MGAvDvvXKjWOuat6ABQNc7XP8W1BQpe/gYO1ninnJhoSdTm+zCtyJ5k/aIdyMqEstcUqH91yNcRXVuj2tUw==";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccountName, storageAccountKey);
            
             
            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>().Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
        }
    }
}
