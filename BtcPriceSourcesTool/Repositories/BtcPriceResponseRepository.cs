using BtcPriceSourcesTool.Contracts;
using BtcPriceSourcesTool.Models;
using System.Net;

namespace BtcPriceSourcesTool.Repositories
{
    public class BtcPriceResponseRepository : IBtcPriceResponseRepository
    {
        private BtcPriceSourcesDbContext ctx;

        public BtcPriceResponseRepository()
        {
            ctx = ConfigureDbContext.Context;
        }

        public void Dispose()
        {
            try
            {
                GC.Collect();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BtcPriceResponse>> GetBtcHistoryBySourceId( int SourceID)
        {          
            return ctx.BtcPriceResponses.Where(s=>s.SourceId== SourceID).ToList();
        }


        public async Task<BtcPriceResponse> GetBtcPriceBySourceId(int SourceID)
        {
            try
            {
                BtcPriceResponse BPR = new BtcPriceResponse();
                Source src = new Source();
                src = ctx.Sources.Where(s => s.SourceId == SourceID).FirstOrDefault();
                string res = await GetBtcResponseFromSource(src.SourceURI);

                // BtcPriceResponse BPR = new BtcPriceResponse();
                BPR.Response = res;
                BPR.SourceId = SourceID;
                BPR.Source = src;//ctx.Sources.Where(s => s.SourceId == SourceID).FirstOrDefault();
                
                ctx.BtcPriceResponses.Add(BPR);
                ctx.SaveChangesAsync();  
                
                return BPR;
            
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<String> GetBtcResponseFromSource(string url) {
            //var url = "https://www.bitstamp.net/api/v2/ticker/btcusd";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Headers["Content-Length"] = "0";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }

        }
    }
}
