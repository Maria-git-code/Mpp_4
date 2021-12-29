using System;
using System.Runtime.InteropServices;

namespace lab_4
{
    public class OsHandle : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;
        
        public IntPtr Handle 
        {
            get
            {
                if (!_disposed)
                {
                    return _handle;
                }
                else
                {
                    throw new ObjectDisposedException(ToString());
                }
            }
            set { _handle = value; }
        }
        [DllImport("Kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);
        
        public OsHandle()
        {
            _handle = IntPtr.Zero;
        }
        
        ~OsHandle()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
                
        public bool Close()
        {
            var result = CloseHandle(Handle);
            Dispose();
            return result;
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && _handle != IntPtr.Zero)
            {
                CloseHandle(Handle);
                _handle = IntPtr.Zero;
            }

            _disposed = true;
        }
    }
}