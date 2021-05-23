using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>The result of an exploration on <see href="http://www.workindenmark.dk">WorkInDenmark</see>.</summary>
    public class WIDExploration
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public uint TotalResults { get; }
        public ushort TotalEstimatedPages { get; }
        public WIDCategories Category { get; }
        public WIDStages Stage { get; }
        public bool IsCompleted { get; }
        public List<Page> Pages { get; }
        public List<PageItem> PageItems { get; }
        public List<PageItemExtended> PageItemsExtended { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExploration"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public WIDExploration(
            string runId,
            uint totalResults,
            ushort totalEstimatedPages,
            WIDCategories category,
            WIDStages stage,
            bool isCompleted,
            List<Page> pages = null,
            List<PageItem> pageItems = null,
            List<PageItemExtended> pageItemsExtended = null
            )
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            RunId = runId;
            TotalResults = totalResults;
            TotalEstimatedPages = totalEstimatedPages;
            Category = category;
            Stage = stage;
            IsCompleted = isCompleted;

            Pages = pages;
            PageItems = pageItems;
            PageItemsExtended = pageItemsExtended;

        }

        #endregion

        #region Methods_public

        public override string ToString()
        {

            return string.Concat(
                "{ ",
                $"'{nameof(RunId)}':'{RunId}', ",
                $"'{nameof(TotalResults)}':'{TotalResults}', ",
                $"'{nameof(TotalEstimatedPages)}':'{TotalEstimatedPages}', ",
                $"'{nameof(Category)}':'{Category}', ",
                $"'{nameof(Stage)}':'{Stage}', ",
                $"'{nameof(IsCompleted)}':'{IsCompleted}', ",
                $"'{nameof(Pages)}':'{Pages?.Count.ToString() ?? "null"}', ",
                $"'{nameof(PageItems)}':'{PageItems?.Count.ToString() ?? "null"}', ",
                $"'{nameof(PageItemsExtended)}':'{PageItemsExtended?.Count.ToString() ?? "null"}'",
                " }"
                );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/