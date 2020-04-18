using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class TabDoc
    {
        public int ID { get; set; }
        public int DOCFRM { get; set; }
        public string DOCTYP { get; set; }
        public int DOCDAT { get; set; }
        public int DOCNUM { get; set; }
        public int DOCSPR { get; set; }
        public int DOCSPRVAL { get; set; }
        public double? DOCKOL { get; set; }
        public double? DOCSUM { get; set; }
        public int DOCFIO { get; set; }
        public string DOCACC { get; set; }
        public string DOCFIOPOL { get; set; }
        public string DOCMEM { get; set; }
        public bool? DOCFLGVIP { get; set; }
        public string DOCNUMVIP { get; set; }
        public string DOCDATVIP { get; set; }
        public DateTime? DOCTIM { get; set; }
        public DateTime? DOCTIMEND { get; set; }
        public int DOCBUX { get; set; }
        public bool? DOCFLG { get; set; }
        public ICollection<TabDocDtl> TabDocDtls { get; set; }

    }
}
