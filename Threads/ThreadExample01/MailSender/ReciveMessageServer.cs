using System;
using System.Collections.Generic;

namespace MailSender
{
    class ReciveMessageServer
    {
        private readonly List<Message> _listOfMessages = new List<Message>();
        public void ReciveMessage(List<Message> listOfMessages)
        {
            this._listOfMessages.AddRange(listOfMessages);
        }

        public void SaveToServer(StorageServer storageServer)
        {
            foreach (var message in _listOfMessages)
            {
                if (message is MessageTypeOne)
                {
                    storageServer.MessagesTypeOne.Add(message);
                    Console.WriteLine("Message type one was stored");
                }
                if (message is MessageTypeTwo)
                {
                    storageServer.MessagesTypeTwo.Add(message);
                    Console.WriteLine("Message type two was stored");
                }
                if (message is MessageTypeThree)
                {
                    storageServer.MessagesTypeThree.Add(message);
                    Console.WriteLine("Message type three was stored");
                }
            }

            _listOfMessages.Clear();
        }
        
    }
}