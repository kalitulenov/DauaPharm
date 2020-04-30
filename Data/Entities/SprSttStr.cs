using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data.Entities
{
    public class SprSttStr
    {
        public int Id { get; set; }
        public int SttStrFrm { get; set; }
        public int SttStrLvl { get; set; }
        public string SttStrKey { get; set; }
        public int SttStrKod { get; set; }
        public string SttStrNam { get; set; }
        public string SttStrAbc { get; set; }
        public bool? SttStrFlg { get; set; }
    }
}
