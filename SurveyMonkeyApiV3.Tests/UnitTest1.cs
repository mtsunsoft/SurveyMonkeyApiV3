using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyMonkeyApiV3.Models;
using SurveyMonkeyApiV3.Services;

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

            List<Survey> surveys = await SurveyService.GetSurveys();
            Assert.IsNotNull(surveys);

        }
    }
}
