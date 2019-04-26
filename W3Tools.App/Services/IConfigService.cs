using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Tools.App.Services
{
    public interface IConfigService
    {
        string GetSetting(string key);
        string SetSetting(string key, string value);
        bool SettingExists(string key);
    }
}
