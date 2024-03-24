using Binder.Api;
using Binder.Application.Services;
using System.Reflection;

namespace Binder.UnitTests.Services
{
    public class AppVersionServiceTests
    {
        [Fact]
        public void GetAppVersion_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            Version appVersion = Assembly.GetAssembly(typeof(Program))!.GetName().Version!;

            // Act
            var result = service.GetAppVersion();

            // Assert
            result.Should().Be($"{appVersion.Major}.{appVersion.Minor}.{appVersion.Revision}");
        }

        private static AppVersionService CreateService()
        {
            return new AppVersionService();
        }
    }
}