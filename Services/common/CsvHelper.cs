using CsvHelper;
using CsvHelper.Configuration;
using GrpcAgroService.Models;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using static GrpcAgroService.Services.CsvConverterService;

namespace GrpcAgroService.Services.common
{
    public static class CsvHelper
    {
        public static IEnumerable<AgroFieldModel> MapCsvDataToEntities(IEnumerable<string[]> csvData)
        {
            //foreach (var row in csvData)
            //{
            //    AgroFieldModel? entity = new AgroFieldModel
            //    {
            //        Name = row[0],
            //        Aria = int.Parse(row[1]),
            //        Bal = int.Parse(row[2]),
            //        PH = int.Parse(row[3]),
            //        Gumus = int.Parse(row[4]),
            //        Azot = int.Parse(row[5]),
            //        Phosfor = int.Parse(row[6]),
            //        Kaliy = int.Parse(row[7]),
            //        Manganese = int.Parse(row[8]),
            //        Cobalt = int.Parse(row[9]),
            //        Copper = int.Parse(row[10]),
            //        Zinc = int.Parse(row[11]),
            //        Lead = int.Parse(row[12]),
            //        Cesium = int.Parse(row[13]),
            //        Strontium = int.Parse(row[14])
            //    };

            //    entities.Add(entity);
            //}

            //return entities;
            return null;
        }

        public static List<InputModel> ReadCsvData(string filePath)
        {
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ";",
                HasHeaderRecord = true
            };
            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(reader, configuration))
                {
                    return csv.GetRecords<InputModel>().ToList();
                }
            }
        }
    }
}