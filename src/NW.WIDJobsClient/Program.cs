using System;
using NW.WIDJobsClient.CommandLine;

namespace NW.WIDJobsClient
{
    class Program
    {

        static int Main(string[] args)
        {

            CommandLineManager commandLineManager = new CommandLineManager();

            return commandLineManager.Execute(args);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 31.08.2021
*/