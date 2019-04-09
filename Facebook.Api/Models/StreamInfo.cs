namespace Facebook.Api.Models
{
    using System.Collections.Generic;

    public class StreamInfo
    {
        public string id { get; set; }
        public IEnumerable<IngestStreams> ingest_streams { get; set; }
    }
}
