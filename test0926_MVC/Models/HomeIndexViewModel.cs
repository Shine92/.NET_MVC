using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test0926_MVC.Models {
    public class HomeIndexViewModel {
        public int id { get; set; }
        public string charData { get; set; }
        public Nullable<int> intData { get; set; }
        public string intDataName { get; set; }
    }
}