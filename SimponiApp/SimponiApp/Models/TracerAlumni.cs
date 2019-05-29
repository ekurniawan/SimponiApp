using System;
using System.Collections.Generic;
using System.Text;

namespace SimponiApp.Models
{
    public class TracerAlumni
    {
        public string ID_PERTANYAAN { get; set; }
        public string ID_SURVEY { get; set; }
        public string PERTANYAAN { get; set; }
        public string TIPE_JAWABAN { get; set; }
        public string IS_PUBLISHED { get; set; }
    }

    public class ListTracerAlumni
    {
        public string STATUS { get; set; }
        public List<TracerAlumni> CONTENT { get; set; }
        public string MESSAGE { get; set; }
    }

    public class JawabanTracerAlumni
    {
        public string ID_PERTANYAAN { get; set; }
        public string PILIHAN { get; set; }
    }

    public class ListJawabanTracerAlumni
    {
        public string STATUS { get; set; }
        public List<JawabanTracerAlumni> CONTENT { get; set; }
        public string MESSAGE { get; set; }
    }

    public class TambahTracerAlumni
    {
        public string ID_PERTANYAAN { get; set; }
        public string ID_SURVEY { get; set; }
        public string ID_ALUMNI { get; set; }
        public string JAWABAN { get; set; }
        public string USERNAME { get; set; }
        public string INSERT_DATE { get; set; }
        public string IP_ADDRESS { get; set; }
    }

    public class SimpanTracerAlumni
    {
        public string STATUS { get; set; }
        public string CONTENT { get; set; }
        public string MESSAGE { get; set; }
    }
}
