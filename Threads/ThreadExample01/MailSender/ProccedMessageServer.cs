using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MailSender
{
    class ProccedMessageServer
    {
        private static readonly object Locker = new object();
        public void ProceedMessage(StorageServer storageServer)
        {
            Thread threadOne = new Thread(() => SaveMessage(storageServer, 1));
            threadOne.Start();
            Thread threadTwo = new Thread(() => SaveMessage(storageServer, 2));
            threadTwo.Start();
            Thread threadThree = new Thread(() => SaveMessage(storageServer, 3));
            threadThree.Start();
        }

        private void SaveMessage(StorageServer storageServer, int messageType)
        {
            List<Message> listMessages = new List<Message>();
            switch (messageType)
            {
                case 1: 
                    listMessages.AddRange(storageServer.MessagesTypeOne);
                    storageServer.MessagesTypeOne.Clear();
                    break;
                case 2:
                    listMessages.AddRange(storageServer.MessagesTypeTwo);
                    storageServer.MessagesTypeTwo.Clear();
                    break;
                case 3:
                    listMessages.AddRange(storageServer.MessagesTypeThree);
                    storageServer.MessagesTypeThree.Clear();
                    break;
            }

            lock (Locker)
            {
                using (StreamWriter sw = new StreamWriter(@"d:\intita\log.ms", true, System.Text.Encoding.Default))
                {
                    foreach (var message in listMessages)
                    {
                        sw.WriteLine(message + " " + message.Text);
                    }

                }
            }
           
            
        }
    }
}