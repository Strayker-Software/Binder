using System.Reflection;
using Binder.Application.Models.Interfaces;

namespace Binder.Application.Services
{
    public sealed class AppVersionService : IAppVersionService
    {
        public string GetAppVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            Version? version = assemblyName.Version;

            return version is not null ? $"{version.Major}.{version.Minor}.{version.Revision}" : string.Empty;
        }
    }
}