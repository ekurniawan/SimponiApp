using System;
using System.Collections.Generic;
using System.Text;

//
namespace SimponiApp.Models
{
    public class Lowongan
    {
        public string ID_LOWONGAN_KERJA { get; set; }
        public string PERUSAHAAN { get; set; }
        public string TGL_SELESAI { get; set; }
    }

    public class ListLowongan
    {
        public string STATUS { get; set; }
        public List<Lowongan> CONTENT { get; set; }
        public string MESSAGE { get; set; }
    }
}
