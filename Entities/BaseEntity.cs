using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
