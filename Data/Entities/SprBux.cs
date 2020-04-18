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
        public string BuxFrmTxt { get; set; }
        public string BuxLog { get; set; }
        public string BuxPsw { get; set; }
        public DateTime? BuxInp { get; set; }
        public DateTime? BuxOut { get; set; }
        public int BuxWho { get; set; }
        public string BuxMnu { get; set; }
        public DateTime? BuxBegDat { get; set; }
        public DateTime? BuxEndDat { get; set; }
        public int BuxDlg { get; set; }
        public bool? BuxUbl { get; set; }
        public bool? BuxAcc { get; set; }
        public bool? BuxTrp { get; set; }
        public bool? BuxPed { get; set; }

    }
}
