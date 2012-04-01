using System;

namespace Txtr.Platform.Logging.Writers
{
    public class NullWriter : AbstractWriter
    {
        public NullWriter() : base( null ) { }

        public override bool Initialize() { return true; }

        public override bool ShouldFlush { get { return false; } }

        public override void Write( params LogEntry[] items ) { }

        public override void Flush() { }

        public void Dispose() { }

        public override void Close() {}
    }
}
