﻿// StartServiceAction.cs, 14.11.2019
// Copyright (C) Dominic Beger 24.03.2020

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nUpdate.Actions
{
    public class StartServiceAction : IUpdateAction
    {
        public IEnumerable<string> Arguments { get; set; }
        public string ServiceName { get; set; }
        public string Description => "Starts a service.";

        public Task Execute()
        {
            return Task.Run(() => { ServiceManager.StartService(ServiceName, Arguments.ToArray()); });
        }

        public bool ExecuteBeforeReplacingFiles { get; set; }
        public string Name => "StartService";
    }
}