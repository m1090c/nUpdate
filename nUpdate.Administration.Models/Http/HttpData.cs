﻿using System;
using nUpdate.Administration.PluginBase.Models;

namespace nUpdate.Administration.Models.Http
{
    public class HttpData : ITransferData
    {
        public Uri ScriptUri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}