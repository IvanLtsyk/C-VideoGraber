using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace ParserCore.BL.coursehunters
{
    public class CourseHunterParser : IParser<ParsData[]>
    {
        public ParsData[] Parse(IHtmlDocument document)
        {
            var list = new List<ParsData>();
            var items = document.QuerySelectorAll("li").Where(item =>
                item.ClassName != null && item.ClassName.Contains("lessons-list__li"));
            foreach (var element in items)
            {
                var imageUrl = element.Children.FirstOrDefault(item =>
                    item.HasAttribute("itemprop") && item.Attributes["itemprop"].Value == "thumbnailUrl");

                var videoUrl = element.Children.FirstOrDefault(item =>
                    item.HasAttribute("itemprop") && item.Attributes["itemprop"].Value == "contentUrl");

                var data = new ParsData()
                {
                    ImageUrl = imageUrl.GetAttribute("href"),
                    WideoUrl = videoUrl.GetAttribute("href")
                };
                list.Add(data);
            }

            return list.ToArray();
        }
    }
}