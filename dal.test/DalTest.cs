﻿using System;
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
    }
}
