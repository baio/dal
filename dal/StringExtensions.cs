using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace dal
{
    public static class StringExtensions
    {
        private static string _link = "<a href=\"{0}\">{0}</a>";

        public static string ToHtml(this string str)
        {
            str = str.Replace("\n", "<br/> ");

            return string.Join(" ", str.Split(' ').Select(p => Uri.IsWellFormedUriString(p, UriKind.Absolute) ? string.Format(_link, p) : p));
        }

    }
}