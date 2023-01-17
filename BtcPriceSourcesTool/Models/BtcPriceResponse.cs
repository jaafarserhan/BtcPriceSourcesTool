namespace BtcPriceSourcesTool.Models
{
    public class BtcPriceResponse
    {
        public int ID { get; set; }
        public string Response { get; set; }
        public DateTime responseDateTime = DateTime.Now;
        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
