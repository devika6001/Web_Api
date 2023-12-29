using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataProvider
{
    Task<IEnumerable<GwpData>> GetGwpData(string country, List<string> lob);
}
