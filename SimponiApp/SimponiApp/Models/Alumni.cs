using System;
using System.Collections.Generic;
using System.Text;

namespace SimponiApp.Models
{
    public class Alumni
    {
        public string ID_ALUMNI { get; set; }
        public string NPM { get; set; }
        public string NAMA_MHS { get; set; }
        public string USERNAME { get; set; }
    }

    public class WrapperAlumni
    {
        public string STATUS { get; set; }
        public Alumni CONTENT { get; set; }
        public string MESSAGE { get; set; }
    }
}
