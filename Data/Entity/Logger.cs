using Data.Entity;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Logger
    {
        public abstract void Info(String eventType, MovableEntity circle);

    }

    internal class CircleLogger : Logger
    {
        private readonly string filename;
        private FileStream file;
        private readonly Queue<String> messages;
        private readonly Mutex mutex = new Mutex();
        private Task runner;
        private readonly AsyncAutoResetEvent waitHandle = new AsyncAutoResetEvent(false);

        internal CircleLogger()
        {
            filename = @"..\..\..\..\logs.json";
            messages = new Queue<String>();
            runner = Run(30, CancellationToken.None);
        }

        public override void Info(string eventType, MovableEntity circle)
        {
            mutex.WaitOne();
            Message m = new Message($"{DateTime.Now:yyyy-MM-dd HH-mm-ss-ffff}", eventType, circle);
            messages.Enqueue(m.Serialize());
            mutex.ReleaseMutex();
            waitHandle.Set();
        }


        private async Task Run(int interval, CancellationToken cancellationToken)
        {
            file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Queue<string> m = GetMessages();
                    if (m != null)
                        while (m.Count > 0)
                        {
                            byte[] msg = Encoding.ASCII.GetBytes((m.Dequeue() + "\n"));
                            file.Write(msg, 0, msg.Length);
                        }
                }
                await waitHandle.WaitAsync(cancellationToken);
            }
            file.Dispose();
        }

        private Queue<String> GetMessages()
        {
            mutex.WaitOne();
            if (messages.Count == 0)
            {
                mutex.ReleaseMutex();
                return null;
            }
            Queue<string> m = new Queue<string>(messages);
            messages.Clear();
            mutex.ReleaseMutex();
            return m;
        }
        private class Message
        {
            private string timestamp;
            private string eventType;
            private MovableEntity circle;

            public string Timestamp { get => timestamp; }
            public string EventType { get => eventType; }
            public MovableEntity Circle { get => circle; }

            public Message(string timestamp, string eventType, MovableEntity circle)
            {
                this.timestamp = timestamp;
                this.eventType = eventType;
                this.circle = circle;
            }

            public string Serialize()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
        }
    }
}
