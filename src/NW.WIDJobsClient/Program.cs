using System;
using NW.WIDJobsClient.CommandLine;
using NW.WIDJobs;
using NW.WIDJobs.BulletPoints;
using System.Collections.Generic;

namespace NW.WIDJobsClient
{
    class Program
    {

        // Fields

        // Methods_Public
        static int Main(string[] args)
        {

            //CommandLineManager commandLineManager = new CommandLineManager();

            //return commandLineManager.Execute(args);

            WIDExplorer widExplorer = new WIDExplorer();
            List<BulletPoint> bulletPoints = widExplorer.GetPreLabeledBulletPoints();
            widExplorer.SaveToJsonFile(bulletPoints);


            return 0;
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