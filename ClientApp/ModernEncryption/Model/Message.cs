using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ModernEncryption.Model
{
    class Message
    {
        public string Text { get; }
        public int Sender { get; }
        public int KeyNumber { get; }
        public int Timestamp { get; }
        public int Receiver { get; }

        public Message(string text, int sender, int keyNumber, int timestamp, int receiver)
        {
            Sender = sender;
            Text = text;
            KeyNumber = keyNumber;
            Timestamp = timestamp;
            Receiver = receiver;
        }
    }
}
