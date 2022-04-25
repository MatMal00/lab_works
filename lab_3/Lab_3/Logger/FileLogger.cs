using System;
using System.IO;
using System.Text;

namespace Lab_3.Logger
{
    class FileLogger : WriterLogger
    {
        private bool disposed;
        protected FileStream stream = null;

        public FileLogger(string path)
        {
            stream = new FileStream(path, FileMode.Append);
            writer = new StreamWriter(stream, Encoding.UTF8);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (stream != null) this.stream.Dispose();
                }

                this.disposed = true;
            }
        }

        public override void Dispose()
        {
            this.Dispose(disposing: true);
        }

        ~FileLogger()
        {
            Dispose(disposing: false);
        }
    }
}
