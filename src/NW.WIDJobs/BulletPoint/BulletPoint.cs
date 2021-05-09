namespace NW.WIDJobs
{
    public class BulletPoint
    {

        // Fields
        // Properties
        public string Label { get; }
        public string Text { get; }

        // Constructors
        public BulletPoint(string label, string text) 
        {

            Validator.ValidateStringNullOrWhiteSpace(label, nameof(label));
            Validator.ValidateStringNullOrWhiteSpace(text, nameof(text));

            Label = label;
            Text = text;

        }

        // Methods (public)
        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/