using System;
using System.Collections.Generic;
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
            SurveyMonkey.AuthToken = "";
            SurveyMonkey.ApiKey = "";

            List<Survey> surveys = await Surveys.GetSurveys();
            Assert.IsNotNull(surveys);

        }
    }
}
