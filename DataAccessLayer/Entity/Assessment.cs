﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    class Assessment
    {
        public int Assessment_Id {get;set;}
        public int Student_Id {get;set;}
        public int Subject_Id {get;set;}
        public int Grade {get;set;}

        public Subject Subject { get; set; }

        public Stunde
    }
}
