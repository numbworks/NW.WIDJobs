namespace NW.WIDJobs
{
    public class PageItemResponse
    {

        // Fields
        // Properties
        public PageItem PageItem { get; set; }
        public string Content { get; set; }

        // Constructors
        public PageItemResponse(PageItem pageItem, string content)
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));
            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            PageItem = pageItem;
            Content = content;            

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/