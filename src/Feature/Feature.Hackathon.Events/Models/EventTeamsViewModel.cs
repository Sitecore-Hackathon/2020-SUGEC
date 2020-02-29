using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Feature.Hackathon.Events.Models
{
    public class EventTeamsViewModel
    {
        public IEnumerable<Item> Teams { get; set; }
    }
}