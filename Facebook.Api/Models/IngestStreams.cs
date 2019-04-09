namespace Facebook.Api
{
    public class IngestStreams
    {
        public string id { get; set; }
        public string stream_id { get; set; }
        public string stream_url { get; set; }
        public string secure_stream_url { get; set; }
        public bool is_master { get; set; }
        public string dash_preview_url { get; set; }
        public string dash_ingest_url { get; set; }
    }
}
