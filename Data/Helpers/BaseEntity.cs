using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Helpers
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
