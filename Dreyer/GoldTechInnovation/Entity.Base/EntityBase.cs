using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Base
{
    public class EntityBase
    {
        [Key]
        public string Id { get; set; }
    }
}
