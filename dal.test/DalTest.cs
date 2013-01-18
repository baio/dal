using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dal.test
{
    [TestClass]
    public class DalTest
    {
        [TestMethod]
        public void TestBlogFeedReader()
        {
            var r = Utils.ReadBlogFeed();
        }

        [TestMethod]
        public void TestTwitReader()
        {
            var r = Utils.ReadTweets();
        }
    }
}
