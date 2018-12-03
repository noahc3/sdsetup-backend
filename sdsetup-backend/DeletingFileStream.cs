using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace sdsetup_backend
{
    public class DeletingFileStream : FileStream {
        public DeletingFileStream(string path, FileMode mode) : base(path, mode) {

        }

        public override void Close() {
            base.Close();
            File.Delete(Name);
        }

        ~DeletingFileStream() {
            base.Dispose();
            File.Delete(Name);
        }
    }
}
