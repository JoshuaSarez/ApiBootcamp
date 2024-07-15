namespace EjemploEntity.DTOs
{
    // ChuckNorrisCategDto myDeserializedClass = JsonConvert.DeserializeObject<ChuckNorrisCategDto>(myJsonResponse);
    public class ChuckNorrisCategDto
    {
        public int total { get; set; }
        public List<ChuckNorrisCategDtoList> result { get; set; }
    }

    // ChuckNorrisCategDtoList myDeserializedClass = JsonConvert.DeserializeObject<ChuckNorrisCategDtoList>(myJsonResponse);
    public class ChuckNorrisCategDtoList
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }


}
