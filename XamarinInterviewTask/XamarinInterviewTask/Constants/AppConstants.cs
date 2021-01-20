using System;
namespace XamarinInterviewTask.Constants
{
    public class AppConstants
    {
        public static string BASE_URL = "https://hn.algolia.com/api/v1/";
        public static string NewArticleFrontPage = "search?tags=front_page";
        public static string SearchTopic = "search?query={0}&page={1}";
    }
}
