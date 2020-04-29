using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class SprBux
    {
        public int Id { get; set; }
        public int BuxKod { get; set; }
        public int BuxTab { get; set; }
        public int BuxFrm { get; set; }
        public string BuxLog { get; set; }
        public string BuxPsw { get; set; }
        public string BuxKey { get; set; }
        public int BuxDlg { get; set; }
        public bool? BuxMol { get; set; }
        public bool? BuxUbl { get; set; }

    }
}
