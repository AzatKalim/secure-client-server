using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SecureClient
{
    class Client
    {
        const String ADRESS = "net.tcp://localhost:5050/IContract";

        // Указание контракта.
        //const Type CONTRACT = typeof(IContract);        // CONTRACT.   (C)    

        Uri address;

        EndpointAddress endpoint;

        BasicHttpBinding binding;

        ChannelFactory<IContract> factory;

        IContract channel;

        public Client()
        {
            // Указание, где ожидать входящие сообщения.
            address = new Uri(ADRESS);  // ADDRESS.   (A)

            // Указание, как обмениваться сообщениями.
            binding = new BasicHttpBinding();         // BINDING.   (B)

            // Создание Конечной Точки.
            endpoint = new EndpointAddress(address);

            // Создание фабрики каналов.
            factory = new ChannelFactory<IContract>(binding, endpoint);  // CONTRACT.  (C) 

            // Использование factory для создания канала (прокси).
            channel = factory.CreateChannel();

            // Использование канала для отправки сообщения получателю.
            channel.Say("Hello WCF!");
        }
        public bool SendMessage(string message)
        {
            if (channel != null)
            {
                channel.Say(message);
                return true;
            }
            else
                return false;
        }
    }
}
