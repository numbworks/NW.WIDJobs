namespace NW.WIDJobs
{
    public class Page
    {

        // Fields
        // Properties
        public string RunId { get; }
        public ushort PageNumber { get; }
        public string Content { get; }

        // Constructors
        public Page
            (string runId, ushort pageNumber, string content) 
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));
            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            RunId = runId;
            PageNumber = pageNumber;
            Content = content;

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/