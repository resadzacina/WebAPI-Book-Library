using Txtr.Platform.Logging.Writers;

namespace Txtr.Platform.Logging.Queues
{
    internal interface IQueue
    {
        AbstractWriter Writer { get; }

        void Enqueue( LogEntry entry );

        void Flush();

        void Close();
    }
}