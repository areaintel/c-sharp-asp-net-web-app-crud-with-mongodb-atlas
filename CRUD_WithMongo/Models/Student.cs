﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_WithMongo.Models
{
    public class Student
    {
        public Object _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
    }
}