using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGwpService
{
    Task<Dictionary<string, decimal>> GetAverageGwp(GwpRequest request);
}
