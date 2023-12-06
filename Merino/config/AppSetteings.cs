using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merino.config
{

    public class AppSetteings
    {
        public string Env { get; set; }

        public SettingFile SettingFile { get; set; }
    }

    public class SettingFile
    {
        public string Database { get; set; }
    }

    public class DatabaseSetting
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        
    }

    public class ConnectionStrings
    {
        public string yuta_SampleWeb01Context { get; set; }
    }



}
