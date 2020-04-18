using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class TabMdv
    {
        public int ID { get; set; }
        public string MDVDOCNAM { get; set; }
        public int? MDVDOCIDN { get; set; }
        public int MDVFRM { get; set; }
        public string MDVOPR { get; set; }
        public int? MDVNNN { get; set; }
        public int? MDVNUM { get; set; }
        public DateTime MDVDAT { get; set; }
        public int MDVKOD { get; set; }
        public TabMat TabMat { get; set; }
        public string MDVDEB { get; set; }
        public int? MDVDEBSPR { get; set; }
        public int? MDVDEBSPRVAL { get; set; }
        public string MDVKRD { get; set; }
        public int? MDVKRDSPR { get; set; }
        public int? MDVKRDSPRVAL { get; set; }
        public double? MDVKOL { get; set; }
        public double? MDVSUM { get; set; }
        public double? MDVRAB { get; set; }
        public DateTime? MDVTIM { get; set; }
        public int? MDVBUX { get; set; }
        public DateTime? MDVWWWEND { get; set; }
        public string MDVWWWTEL { get; set; }
        public string MDVWWWEML { get; set; }
        public string MDVWWWADR { get; set; }
        public bool? MDVWWWUPS { get; set; }
    }
}
