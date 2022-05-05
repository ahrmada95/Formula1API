using System;
using System.Collections.Generic;

namespace formula1.Models
{
    public partial class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Number { get; set; }
        public string? Team { get; set; }
        public string? CarId { get; set; }
    }
}
