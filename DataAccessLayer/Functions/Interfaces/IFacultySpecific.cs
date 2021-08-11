﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IFacultySpecific
    {

        public Task<Dictionary<int, double>> GetTopFromFaculty(int faculty_id);

    }
}
