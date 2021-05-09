using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web;

namespace NW.WIDJobs
{
    public class PageItemExtendedScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public PageItemExtendedScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageItemExtendedScraper()
            : this(new XPathManager()) { }

        // Methods (public)
        public List<PageItemExtended> Do(PageItemResponse pageItemResponse)
        {

            Validator.ValidateObject(pageItemResponse, nameof(pageItemResponse));

            List<PageItemExtended> pageItems = new List<PageItemExtended>();

            /* ... */

            return pageItems;

        }

        // Methods (private)
        private string Old_GetEmployer(string response)
        {

            /*
             *  ...
             *  <div id="scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan">
             * 		<hr>
             * 		<h2>
             * 			BESTSELLER A/S
             * 		</h2>
             *      ...
             * 
             */

            string xpath = "//div[@id='scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan']//h2";

            string innerText = _xpathManager.GetInnerText(response, xpath);
            innerText = TrimOrNull(innerText);
            innerText = DecodeHtml(innerText);
            innerText = ToTitleCase(innerText);

            return innerText;

        }
        private short? Old_GetOpenings(string response)
        {

            /*
             * ...
             * 		<dl class="dl-justify nomargin">
             * 			<dt>
             * 				Number of openings:
             * 			</dt>
             * 			<dd>
             * 				 1
             * 				
             * 			</dd>
             *      ...
             * 
             */

            string xpath = "//dt[contains(.,'openings')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            innerText = TrimOrNull(innerText);

            return ParseOpeningsOrNull(innerText);

        }
        private DateTime? Old_GetAdvertisementPublishDate(string response)
        {

            /*
             * ...
             * 		<dl class="dl-justify nomargin">
             *      ...
             *          <dt>
             *              Advertisement publish date:
             *          </dt>
             *          <dd>
             *              08/08/2018
             *              
             *          </dd>
             *      ...
             * 
             */

            string xpath = "//dt[contains(.,'Advertisement')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            if (innerText == null)
                innerText = Old_GetCreated(response); // Some ads have this instead of Advertisement Publish Date.

            innerText = TrimOrNull(innerText);

            return ParseDateOrNull(innerText);

        }
        private DateTime? Old_GetApplicationDeadline(string response)
        {

            /*
             * ...
             * 		<dl class="dl-justify nomargin">
             *      ...
             *          <dt>
             *              Application deadline:
             *          </dt>
             *          <dd>
             *              29/08/2018
             *              
             *          </dd>
             *      ...
             * 
             */

            string xpath = "//dt[contains(.,'deadline')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            if (innerText == null)
                innerText = Old_GetApplicationDate(response); // Some ads have this instead of Application deadline.

            innerText = TrimOrNull(innerText);

            return ParseDateOrNull(innerText);

        }
        private string Old_GetEmploymentStartDate(string response)
        {

            /*
             * ...
             * 		<dl class="dl-justify nomargin">
             *      ...
             *          <dt>
             *              Start date of employment:
             *          </dt>
             *          <dd>
             *              As soon as possible
             *              
             *          </dd>
             *          </dd>
             *      </dl>
             *
             *  </div>
             * </div>
             * 
             */

            string xpath = "//dt[contains(.,'employment')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            innerText = TrimOrNull(innerText);

            return innerText;

        }
        private string Old_GetDescription(string response)
        {

            /*
             *  ...
             * 	<div class="row">
             * 	    <div class="col-sm-11">
             * 		    <div id="jobDescription">
             * 			    <p><strong>Do you speak Italian, and do you ...</p>
             * 		</div>
             * 		<br>
             *      ...
             * 
             */

            string xpath = "//div[@id='jobDescription']";

            string innerText = _xpathManager.GetInnerText(response, xpath);
            innerText = DecodeHtml(innerText);
            innerText = TrimOrNull(innerText);

            // The ads without a description usually have a presentation 
            // (shorter description + link to the complete one)
            if (innerText == null)
                innerText = Old_GetPresentation(response);

            return innerText;

        }
        private string Old_GetPosition(string response)
        {

            /*
             * ...
             * <aside>
             *    <div class="row row-wide aside padding-left-extra">
             *        <div class="col-sm-12">
             *
             *            <div class="row">
             *                <div class="col-ms-6 col-sm-4">
             *
             *      ...
             *
             *                    <h3 id="scphpage_0_scphcontent_1_ctl00_H1">
             *                        Position
             *                    </h3>
             *                    <p>
             *                        Management / Sales and marketing managers
             *                    </p>
             *      ...
             * 
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//p";
            uint valueNr = 1; // 0 is an empty <p>/<p>

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            innerText = TrimOrNull(innerText);

            return innerText;

        }
        private string Old_GetEmploymentType(string response)
        {

            /*
             * ...
             * <aside>
             *    <div class="row row-wide aside padding-left-extra">
             *        <div class="col-sm-12">
             *
             *            <div class="row">
             *                <div class="col-ms-6 col-sm-4">
             *
             *      ...
             *
             *                    <h3>
             *                        Type of employment
             *                    </h3>
             *                    <p>
             *                        Regular position
             *                        
             *                    </p>
             *      ...
             * 
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//p";
            uint valueNr = 2;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            innerText = TrimOrNull(innerText);

            return innerText;

        }
        private string Old_GetWeeklyWorkingHours(string response)
        {

            /*
             * ...
             * <aside>
             *    <div class="row row-wide aside padding-left-extra">
             *        <div class="col-sm-12">
             *
             *            <div class="row">
             *                <div class="col-ms-6 col-sm-4">
             *
             *      ...
             *
             *                    <h3>
             *                        Weekly working hours
             *                    </h3>
             *                    <p>
             *                        Full time (37 hours)
             *                        
             *                    </p>
             *      ...
             * 
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//p";
            uint valueNr = 3;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);
            innerText = TrimOrNull(innerText);

            return innerText;

        }
        private string Old_GetContact(string response)
        {

            /*
             * ...
             * <div class="col-ms-6 col-sm-4">
             *
             *     <h3>
             *         Contact
             *     </h3>
             *     <p>
             *        <span id="scphpage_0_scphcontent_1_ctl00_uiContactNameSpan">
             *           Apply online<br>
             *        </span>
             *     </p>
             * 
             *  ...
             * 
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//p//span[@id='scphpage_0_scphcontent_1_ctl00_uiContactNameSpan']";

            string innerText = _xpathManager.GetInnerText(response, xpath);
            innerText = TrimOrNull(innerText);

            return innerText;

        }
        private string Old_GetEmployerAddress(string response)
        {

            /*
             * ...
             * <div class="col-ms-6 col-sm-4">
             *      
             *      ...
             *     <h3 id="scphpage_0_scphcontent_1_ctl00_uiEmployerHeading">
             *          Employer
             *      </h3>
             *      <p id="scphpage_0_scphcontent_1_ctl00_uiEmployerAddressSpan">
             *          BESTSELLER A/S<br>
             *                                  Fredskovvej 5<br>
             *                                  DK 7330 Brande<br>
             *                                  Denmark<br>
             *      </p>
             * 
             *  ...
             * 
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//p[@id='scphpage_0_scphcontent_1_ctl00_uiEmployerAddressSpan']";

            string innerText = _xpathManager.GetInnerText(response, xpath);
            innerText = TrimOrNull(innerText);
            innerText = DecodeHtml(innerText);

            if (innerText != null)
                innerText = CleanEmployerAddress(innerText);

            return innerText;

        }
        private string Old_GetHowToApply(string response)
        {

            /*
             * ...
             *  <div class="col-ms-6 col-sm-4">
             *      <h3 id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyHeading">
             *          How to apply
             *      </h3>
             *      <ul>
             * 
             *          <li id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyOnlineSpan"><span style="word-wrap: break-word">
             *              Online:
             *              <a id="scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline" href="http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696" target="_blank">Application form</a><br>
             *          </span></li>
             *      </ul>
             *  ...
             *  
             *  or:
             *  
             *  ...
             *  <div class="col-ms-6 col-sm-4">
             *     <h3 id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyHeading">
             *           How to apply
             *      </h3>
             *      <ul>
             *           <li id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyByEmailSpan"><span style="word-wrap: break-word">
             *               Via e-mail:
             *               <a id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyEmail" href="mailto:jobs@colourbox.com"> jobs@colourbox.com</a><br />
             *           </span></li>
             *  ...
             * 
             */

            string xpath1 = "//div[@class='col-ms-6 col-sm-4']//ul";

            string innerText = _xpathManager.GetInnerText(response, xpath1);
            innerText = TrimOrNull(innerText);

            if (innerText != null)
                innerText = innerText.Replace("  ", string.Empty).Replace(Environment.NewLine, " ");

            string xpath2 = "//a[@id='scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline']/@*";
            uint attributeNr = 1;

            List<string> attributeValues = _xpathManager.GetAttributeValues(response, xpath2, attributeNr);
            if (attributeValues == null)
                return innerText;
            if (attributeValues.Count < 1)
                return innerText;
            if (attributeValues[0] == string.Empty)
                return innerText;

            // We are only interested into the first hyperlink found, if any and not-null.
            innerText = string.Concat(innerText, "<", TrimOrNull(attributeValues[0]), ">");

            return innerText;

        }
        private string Old_GetPresentation(string response)
        {

            /*
             *  ...
             * 	<div class="row">
             * 	<div class="col-sm-11">
             * 	    <div class="JobPresentation">
             * 	        Security Architect IBM Nordic...
             * 	    </div>
             * 	    
             *  	<a href="https://krb-sjobs.brassring.com/TGnewUI/Search/home/HomeWithPreLoad?partnerid=26059&siteid=5016&PageType=JobDetails&jobid=148439">See the complete text at IBM Danmark ApS</a>
             *      ...
             * 
             */

            string xpath1 = "//div[@class='JobPresentation']";

            string innerText1 = _xpathManager.GetInnerText(response, xpath1);
            innerText1 = TrimOrNull(innerText1);

            string xpath2 = "//a[contains(., 'complete')]";
            string innerText2 = _xpathManager.GetInnerText(response, xpath2);

            string xpath3 = "//a[contains(., 'complete')]/@href";
            string innerText3 = _xpathManager.GetFirstAttributeValue(response, xpath3);

            return string.Join(Environment.NewLine, innerText1, innerText2, innerText3);

        }
        private string Old_GetCreated(string response)
        {

            /*
             * ...
             *  <div class="col-sm-11 ">
             *      <dl class="dl-justify nomargin">
             *  		<dt>Created</dt>
             *  		<dd>30/06/2018</dd>
             *  		...
             *  	</dl>
             *  </div>
             *  ...
             * 
             */

            string xpath = "//dt[contains(.,'Created')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);

            return innerText;

        }
        private string Old_GetApplicationDate(string response)
        {

            /*
             * ...
             * 		<dl class="dl-justify nomargin">
             *      ...
             *          <dt>Application</dt>
             *          <dd>29/08/2018</dd>
             *      ...
             * 
             */

            string xpath = "//dt[contains(.,'Application')]/following-sibling::dd";
            uint valueNr = 0;

            string innerText = _xpathManager.GetInnerText(response, xpath, valueNr);

            return innerText;

        }

        private string TrimOrNull(string str)
        {

            if (str == null)
                return null;

            return str.Trim();

        }
        private DateTime? ParseDateOrNull(string str)
        {

            try
            {

                string[] arr = str.Split('/'); // "29/08/2018" => "29"; "08"; "2018";
                if (arr.Length != 3)
                    return null;

                return new DateTime(
                    ushort.Parse(arr[2]),   // 2018
                    ushort.Parse(arr[1]),   // 08
                    ushort.Parse(arr[0])    // 29
                    );

            }
            catch
            {
                return null;
            }

        }
        private short? ParseOpeningsOrNull(string str)
        {

            try
            {
                return short.Parse(str);
            }
            catch
            {
                return null;
            }

        }
        private string ToTitleCase(string str)
        {

            if (str == null)
                return null;

            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

            // ToTitleCase() doesn't work on all-uppercase strings.
            return textInfo.ToTitleCase(str.ToLower());

        }
        private string DecodeHtml(string str)
        {

            if (str == null)
                return null;

            return HttpUtility.HtmlDecode(str);

        }
        private string CleanEmployerAddress(string str)
            => str.Replace("                        ", string.Empty).Replace(Environment.NewLine, " ");

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/