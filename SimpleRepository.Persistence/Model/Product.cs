using SimpleRepository.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRepository.Persistence.Model
{

    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}
