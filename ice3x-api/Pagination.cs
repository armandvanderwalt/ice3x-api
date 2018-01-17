using Newtonsoft.Json;

namespace ice3x_api
{
    public class Pagination
    {
        [JsonProperty("items_per_page")]
        public long ItemsPerPage { get; set; }

        [JsonProperty("total_items")]
        public long TotalItems { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }
    }
}