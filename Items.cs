﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_API
{
    public class ItemsDatum
    {
        public List<string> games { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string id { get; set; }
    }

    public class ItemsRoot
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<ItemsDatum> data { get; set; }
    }

}