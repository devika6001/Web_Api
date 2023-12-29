using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GwpService : IGwpService
{
    private readonly IDataProvider _dataProvider;

    public GwpService(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public async Task<Dictionary<string, decimal>> GetAverageGwp(GwpRequest request)
    {
        var data = await _dataProvider.GetGwpData(request.Country, request.Lob);

        var result = new Dictionary<string, decimal>();
        foreach (var lob in request.Lob)
        {
            var average = data.Where(d => d.Lob == lob).Average(d => d.Gwp);
            result.Add(lob, average);
        }

        return result;
    }
}
