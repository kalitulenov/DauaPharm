using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class SprBuxMnu
    {
        public int Id { get; set; }
        public int MnuBarNum { get; set; }
        public string MnuBarKod { get; set; }
        public int? MnuBarPrn { get; set; }
        public string? MnuBarTxt { get; set; }
        public string MnuBarUrl { get; set; }
        public bool? MnuBarFlg { get; set; }
        public bool MnuBarCld { get; set; }
        //public int? ParentId { get; set; }
    }
}
