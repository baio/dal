using CsQuery;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Xml.Linq;

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
                WebClient twitter = new WebClient();

                var str = twitter.DownloadString(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=dataavail&count=2&include_rts=1"));

                XElement xmlTweets = XElement.Parse(str);

                var r = xmlTweets.Descendants("status").Select(p => {
                    var tweet = p.Element("retweeted_status");
                    if (tweet == null)
                        tweet = p;
                    return new TwitModel { Text = tweet.Element("text").Value.ToHtml(), Name = tweet.Element("user").Element("name").Value };
                }).ToArray();

                cache.Add("ReadTwits", r, null, DateTime.MaxValue, new TimeSpan(ReadTwitCacheTimeOut, 0, 0), CacheItemPriority.Default, null);

                return r;
                
            }
        }


    }
}