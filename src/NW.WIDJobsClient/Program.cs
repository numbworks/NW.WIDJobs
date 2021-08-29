using System;
using NW.WIDJobsClient.CommandLine;

namespace NW.WIDJobsClient
{
    class Program
    {

        // Fields

        // Methods_Public
        static int Main(string[] args)
        {

            CommandLineManager commandLineManager = new CommandLineManager();
            
            return commandLineManager.Execute(args);

        }

        // Methods_Private

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 2.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/