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
            : base("Self Host Integration Tests", typeof(FilesService).GetAssembly()) { }

        public AppConfig Config { get; set; }

        public override void Configure(Container container)
        {
            this.Config = new AppConfig
            {
                RootDirectory = "App_Data/files/",
                TextFileExtensions = "txt,sln,proj,cs,config,asax".Split(',').ToList(),
                ExcludeDirectories = new List<string>(),
            };
            container.Register(this.Config);
        }

        protected IWebHost WebHost { get; set; }

        public override ServiceStackHost Start(string[] urlBases)
        {
            this.WebHost = ConfigureHost(new WebHostBuilder(), urlBases).Build();
            this.WebHost.Start();

            return this;
        }

        public override void Dispose()
        {
            this.WebHost.Dispose();
            this.WebHost = null;

            base.Dispose();
        }
    }
}