using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace navitem.Models
{
    public class NavigationItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public List<NavigationItem> ParentItems { get; set; }
    }
}
