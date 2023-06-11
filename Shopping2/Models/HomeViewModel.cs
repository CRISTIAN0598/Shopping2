using Shopping2.Common;
using Shopping2.Data.Entities;

namespace Shopping2.Models
{
    public class HomeViewModel
    {
        public PaginatedList<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public float Quantity { get; set; }

    }
}
