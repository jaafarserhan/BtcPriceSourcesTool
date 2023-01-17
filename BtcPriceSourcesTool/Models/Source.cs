namespace BtcPriceSourcesTool.Models
{
    public class Source
    {

        public int SourceId { get; set; }

        public string SourceName { get; set; }

        public string SourceURI { get; set; }

        public List<BtcPriceResponse> BtcPriceResponses { get; } = new();

    }
}
