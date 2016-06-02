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
        string GetValue(string key);
    }

    public class TestService : ITestService
    {
        public IEnumerable<string> GetTestValues()
        {
            return new List<string> {"Hello", "this", "is", "a", "injected", "service", "method"};
        }

        public string GetValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return "test";
        }
    }
}
