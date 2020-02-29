using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Feature.Hackathon.Globals.Models
{
    public class HeaderViewModel : RenderingModel
    {
        public IEnumerable<Item> NavigationLinks { get; set; }
    }
}