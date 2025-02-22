﻿using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using DataAccessLayer.Functions.Specific;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Students;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Models.Subject;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Subject_Service : ISubject_Service
    {
        private ICRUD _crud = new CRUD();
        private ISubjectSpecific _iss = new SubjectSpecific();

        public async Task<Generic_ResultSet<Subject_ResultSet>> GetSubjectBySubjectId(int subject_id)
        {
            Generic_ResultSet<Subject_ResultSet> result = new Generic_ResultSet<Subject_ResultSet>();
            try
            {
                //GET subject FROM DB
                Subject subject = await _crud.Read<Subject>(subject_id);

                //MANUAL MAPPING OF RETURNED subject VALUES TO OUR subject_ResultSet
                Subject_ResultSet subjectReturned = new Subject_ResultSet
                {
                    subject_id = subject.Subject_Id,
                    subject_name = subject.Subject_name,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetSybjectIdBySubjectName() method executed successfully.";
                result.result_set = subjectReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This subject doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<List<Subject_ResultSet>>> GetSubjects()
        {
            Generic_ResultSet<List<Subject_ResultSet>> result = new Generic_ResultSet<List<Subject_ResultSet>>();

            try
            {
                var subjects = await _crud.ReadAll<Subject>();

                result.result_set = new List<Subject_ResultSet>();
                subjects.ForEach(s =>
                {
                    {
                        result.result_set.Add(new Subject_ResultSet
                        {
                            subject_id = s.Subject_Id,
                            subject_name = s.Subject_name,
                        });
                    }
                });

                result.userMessage = string.Format("s");
                result.internalMessage = "GetSybjects() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This subject doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Subject_ResultSet>>> GetSubjectsByStudentId(int student_id)
        {
            Generic_ResultSet<List<Subject_ResultSet>> result = new Generic_ResultSet<List<Subject_ResultSet>>();

            try
            {
                var subjects = await _iss.SubjectsOfStudent(student_id);

                result.result_set = new List<Subject_ResultSet>();
                subjects.ForEach(s =>
                {
                    {
                        result.result_set.Add(new Subject_ResultSet
                        {
                            subject_id = s.Subject_Id,
                            subject_name = s.Subject_name,
                        });
                    }
                });

                result.userMessage = string.Format("s");
                result.internalMessage = "GetSybjectIdBySubjectName() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This subject doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Subject_ResultSet>> DeleteSubjectByStudent(int student_id, int subject_id)
        {
            Generic_ResultSet<Subject_ResultSet> result = new Generic_ResultSet<Subject_ResultSet>();

            try
            {
                var isDeleted = await _iss.DeleteSubjectFromStudent(student_id,subject_id);
                if (isDeleted)
                {
                    result.success = true;
                }
                else
                {
                    result.success = false;
                }

                result.userMessage = string.Format("s");
                result.internalMessage = "DeleteSubjectByStudent() method executed successfully.";
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This subject doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<Subject_ResultSet>> AddSubjectToStudent(int student_id,int subject_id)
        {
            Generic_ResultSet<Subject_ResultSet> result = new Generic_ResultSet<Subject_ResultSet>();
            try
            {
                
                var subject = await _iss.AddSubjectToStudent(student_id,subject_id);

                //MANUAL MAPPING OF RETURNED subject VALUES TO OUR subject_ResultSet
                if (subject != null)
                {
                    Subject_ResultSet subjectReturned = new Subject_ResultSet
                    {
                        subject_id = subject.Subject_Id,
                    };
                    result.result_set = subjectReturned;
                }

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "GetSybjectIdBySubjectName() method executed successfully.";
                
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This subject doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}