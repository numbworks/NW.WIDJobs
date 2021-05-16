using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class ExplorationResult
    {

        // Fields
        // Properties
        public string RunId { get; }
        public uint TotalResults { get; }
        public ushort? TotalEstimatedPages { get; }
        public List<Page> Pages { get; }
        public List<PageItem> PageItems { get; }
        public List<PageItemExtended> PageItemsExtended { get; }

        // Constructors
        public ExplorationResult(
            string runId,
            uint totalResults,
            ushort? totalEstimatedPages = null,
            List<Page> pages = null,
            List<PageItem> pageItems = null,
            List<PageItemExtended> pageItemsExtended = null)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            RunId = runId;
            TotalResults = totalResults;
            TotalEstimatedPages = totalEstimatedPages;
            Pages = pages;
            PageItems = pageItems;
            PageItemsExtended = pageItemsExtended;

        }

        // Methods (public)
        public override string ToString()
        {

            return string.Concat(
                "{ ",
                $"'{nameof(RunId)}':'{RunId}', ",
                $"'{nameof(TotalResults)}':'{TotalResults}', ",
                $"'{nameof(TotalEstimatedPages)}':'{TotalEstimatedPages?.ToString() ?? "null"}', ",
                $"'{nameof(Pages)}':'{Pages?.Count.ToString() ?? "null"}', ",
                $"'{nameof(PageItems)}':'{PageItems?.Count.ToString() ?? "null"}', ",
                $"'{nameof(PageItemsExtended)}':'{PageItemsExtended?.Count.ToString() ?? "null"}'",
                " }"
                );

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/