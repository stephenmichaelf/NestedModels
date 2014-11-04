using System.Collections.Generic;

namespace NestedModels.Models
{
    public class PageViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ZoneViewModel> Zones { get; set; } 
    }

    public class ZoneViewModel
    {
        public string Name { get; set; }
        public IEnumerable<WidgetViewModel> Widgets { get; set; } 
    }

    public class WidgetViewModel
    {
        public string Name { get; set; }
    }
}