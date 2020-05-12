using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class SprKdr
    {
        public int Id { get; set; }
        public int KdrFrm { get; set; }
        public int KdrKod { get; set; }
        public string KdrIin { get; set; }
        public string KdrFam { get; set; }
        public string KdrIma { get; set; }
        public string KdrOtc { get; set; }
        public string KdrFio { get; set; }
        public bool? KdrSex { get; set; }
        public DateTime? KdrBrt { get; set; }
        public string? KdrDnn { get; set; }
        public DateTime? KdrDdt { get; set; }
        public string KdrDpl { get; set; }
        public string KdrThn { get; set; }
        public int KdrKodSup { get; set; }
        public bool? KdrUbl { get; set; }
    }
}
