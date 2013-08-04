using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteligenciaDigital.SAJ.Web.Models
{
    public class Page
    {
        public List<object> rows  { get; set;}
        public int page { get; set;}
        public int records { get; set;}
        public int total { get; set;}
    }
}