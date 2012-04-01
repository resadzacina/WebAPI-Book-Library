using System;
using System.IO;
using System.Text;
using Txtr.Platform.Logging.Formatters;
using System.Diagnostics.CodeAnalysis;

namespace Txtr.Platform.Logging.Writers
{
    internal class FileWriter : AbstractWriter
    {
        // File Name
        string fileName;
        string logPath;

        // Stream Writer
        StreamWriter streamWriter;
        int maxSize = 512000;

        public FileWriter( string path, string name, IFormatter formatter ) : base( formatter )
        {
            this.fileName = name;
            this.logPath = path;
        }

        string FullName { get; set; }

        public int MaxSize
        {
            get { return this.maxSize; }
            set { this.maxSize = value; }
        }

        public override void Write( params LogEntry[] items )
        {
            if ( items != null )
            {
                try
                {
                    // open the log
                    if ( this.streamWriter == null ) OpenLog();

                    // check that the stream writer was opened.
                    if ( this.streamWriter == null ) throw new Exception( "FileWriter.Write - Stream Writer is null" );
                    
                    // loop through the items and write
                    foreach ( var item in items ) this.streamWriter.WriteLine( base.formatter.Format( item ) );
                }
                catch ( Exception exception )
                {
                    try
                    {
                        Reset();
                        System.Diagnostics.Debug.WriteLine( "Cannot write to Log " + exception.Message );
                        //WriteEmergencyMessage( "Cannot write to Log " + ex.Message );
                    }
                    catch { }
                }
            }
        }

        public bool IsMaxSize
        {
            get { return this.streamWriter != null ? this.streamWriter.BaseStream.Length > MaxSize : false; }
        }

        public void Reset()
        {
            Close();
            OpenLog();
        }

        [SuppressMessage("Microsoft.Design", "CA1031")]
        void OpenLog()
        {
            try
            {
                string logName = string.Format( "{0}_{1}.log", fileName, DateTime.Now.ToString( "yyyy'-'MM'-'dd'T'HH'_'mm'_'ss" ) );
                
                if ( !System.IO.Directory.Exists( logPath ) )
                    System.IO.Directory.CreateDirectory( logPath );

                FullName = Path.Combine( logPath, logName );
                streamWriter = new StreamWriter( FullName, false, UnicodeEncoding.UTF8 );
                streamWriter.AutoFlush = true;

                // header
                if ( base.HasHeader() ) this.streamWriter.WriteLine( base.formatter.Header );
            }
            catch ( Exception exception )
            {
                streamWriter = null;
                System.Diagnostics.Debug.WriteLine( "Cannot create Log " + exception.Message );
                //WriteEmergencyMessage( "Cannot write to Log " + ex.Message );
            }
        }

        public void Dispose()
        {
            using (streamWriter) { }

            GC.SuppressFinalize(this);
        }

        public override void Close()
        {
            // footer
            if ( this.streamWriter == null ) return;
            if ( base.HasFooter() ) this.streamWriter.WriteLine( base.formatter.Footer );
            this.streamWriter.Close();
        }

        public override bool Initialize()
        {
            OpenLog();
            return ( this.streamWriter != null );
        }

        public override bool ShouldFlush
        {
            get { return this.IsMaxSize; }
        }

        public override void Flush()
        {
            Close();
            OpenLog();
        }
    }
}
