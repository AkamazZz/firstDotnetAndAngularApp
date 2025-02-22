﻿using System;
using BusinessLogicLayer.Services.Models.Students;
using BusinessLogicLayer.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IStudent_Service   
    {
        Task<Generic_ResultSet<Student_ResultSet>> GetTopOfStudents();
        Task<Generic_ResultSet<Student_ResultSet>> GetNameAndSurnameByStudentId(int student_id);
        Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfFaculty(int faculty_id);
        Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfSpecilaity(int speciliaty_id);
        Task<Generic_ResultSet<Student_ResultSet>> GetGroupIdByStudentId(int student_id);
        Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudentOfGroup(int group_id);
        Task<Generic_ResultSet<Student_ResultSet>> DeleteStudent(int student_id);
        Task<Generic_ResultSet<Student_ResultSet>> UpdateStudent(int student_id, int faculty_id, int speciality_id, int group_id, string name, string surname);

        Task<Generic_ResultSet<Student_ResultSet>> AddSingleStudent(int speciality_id, int faculty_id, int group_id, string name, string surname);

        //Task<Generic_ResultSet<Student_ResultSet>> EditStudent();
        Task<Generic_ResultSet<List<Student_ResultSet>>> GetAllStudents();
        Task<Generic_ResultSet<Student_ResultSet>> GetStudentByFullName(string name, string surname); 



    }
}
