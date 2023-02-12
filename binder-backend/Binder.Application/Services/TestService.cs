using Binder.Core.Models;

namespace Binder.Application.Services
{
    public class TestService
    {
        public string GetHelloMessage()
        {
            return new TestData().HelloText;
        }
    }
}