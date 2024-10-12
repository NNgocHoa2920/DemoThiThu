using System;
using System.Collections.Generic;

namespace Demo_DeSoMot.Models
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            Sinhviens = new HashSet<Sinhvien>();
        }

        public string Malop { get; set; } = null!;
        public string Tenlop { get; set; } = null!;

        public virtual ICollection<Sinhvien> Sinhviens { get; set; }
    }
}
