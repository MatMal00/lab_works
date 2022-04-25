using System;
using System.IO;

namespace Lab_3.Logger
{
    public abstract class WriterLogger : ILogger
    {
        protected TextWriter writer;

        public virtual void Log(params string[] messages)
        {
            string messageToSend = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz") + ": ";
            foreach (var message in messages) messageToSend += message + " ";

            writer.WriteLine(messageToSend);
            writer.Flush();
        }

        public abstract void Dispose();

    }
}
