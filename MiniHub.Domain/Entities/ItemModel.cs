using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Domain.Entities
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<TagModel> Tags { get; set; }

    }   
}
