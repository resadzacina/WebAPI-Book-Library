using Txtr.Platform.Logging.Writers;

namespace Txtr.Platform.Logging.Queues
{
    internal class LogQueue : IQueue
    {
        const int SIZE_CHECK = 20;

        readonly object lockObject = new object();
        int checkSize;

        public AbstractWriter Writer { get; private set; }

        public LogQueue( AbstractWriter writer )
        {
            Writer = writer;
        }

        public void Enqueue( LogEntry entry )
        {
            WriteItem( entry );
        }

        public void Flush()
        {
            lock ( lockObject )
            {
                Writer.Flush();
            }
        }

        public void Close()
        {
            WriteItem( new LogEntry( "Logger", LogLevel.Info, "Logger Closing" ) );

            lock ( lockObject )
            {
                Writer.Close();
            }
        }

        void WriteItem( LogEntry entry )
        {
            lock ( lockObject )
            {
                Writer.Write( entry );

                if ( checkSize++ > SIZE_CHECK )
                {
                    if ( Writer.ShouldFlush )
                        this.Flush();

                    checkSize = 0;
                }
            }
        }
    }
}
