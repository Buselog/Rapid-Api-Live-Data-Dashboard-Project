namespace RapidAPIProject.Models
{
    public class NewsViewModel
    {
            public Response response { get; set; }

        public class Response
        {
            public string next_initial { get; set; }
            public int restResults { get; set; }
            public string next_country { get; set; }
            public int totalResults { get; set; }
            public string next_final { get; set; }
            public string next_category { get; set; }
            public Datum[] data { get; set; }
            public string next_query { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string site_region { get; set; }
            public string site_language { get; set; }
            public string author { get; set; }
            public string domain { get; set; }
            public long crawled { get; set; }
            public string language { get; set; }
            public string title { get; set; }
            public string site_type { get; set; }
            public string text { get; set; }
            public string url { get; set; }
            public string site { get; set; }
            public string site_country { get; set; }
            public DateTime published { get; set; }
        }

    }
}
