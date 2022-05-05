using System;
using System.Collections.Generic;

namespace formula1.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string CarId { get; set; } = null!;
        public string? Team { get; set; }
        public int? Year { get; set; }
    }
}
