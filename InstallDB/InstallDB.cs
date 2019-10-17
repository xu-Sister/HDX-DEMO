using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace InstallDB
{
    //这里跑两个bat文件
    [RunInstaller(true)]
    public partial class InstallDB : System.Configuration.Install.Installer
    {
        public InstallDB()
        {
            InitializeComponent();
        }
    }
}
