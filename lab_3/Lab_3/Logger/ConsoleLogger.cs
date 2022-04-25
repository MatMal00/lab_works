using System;

namespace Lab_3.Logger
{
    class ConsoleLogger : WriterLogger
    {
        public ConsoleLogger()
        {
            writer = Console.Out;
        }

        public override void Dispose()
        {
        }
    }
}
