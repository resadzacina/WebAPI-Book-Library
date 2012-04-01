using System;

namespace Txtr.Platform.Logging
{
    internal interface IWriter : IDisposable
    {
        bool Initialize();

        void Write( string[] items );

        bool ShouldFlush { get; }

        void Flush();
    }
}
