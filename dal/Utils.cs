using CsQuery;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Xml.Linq;
using TweetSharp;

namespace dal
{
    public static class Utils
    {
        public static string ReadBlogFeedUri = "http://data-avail.blogspot.com/feeds/posts/default?alt=rss";
        public static int ReadBlogFeedCacheTimeOut = 6;
        public static int ReadTwitCacheTimeOut = 1;

        public static IEnumerable<BlogFeedModel> ReadBlogFeed(bool Cached = true)
        {
            var cache = HttpRuntime.Cache;

            if (Cached && cache["ReadBlogFeed"] != null)
            {
                return (BlogFeedModel[])cache["ReadBlogFeed"];
            }
            else
            {
                using (var reader = XmlReader.Create(ReadBlogFeedUri))
                {
                    var r = SyndicationFeed.Load(reader).Items.Take(2).ToArray().Select(p => {
                        var dom = CQ.Create(p.Summary.Text);
                        var text = dom.Select("div").Text();
                        if (text.Length > 60)
                            text = text.Remove(60);
                        if (text.Length > 0)
                            text += "...";
                        return new BlogFeedModel
                        {
                            Title = p.Title.Text,
                            Text = !string.IsNullOrEmpty(text) ? text : p.Title.Text, 
                            Img = dom.Select("img:eq(0)").Attr("src"),
                            Link = p.Links.FirstOrDefault(x => x.RelationshipType == "alternate").Uri.AbsoluteUri,
                        };
                    }).ToArray();


                    cache.Add("ReadBlogFeed", r, null, DateTime.MaxValue, new TimeSpan(ReadBlogFeedCacheTimeOut, 0, 0), CacheItemPriority.Default, null);

                    return r;
                }
            }
        }

        public static IEnumerable<TwitModel> ReadTweets(bool Cached = true)
        {
            var cache = HttpRuntime.Cache;

            if (Cached && cache["ReadTwits"] != null)
            {
                return (TwitModel[])cache["ReadTwits"];
            }
            else
            {
                var service = new TwitterService(ConfigurationManager.AppSettings["TWITTER_CONSUMER_KEY"], ConfigurationManager.AppSettings["TWITTER_CONSUMER_SECRET"]);
                service.AuthenticateWith(ConfigurationManager.AppSettings["TWITTER_ACCESS_TOKEN"], ConfigurationManager.AppSettings["TWITTER_ACCESS_TOKEN_SECRET"]);

                var tweets = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { IncludeRts = true, Count = 2 });
                var r = tweets.Select(p => new TwitModel { Text = p.TextAsHtml, Name = p.Author.ScreenName }).ToArray();

                cache.Add("ReadTwits", r, null, DateTime.MaxValue, new TimeSpan(ReadTwitCacheTimeOut, 0, 0), CacheItemPriority.Default, null);

                return r;
                
            }
        }


    }
}