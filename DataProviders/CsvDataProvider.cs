using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

public class CsvDataProvider : IDataProvider
{
    private const string FilePath = "Data/gwpByCountry.csv";

    public async Task<IEnumerable<GwpData>> GetGwpData(string country, List<string> lob)
    {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader))
        {
            var records = await csv.GetRecordsAsync<GwpData>();
            return records.Where(d => d.Country == country && lob.Contains(d.Lob)).ToList();
        }
    }
}
