using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsTrackingApp.Models
{
    public class HaberViewModel
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string HaberBaslik { get; set; }
        public string HaberIcerik { get; set; }
        public string Tbl_Kategori { get; set; }
        public string KategoriAdi { get; set; }

    }
}