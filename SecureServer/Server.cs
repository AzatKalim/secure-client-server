using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Security.Cryptography;

namespace SecureServer
{
    class Server
    {   
        BasicHttpBinding binding;

        ServiceHost host;

        SHA256 hashFunction;
       
        public  Server()
        {
            Console.Title = "SERVER";           
            // Создание провайдера Хостинга с указанием Сервиса.
            host = new ServiceHost(typeof(Service));

            hashFunction = SHA256Managed.Create();
        }
        public void StartHost()
        {
            // Начало ожидания прихода сообщений.
            host.Open();
        }
        public void StopHost()
        {
            // Завершение ожидания прихода сообщений.
            host.Close();
        }

        public byte[] ComputeHash(string message)
        {
            Byte[] msgByteArr = Encoding.ASCII.GetBytes(message);
            Byte[] hashArray = hashFunction.ComputeHash(msgByteArr);
            return hashArray;
        }
    }
}
