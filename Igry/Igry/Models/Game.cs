using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Game : BaseModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("tba")]
        public bool Tba { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImage { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("rating_top")]
        public int RatingTop { get; set; }

        [JsonProperty("ratings")]
        public IList<Rating> Ratings { get; set; }

        [JsonProperty("ratings_count")]
        public int RatingsCount { get; set; }

        [JsonProperty("reviews_text_count")]
        public int ReviewsTextCount { get; set; }

        [JsonProperty("added")]
        public int Added { get; set; }

        [JsonProperty("added_by_status")]
        public AddedByStatus AddedByStatus { get; set; }

        [JsonProperty("metacritic")]
        public int? Metacritic { get; set; }

        [JsonProperty("playtime")]
        public int Playtime { get; set; }

        [JsonProperty("suggestions_count")]
        public int SuggestionsCount { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("user_game")]
        public object UserGame { get; set; }

        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }

        [JsonProperty("saturated_color")]
        public string SaturatedColor { get; set; }

        [JsonProperty("dominant_color")]
        public string DominantColor { get; set; }

        [JsonProperty("platforms")]
        public IList<Platform> Platforms { get; set; }

        [JsonProperty("parent_platforms")]
        public IList<ParentPlatform> ParentPlatforms { get; set; }

        [JsonProperty("genres")]
        public IList<Genre> Genres { get; set; }

        [JsonProperty("stores")]
        public IList<Store> Stores { get; set; }

        [JsonProperty("clip")]
        public Clip Clip { get; set; }

        [JsonProperty("tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("esrb_rating")]
        public EsrbRating EsrbRating { get; set; }

        [JsonProperty("short_screenshots")]
        public IList<ShortScreenshot> ShortScreenshots { get; set; }

    }
}
