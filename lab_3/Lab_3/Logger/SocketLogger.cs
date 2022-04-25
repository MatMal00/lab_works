using System;
using System.Text;

namespace Lab_3.Logger
{
    class SocketLogger : ILogger
    {
        private ClientSocket clientSocket;
        private bool disposedValue;

        public SocketLogger(string host, int port)
        {
            this.clientSocket = new ClientSocket(host, port);
        }

        public void Log(params string[] messages)
        {
            DateTime time = DateTime.Now;

            try
            {
                string messageToSend = time.ToString("yyyy-MM-ddTHH:mm:sszzz") + ": ";
                foreach (var message in messages) messageToSend += message + " ";

                clientSocket.Send(Encoding.UTF8.GetBytes(messageToSend));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    clientSocket.Dispose();

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~SocketLogger()
        {
            Dispose(disposing: false);
        }
    }
}
