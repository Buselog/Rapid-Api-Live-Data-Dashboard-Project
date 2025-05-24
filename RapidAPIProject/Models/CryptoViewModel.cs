namespace RapidAPIProject.Models
{
    public class CryptoViewModel
    {
            public int error { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        public class Data
        {
            public string from { get; set; }
            public string to { get; set; }
            public int amount { get; set; }
            public string value { get; set; }
        }

    }
}
