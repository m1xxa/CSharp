using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender
{
    class Program
    {
        /*
         Попроще:
        Есть три вида сообщений. 
        Есть два сервера, одни для входящих сообщений, 
        который их принимает, складывает в три очереди 
        по типу и ведёт статистику. 
        Второй обрабатывает сообщения с каждой очереди 
        и сохраняет все сообщения в архивный файл. 
        В Х минут отсылается У сообщений
        */

        static void Main(string[] args)
        {
            StorageServer storageServer = new StorageServer();
            ReciveMessageServer reciveMessageServer = new ReciveMessageServer();
            ProccedMessageServer proccedMessageServer = new ProccedMessageServer();
            Random random = new Random();
            int index = 1;

            while (true)
            {
                Thread.Sleep(random.Next(0, 10) * 500);
                int numberOfMessage = random.Next(0, 50);
                List<Message> list = new List<Message>();

                for (int i = 0; i < numberOfMessage; i++)
                {
                    int type = random.Next(1, 4);
                    switch (type)
                    {
                        case 1: 
                            list.Add(new MessageTypeOne(index.ToString()));
                            break;
                        case 2:
                            list.Add(new MessageTypeTwo(index.ToString()));
                            break;
                        case 3:
                            list.Add(new MessageTypeThree(index.ToString()));
                            break;
                    }
                    index++;
                }

                reciveMessageServer.ReciveMessage(list);
                reciveMessageServer.SaveToServer(storageServer);
                proccedMessageServer.ProceedMessage(storageServer);
            }
        }
    }
}
