using System.Linq;
using Funq;
using RestFiles.ServiceInterface;
using ServiceStack;

namespace RestFiles.Tests
{
    public class TestAppHost
        : AppSelfHostBase
    {
        public const string ListeningOn = "http://localhost:8080/";

        public TestAppHost()
            : base("HttpListener Hosts for Unit Tests", typeof(FilesService).GetAssembly()) { }

        public AppConfig Config { get; set; }

        public override void Configure(Container container)
        {
            this.Config = new AppConfig
            {
                RootDirectory = "~/App_Data/files/".MapAbsolutePath(),
                TextFileExtensions = ".txt,.sln,.proj,.cs,.config,.asax".Split(',').ToList(),
            };
            container.Register(this.Config);

            this.Start(ListeningOn);
        }
    }
}