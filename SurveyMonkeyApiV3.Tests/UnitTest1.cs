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

            SurveyDetails details = await Surveys.GetSurveyDetails(surveys[0].id);
            Assert.IsNotNull(details);

            SurveyDetails detailsExpanded = await Surveys.GetSurveyDetailsExpanded(surveys[0].id);
            Assert.IsNotNull(detailsExpanded.pages);


            List<Page> pages = await Surveys.GetSurveyPages(surveys[0].id);
            Assert.AreNotEqual(0, pages.Count);

            Page page = await Surveys.GetSurveyPageDetails(surveys[0].id, pages[0].id);
            Assert.IsNotNull(page);


            List<Question> questions = await Surveys.GetSurveyPageQuestions(surveys[0].id, pages[0].id);
            Assert.AreNotEqual(0, questions.Count);


            Question questionDetails = await Surveys.GetSurveyPageQuestionDetails(surveys[0].id, pages[0].id, questions[0].id);
            Assert.IsNotNull(questionDetails);


            List<Collector> collectors = await Surveys.GetSurveyCollectors(surveys[0].id);
            Assert.AreNotEqual(0, collectors.Count);

            CreateMessage createMsg = new CreateMessage()
            {
                body_html = "[SurveyLink], [FooterLink] and [OptOutLink]",
                subject = "new survey",
                type = "invite",
                body_text = "[SurveyLink], [FooterLink] and [OptOutLink]",
                is_branding_enabled = false
            };

            Message message = await Collectors.CreateCollectorMessage(collectors[0].id, createMsg);
            Assert.IsNotNull(message);

            List<Message> messages = await Collectors.GetCollectorMessages(collectors[0].id);
            Assert.AreNotEqual(0, messages.Count);


        }
    }
}
