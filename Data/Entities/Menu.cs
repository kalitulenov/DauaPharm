using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public int MnuBarNum { get; set; }
        public string MnuBarKod { get; set; }
        public string MnuBarPrn { get; set; }
        public string MnuBarTxt { get; set; }
        public string MnuBarUrl { get; set; }
        public bool MnuBarFlg { get; set; }
    }
}
