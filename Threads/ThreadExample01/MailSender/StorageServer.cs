using System.Collections.Generic;

namespace MailSender
{
    class StorageServer
    {
        public StorageServer()
        {
            MessagesTypeOne = new List<Message>();
            MessagesTypeTwo = new List<Message>();
            MessagesTypeThree = new List<Message>();
        }
        public List<Message> MessagesTypeOne { get; set; }
        public List<Message> MessagesTypeTwo { get; set; }
        public List<Message> MessagesTypeThree { get; set; }
    }
}