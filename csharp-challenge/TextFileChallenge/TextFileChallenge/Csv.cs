using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    class Csv
    {
        string filePath;
        IEnumerable<UserModel> records;

        public Csv(string fPath)
        {
            filePath = fPath;
            ReadCsv();
        }

        private void ReadCsv()
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            using (CsvReader csvReader = new CsvReader(streamReader))
            {
                records = csvReader.GetRecords<UserModel>().ToList();
            }
        }

        public IEnumerable<UserModel> GetRecords()
        {
            return records;
        }
    }
}
