using SimpleRepository.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRepository.Persistence.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
