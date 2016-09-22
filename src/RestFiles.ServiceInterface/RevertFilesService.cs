using RestFiles.ServiceModel;
using ServiceStack;
using ServiceStack.VirtualPath;

namespace RestFiles.ServiceInterface
{
    /// <summary>
    /// Define your ServiceStack web service request (i.e. Request DTO).
    /// </summary>
    public class RevertFilesService : Service
    {
        /// <summary>
        /// Gets or sets the AppConfig. The built-in IoC used with ServiceStack autowires this property.
        /// </summary>
        public AppConfig Config { get; set; }

        public object Post(RevertFiles request)
        {
            VirtualFiles.DeleteFolder(Config.RootDirectory);

            foreach (var file in VirtualFiles.GetDirectory("src").GetAllMatchingFiles("*.*"))
            {
                VirtualFiles.WriteFile(file, file.VirtualPath.Replace("src/", Config.RootDirectory));
            }

            return new RevertFilesResponse();
        }
    }
}