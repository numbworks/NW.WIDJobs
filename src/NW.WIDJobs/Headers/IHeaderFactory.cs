using System.Net;

namespace NW.WIDJobs.Headers
{

    public interface IHeaderFactory
    {
        /// <summary>Creates a collection of headers to attach to a HTTP Request.</summary>	
        WebHeaderCollection Create();
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/
