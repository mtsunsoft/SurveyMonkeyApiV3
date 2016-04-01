using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyMonkeyApiV3.Models;

namespace SurveyMonkeyApiV3.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestGetSurveys()
        {
            SurveyMonkey.AuthToken = ConfigurationManager.AppSettings["SurveyMonkeyAuthToken"];
            SurveyMonkey.ApiKey = ConfigurationManager.AppSettings["SurveyMonkeyApiKey"];

            List<Survey> surveys = await Surveys.GetSurveys();
            Assert.IsNotNull(surveys);

            SurveyDetails details = await Surveys.GetSurveyDetails(surveys[0].id);
            Assert.IsNotNull(details);

            SurveyDetails detailsExpanded = await Surveys.GetSurveyDetailsExpanded(surveys[0].id);
            Assert.IsNotNull(detailsExpanded.pages);

            List<Page> pages = await Surveys.GetSurveyPages(surveys[0].id);
            Assert.AreNotEqual(0, pages.Count);

            Page page = await Surveys.GetSurveyPageDetails(surveys[0].id, pages[0].id);
            Assert.IsNotNull(page);
        }
    }
}
