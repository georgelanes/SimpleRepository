using System;

namespace SimpleRepository.Core.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
