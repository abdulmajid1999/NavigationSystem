using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace navitem.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public NavigationItem Parent { get; set; }
        public ICollection<NavigationItem> Children { get; set; } = new List<NavigationItem>();
    }
}
