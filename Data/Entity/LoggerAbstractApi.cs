using Data.Entity;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public abstract class LoggerAbstractApi
    {
        public abstract void Info(String eventType, MovableEntity circle);
        public abstract void Info(String eventType, List<MovableEntity> circles);

        public static LoggerAbstractApi Create()
        {
            return new BallLogger($"BouncingBallsLog {DateTime.Now:yyyy-MM-dd HH-mm-ss-ffff}");
        }
    }



    internal class BallLogger : LoggerAbstractApi
    {
        internal BallLogger(string logname)
        {
            filename = logname + ".log";
            messages = new Queue<String>();
            task = Run(30, CancellationToken.None);
        }

        public override void Info(string eventType, MovableEntity circle)
        {
            List<MovableEntity> l = new List<MovableEntity> { circle };
            Info(eventType, l);
        }

        public override void Info(string eventType, List<MovableEntity> circles)
        {
            mutex.WaitOne();
            Message m = new Message($"{DateTime.Now:yyyy-MM-dd HH-mm-ss-ffff}", eventType, circles);
            //Utrwalony stan
            messages.Enqueue(m.Serialize());
            mutex.ReleaseMutex();
            waitHandle.Set();
        }

        private async Task Run(int interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Queue<string> m = GetMessages();
                    if (m != null)
                        while (m.Count > 0)
                        {
                            File.AppendAllText(filename, m.Dequeue() + "\n");
                        }
                }
                await waitHandle.WaitAsync(cancellationToken);
            }
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
            private List<MovableEntity> circles;

            public string Timestamp { get => timestamp; }
            public string EventType { get => eventType; }
            public List<MovableEntity> Balls { get => circles; }

            public Message(string timestamp, string eventType, List<MovableEntity> circles)
            {
                this.timestamp = timestamp;
                this.eventType = eventType;
                this.circles = circles;
            }

            public string Serialize()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
        }

        private readonly string filename;
        private readonly Queue<String> messages;
        private readonly Mutex mutex = new Mutex();
        private Task task;
        private readonly AsyncAutoResetEvent waitHandle = new AsyncAutoResetEvent(false);

    }



}
