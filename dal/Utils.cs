using CsQuery;
using dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Caching;
using System.Xml;

namespace dal
{
    public static class Utils
    {
        public static string ReadBlogFeedUri = "http://data-avail.blogspot.com/feeds/posts/default?alt=rss";
        public static int ReadBlogFeedCacheTimeOut = 6;

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
    }
}