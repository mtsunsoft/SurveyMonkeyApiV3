using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
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
            Thread.Sleep(500);

            SurveyDetails details = await Surveys.GetSurveyDetails(surveys[0].id);
            Assert.IsNotNull(details);
            Thread.Sleep(500);

            SurveyDetails detailsExpanded = await Surveys.GetSurveyDetailsExpanded(surveys[0].id);
            Assert.IsNotNull(detailsExpanded.pages);
            Thread.Sleep(500);

            List<Page> pages = await Surveys.GetSurveyPages(surveys[0].id);
            Assert.AreNotEqual(0, pages.Count);
            Thread.Sleep(500);

            Page page = await Surveys.GetSurveyPageDetails(surveys[0].id, pages[0].id);
            Assert.IsNotNull(page);
            Thread.Sleep(500);

            List<Question> questions = await Surveys.GetSurveyPageQuestions(surveys[0].id, pages[0].id);
            Assert.AreNotEqual(0, questions.Count);
            Thread.Sleep(500);

            Question questionDetails = await Surveys.GetSurveyPageQuestionDetails(surveys[0].id, pages[0].id, questions[0].id);
            Assert.IsNotNull(questionDetails);
            Thread.Sleep(500);

        }
    }
}
