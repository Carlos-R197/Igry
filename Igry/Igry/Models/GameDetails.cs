using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace Igry.Models
{
    public class GameDetails
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_original")]
        public string NameOriginal { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metacritic")]
        public int? Metacritic { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("tba")]
        public bool Tba { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImage { get; set; }

        [JsonProperty("background_image_additional")]
        public string BackgroundImageAdditional { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("rating_top")]
        public int? RatingTop { get; set; }

        [JsonProperty("ratings")]
        public IList<Rating> Ratings { get; set; }

        [JsonProperty("added")]
        public int Added { get; set; }

        [JsonProperty("added_by_status")]
        public AddedByStatus AddedByStatus { get; set; }

        [JsonProperty("playtime")]
        public int Playtime { get; set; }

        [JsonProperty("screenshots_count")]
        public int ScreenshotsCount { get; set; }

        [JsonProperty("movies_count")]
        public int MoviesCount { get; set; }

        [JsonProperty("creators_count")]
        public int CreatorsCount { get; set; }

        [JsonProperty("achievements_count")]
        public int AchievementsCount { get; set; }

        [JsonProperty("parent_achievements_count")]
        public int ParentAchievementsCount { get; set; }

        [JsonProperty("reddit_url")]
        public string RedditUrl { get; set; }

        [JsonProperty("reddit_name")]
        public string RedditName { get; set; }

        [JsonProperty("reddit_description")]
        public string RedditDescription { get; set; }

        [JsonProperty("reddit_logo")]
        public string RedditLogo { get; set; }

        [JsonProperty("reddit_count")]
        public int RedditCount { get; set; }

        [JsonProperty("twitch_count")]
        public int TwitchCount { get; set; }

        [JsonProperty("youtube_count")]
        public int YoutubeCount { get; set; }

        [JsonProperty("reviews_text_count")]
        public int ReviewsTextCount { get; set; }

        [JsonProperty("ratings_count")]
        public int RatingsCount { get; set; }

        [JsonProperty("suggestions_count")]
        public int SuggestionsCount { get; set; }

        [JsonProperty("alternative_names")]
        public IList<string> AlternativeNames { get; set; }

        [JsonProperty("metacritic_url")]
        public string MetacriticUrl { get; set; }

        [JsonProperty("parents_count")]
        public int ParentsCount { get; set; }

        [JsonProperty("additions_count")]
        public int AdditionsCount { get; set; }

        [JsonProperty("game_series_count")]
        public int GameSeriesCount { get; set; }

        [JsonProperty("user_game")]
        public object UserGame { get; set; }

        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }

        [JsonProperty("saturated_color")]
        public string SaturatedColor { get; set; }

        [JsonProperty("dominant_color")]
        public string DominantColor { get; set; }

        [JsonProperty("parent_platforms")]
        public IList<ParentPlatform> ParentPlatforms { get; set; }

        [JsonProperty("platforms")]
        public IList<Platform> Platforms { get; set; }

        [JsonProperty("stores")]
        public IList<Store> Stores { get; set; }

        [JsonProperty("developers")]
        public IList<Developer> Developers { get; set; }

        [JsonProperty("genres")]
        public IList<Genre> Genres { get; set; }

        [JsonProperty("tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("publishers")]
        public IList<Publisher> Publishers { get; set; }

        [JsonProperty("esrb_rating")]
        public EsrbRating EsrbRating { get; set; }

        [JsonProperty("clip")]
        public Clip Clip { get; set; }

        [JsonProperty("description_raw")]
        public string DescriptionRaw { get; set; }
    }

}
