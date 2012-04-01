using System;
using Txtr.Platform.Logging.Formatters;

namespace Txtr.Platform.Logging.Writers
{
    public abstract class AbstractWriter
    {
        protected readonly IFormatter formatter;

        public AbstractWriter( IFormatter formatter )
        {
            this.formatter = formatter;
        }

        public abstract bool Initialize();

        public abstract void Write( params LogEntry[] items );

        public abstract bool ShouldFlush { get; }

        public abstract void Flush();

        public abstract void Close();

        protected bool HasHeader() {return !string.IsNullOrEmpty( this.formatter.Header ); }

        protected bool HasFooter() { return !string.IsNullOrEmpty( this.formatter.Footer ); }


    }
}
