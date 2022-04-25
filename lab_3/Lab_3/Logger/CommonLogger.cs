using System;

namespace Lab_3.Logger
{
    class CommonLogger : ILogger
    {
        private ILogger[] loggers;
        private bool disposed;

        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void Log(params string[] messages)
        {
            foreach (var log in loggers)
                log.Log(messages);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    foreach (var logger in loggers) logger.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
