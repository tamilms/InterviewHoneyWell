using System;
using System.Collections.Generic;

namespace XamarinInterviewTask.Models
{
    public class NewsHeadlinesModel
    {
        public List<Hit> hits { get; set; }
        public int nbHits { get; set; }
        public int page { get; set; }
        public int nbPages { get; set; }
        public int hitsPerPage { get; set; }
        public bool exhaustiveNbHits { get; set; }
        public string query { get; set; }
        public string @params { get; set; }
        public int processingTimeMS { get; set; }
    }

    public class Title
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public List<object> matchedWords { get; set; }
    }

    public class Url
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public List<object> matchedWords { get; set; }
    }

    public class Author
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public List<object> matchedWords { get; set; }
    }

    public class StoryText
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public List<object> matchedWords { get; set; }
    }

    public class HighlightResult
    {
        public Title title { get; set; }
        public Url url { get; set; }
        public Author author { get; set; }
        public StoryText story_text { get; set; }
    }

    public class Hit
    {
        public DateTime created_at { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public int points { get; set; }
        public string story_text { get; set; }
        public object comment_text { get; set; }
        public int num_comments { get; set; }
        public object story_id { get; set; }
        public object story_title { get; set; }
        public object story_url { get; set; }
        public object parent_id { get; set; }
        public int created_at_i { get; set; }
        public List<string> _tags { get; set; }
        public string objectID { get; set; }
        public HighlightResult _highlightResult { get; set; }
    }
}
