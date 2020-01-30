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
                item.ClassName != null && item.ClassName.Contains("lessons-item"));
            int i = 1;
            foreach (var element in items)
            {
                var imageUrl = element.Children.FirstOrDefault(item =>
                    item.HasAttribute("itemprop") && item.Attributes["itemprop"].Value == "thumbnail");

                var videoUrl = element.Children.FirstOrDefault(item =>
                    item.HasAttribute("itemprop") && item.Attributes["itemprop"].Value == "url");

                var fileName = element.Children.FirstOrDefault(item =>
                    item.HasAttribute("itemprop") && item.Attributes["itemprop"].Value == "name");

                var data = new ParsData()
                {
                    ImageUrl = imageUrl.GetAttribute("href"),
                    WideoUrl = videoUrl.GetAttribute("href"),
                    FileName = $"{i}_{fileName.InnerHtml.Trim()}"
                };
                list.Add(data);
                ++i;
            }

            return list.ToArray();
        }
    }
}