using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dal.Models
{
    public class ProjectSummaryModel
    {
        public string Company { get; set; }

        public string WebsiteCaption { get; set; }

        public string WebsiteUrl { get; set; }

        public string SourceCaption { get; set; }

        public string SourceUrl { get; set; }

        public string Features { get; set; }

        public string Challenges { get; set; }

        public int Duration { get; set; }

        public string [] Team { get; set; }
    }
}