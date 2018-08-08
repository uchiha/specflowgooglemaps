using APITest.utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace APITest.Specs
{
    [Binding]
    public class NearbyPlacesGoogleAPISteps
    {
        [Given(@"I am using the google maps api ""(.*)""")]
        public void GivenIAmUsingTheGoogleMapsApi(string p0)
        {
            RestUtils.SetClient(p0);
        }

        [Given(@"access to the ""(.*)"" resource with ""(.*)"" as a method")]
        public void GivenAccessToTheUtilityWithAsAMethod(string p0, string p1)
        {
            RestUtils.SetRestRequest(p0, p1);
        }

        [Given(@"I add parameter ""(.*)"" with value ""(.*)""")]
        public void GivenIAddParameterWithValue(string p0, string p1)
        {
            RestUtils.RestRequestUsed.AddParameter(p0, p1);
        }

        [When(@"I execute the said request")]
        public void WhenIExecuteTheSaidRequest()
        {
            RestUtils.ExecuteRequest();
        }

        [Then(@"I should have ""(.*)"" results")]
        public void ThenIShouldHaveResults(int p0)
        {
            Assert.AreEqual(true, RestUtils.Verify_ResultCount(p0), 
                "The results count obtained does not match with the expected.");
            
        }

    }
}
