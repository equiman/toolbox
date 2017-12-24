﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Linq;
using ToolBox.System;

namespace ToolBox.Platform
{
    public static partial class CommandSystem
    {
        public static ICommandSystem Win
        {
            get
            {
                return new CommandSystemWin();
            }
        }
    }

    public sealed class CommandSystemWin : ICommandSystem
    {
        public string PathNormalizer(string path) {
            try
            {
                return path.Replace(@"/",@"\");
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public string GetHomeFolder(string path) {
            try
            {
                return path.Replace("~",$"{Env.GetValue("USERPROFILE")}").Replace(@"/",@"\");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}