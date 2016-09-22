using System.Collections.Generic;

namespace RestFiles.ServiceInterface
{
    public class AppConfig
    {
        public string RootDirectory { get; set; }

        public List<string> TextFileExtensions { get; set; }

        public List<string> ExcludeDirectories { get; set; }
    }
}