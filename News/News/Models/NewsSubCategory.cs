using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsSubCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int NewsCategoryId { get; set; }
        [ForeignKey("NewsCategoryId")]
        public NewsCategory NewsCategory { get; set; }

        public List<News> News { get; set; }
    }
    //public class Cata
    //{
    //    public int Id { get; set; }
    //    public string    Name { get; set; }
    //    public int? UstId { get; set; }

    //}

    ///*
    // -1 AnaKategori (UstId NUll)
    //       -3 altKategori (ustid 1) 
    //            -4 altkate (usti 3)
    //            -5 alt kat (ust 3)
    // -2 IkinciANaKategori (UstId Null)
     
     
    // */
}
