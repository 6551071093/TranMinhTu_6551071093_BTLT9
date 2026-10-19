using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace App_QuanLyChiTieu.Configurations
{
    internal class AppSettings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; } = new();
    }
    public class ConnectionStringsSettings
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }
}
