using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITestService
    {
        IEnumerable<string> GetTestValues();
    }

    public class TestService : ITestService
    {
        public IEnumerable<string> GetTestValues()
        {
            return new List<string> {"Hello", "this", "is", "a", "injected", "service"};
        }
    }
}
