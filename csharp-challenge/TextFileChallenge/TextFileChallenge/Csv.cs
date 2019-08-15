using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    public class Csv
    {
        string filePath;
        IEnumerable<UserModel> records;
        string[] headerRow;

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

                csvReader.Read();
                csvReader.ReadHeader();

                headerRow = csvReader.Context.HeaderRecord; 

                records = csvReader.GetRecords<UserModel>().ToList();
            }
        }

        public IEnumerable<UserModel> GetRecords()
        {
            return records;
        }

        public void SaveToCsv(IEnumerable<UserModel> users)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter))
            {
                foreach (string column in headerRow)
                {
                    csvWriter.WriteField(column);
                }
                csvWriter.NextRecord();

                foreach (var user in users)
                {
                    foreach (string column in headerRow)
                    {
                        csvWriter.WriteField(user.GetType().GetProperty(column).GetValue(user));
                    }
                    csvWriter.NextRecord();
                }
            }
        }
    }
}
