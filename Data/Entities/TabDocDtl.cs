using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class TabDocDtl
    {
        public int ID { get; set; }
        public int DTLNNN { get; set; }
        public string DTLOPR { get; set; }
        public int DTLNUM { get; set; }
        public DateTime? DTLDAT { get; set; }
        public int DTLDEBSPRVAL { get; set; }
        public int DTLDEBOBR { get; set; }
        public string DTLNAM { get; set; }
        public double? DTLKOL { get; set; }
        public string DTLEDN { get; set; }
        public double? DTLZEN { get; set; }
        public double? DTLSUM { get; set; }
        public bool? DTLNDC { get; set; }
        public int DTLSUMNDC { get; set; }
        public int DTLGRP { get; set; }
        public string DTLMEM { get; set; }
        public string DTLDOCNUM { get; set; }
        public int DTLDOCIDN { get; set; }
        public int DTLKRDSPRVAL { get; set; }
        public int DTLKRDOBR { get; set; }
        public string DTLIZG { get; set; }
        public string DTLDATIZG { get; set; }
        public string DTLNUMIZG { get; set; }
        public string DTLNOMNUM { get; set; }
        public DateTime? DTLSRKSLB { get; set; }
        public int DTLMRK { get; set; }
        public DateTime? DTLTIM { get; set; }
        public bool? DTLFLG { get; set; }
        public int vDTLBUX { get; set; }

    }
}
