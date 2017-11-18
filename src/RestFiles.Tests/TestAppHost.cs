using System.Collections.Generic;
using System.Linq;
using Funq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using RestFiles.ServiceInterface;
using ServiceStack;

namespace RestFiles.Tests
{
    public class TestAppHost
        : AppSelfHostBase
    {
        public const string ListeningOn = "http://localhost:8080/";

        public TestAppHost()
            : base("Self Host Integration Tests", typeof(FilesService).Assembly) { }

        public AppConfig AppConfig { get; set; }

        public override void Configure(Container container)
        {
            this.AppConfig = new AppConfig
            {
                RootDirectory = "App_Data/files/",
                TextFileExtensions = "txt,sln,proj,cs,config,asax".Split(',').ToList(),
                ExcludeDirectories = new List<string>(),
            };
            container.Register(this.AppConfig);
        }
    }
}
