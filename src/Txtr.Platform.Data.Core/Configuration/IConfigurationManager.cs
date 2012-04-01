using System.Collections.Specialized;

namespace Txtr.Platform.Data.Core.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings
        {
            get;
        }

        string ConnectionStrings(string name);

        T GetSection<T>(string sectionName);
    }
}