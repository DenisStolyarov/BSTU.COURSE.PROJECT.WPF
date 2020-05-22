using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BSTU.FileCabinet.BLL.Interfaces
{
    public interface IFileRecordService<T>
    {
        IEnumerable<T> ImportRecords(string path);
        void ExportRecords(IEnumerable<T> records, string path);
    }
}
