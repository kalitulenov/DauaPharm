using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class TabMat
    {
        public int ID { get; set; }
        public string MATPRXDOCNAM { get; set; }
        public int? MATPRXDOCIDN { get; set; }
        public int MATFRM { get; set; }
        public int MATKOD { get; set; }
        public int? MATNUMART { get; set; }
        public string MATNAM { get; set; }
        public string MATEDN { get; set; }
        public string MATEDNNAM { get; set; }
        public double? MATZEN { get; set; }
        public int? MATGRP { get; set; }
        public string MATMEM { get; set; }
        public int? MATVOC { get; set; }
        public string MATAMRGRP { get; set; }
        public DateTime? MATDATVVV { get; set; }
        public string MATIZGKTO { get; set; }
        public string MATDATIZG { get; set; }
        public string MATNUMIZG { get; set; }
        public string MATNOMNUM { get; set; }
        public string MATSRKSLB { get; set; }
        public double? MATBUXPRO { get; set; }
        public double? MATBUXOCT { get; set; }
        public int? MATMRK { get; set; }
        public int? MATOTV { get; set; }
        public bool? MATFLG { get; set; }
        public DateTime? MATTIM { get; set; }
        public double? MATZENOLD { get; set; }
        public string MATKNF { get; set; }
    }
}
