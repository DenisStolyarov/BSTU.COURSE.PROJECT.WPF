using BSTU.FileCabinet.BLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.BLL.Services
{
    public class CommonFileRecordService<Entity> : IFileRecordService<Entity>
    {
        private const string FormatExtension = ".json";

        public void ExportRecords(IEnumerable<Entity> entities, string path)
        {
            if (!IsValidPath(path))
            {
                throw new ArgumentException();
            }

            var records = JsonConvert.SerializeObject(entities);
            File.WriteAllText(path, records);
        }

        public IEnumerable<Entity> ImportRecords(string path)
        {
            if (!IsValidPath(path))
            {
                throw new ArgumentException();
            }

            var records = File.ReadAllText(path);
            var entities = JsonConvert.DeserializeObject<IEnumerable<Entity>>(records);
            return entities;
        }

        private bool IsValidPath(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            if (!Path.GetExtension(path).Equals(FormatExtension))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
