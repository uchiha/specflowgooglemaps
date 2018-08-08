using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITest.utilities
{
    public class RestUtils
    {
        private static RestClient rClient;
        private static RestRequest rReq;
        private static IRestResponse rResp;

        public static RestClient RestClientUsed
        {
            get
            {
                return rClient;
            }
        }

        public static RestRequest RestRequestUsed
        {
            get
            {
                return rReq;
            }
        }

        public static IRestResponse RestResponseGen
        {
            get
            {
                return rResp;
            }
        }

        public static void SetClient(string clientUri)
        {
            rClient =  new RestClient(clientUri);
        }

        public static void SetRestRequest(string handle, string methodType)
        {
            Method metho = Method.GET;

            switch (methodType)
            {
                case "get":
                    metho = Method.GET;
                    break;
                case "post":
                    metho = Method.POST;
                    break;
                default:
                    metho = Method.COPY;
                    break;
            }

            rReq = new RestRequest(handle, metho);
        }

        public static void ExecuteRequest()
        {
            rResp = RestClientUsed.Execute(RestRequestUsed);
        }

        public static void AddParamRestReq(RestRequest req, string key, string value)
        {
            req.AddParameter(key, value);
        }

        public static bool Verify_ResultCount(int expected)
        {
            bool isCorrect = false;
            JObject joResponse = JObject.Parse(rResp.Content);
            JArray array = (JArray)joResponse["results"];
            System.Console.WriteLine(">>>>>: \"" + array.Count + "\"");
            if (array.Count == expected)
            {
                isCorrect = true;
            }

            return isCorrect;
        }
    }
}
