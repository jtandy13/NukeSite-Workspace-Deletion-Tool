using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NukeSpace
{
    class NukeSetting 
    {
        private string _DBname;
        private string _serverName;
        private string _csvPath;

        public string DBname
        {
            get { return _DBname; }
            set
            {
                if (_DBname != value)
                {
                    _DBname = value;
                   
                }
            }
        }

        public string serverName
        {
            get { return _serverName; }
            set
            {
                if (_serverName != value)
                {
                    _serverName = value;
                    
                }
            }
        }
        public string csvPath
        {
            get { return _csvPath; }
            set
            {
                if (_csvPath != value)
                {
                    _csvPath = value;
                    
                }
            }
        }


        public NukeSetting() { }
    }
}
