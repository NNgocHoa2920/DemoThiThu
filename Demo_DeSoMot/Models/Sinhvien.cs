using System;
using System.Collections.Generic;

namespace Demo_DeSoMot.Models
{
    public partial class Sinhvien
    {
        public string Masv { get; set; } = null!;
        public string Ten { get; set; } = null!;
        public DateTime Ngaysinh { get; set; }
        public string Nganh { get; set; } = null!;
        public string? Malop { get; set; }

        public virtual Lophoc? MalopNavigation { get; set; }
    }
}
