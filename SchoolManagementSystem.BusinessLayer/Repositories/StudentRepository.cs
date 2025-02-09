using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SchoolManagementSystem.BusinessLayer.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentViewModel>> GetAllStudentList()
        {
            var student = await (from s in _context.Student
                                 join p in _context.StudentParentsDetails
                                 on s.StudentId equals p.StudentId into parents
                                 from p in parents.DefaultIfEmpty()
                                 where s.Status == true
                                 select new StudentViewModel
                                 {
                                     StudentId = s.StudentId,
                                     StudentUniqueId = s.StudentUniqueId,
                                     StudentName = s.StudentName,
                                     StudentName_Nep = s.StudentName_Nep,
                                     Gender = s.Gender,
                                     StudentImage = s.StudentImage,
                                     FatherCell = p != null ? p.FatherCell : null,
                                     MotherCell = p != null ? p.MotherCell : null
                                 }).ToListAsync() ?? new List<StudentViewModel>();

            return student;
        }

        public async Task<StudentViewModel> GetStudentById(int? id)
        {
            var student = await _context.Student.Where(x => x.StudentId == id).Select(x => new StudentViewModel()
            {
                StudentUniqueId = x.StudentUniqueId,
                StudentName = x.StudentName,
                StudentEmail = x.StudentName,
                StudentImage = x.StudentImage,
                StudentName_Nep = x.StudentName_Nep,
                StudentIDUnique = x.StudentUniqueId,
            }).FirstOrDefaultAsync() ?? new StudentViewModel();
            return student;
        }
        public async Task<bool> InsertUpdateStudent(StudentViewModel model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.StudentId > 0)
                    {
                        var studentId = model.StudentId;
                        var student = await _context.Student.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (student != null)
                        {
                            student.StudentId = model.StudentId;
                            student.StudentUniqueId = model.StudentUniqueId;
                            student.StudentName = model.StudentName;
                            student.StudentName_Nep = model.StudentName_Nep;
                            student.Gender = model.Gender;
                            student.DOB_AD = model.DOB_AD;
                            student.DOB_BS = model.DOB_BS;
                            student.BloodGroup = model.BloodGroup;
                            student.StudentImage = model.StudentImage;
                            student.PhoneNumber = model.PhoneNumber;
                            student.Nationality = model.Nationality;
                            student.Status = true;
                            student.AdmittedBy = model.AdmittedBy;
                            student.AdmittedDate = model.AdmittedDate;
                            student.CreateddBy = model.UpdatedBy;
                            student.CreatedDate = model.UpdatedDate;
                            student.DeletedBy = model.DeletedBy;
                            student.DeletedDate = model.DeletedDate;
                            _context.Entry(student).State = EntityState.Modified;
                        }
                        var parents = await _context.StudentParentsDetails.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (parents != null)
                        {
                            parents.StudentId = studentId;
                            //parents.Id = model.Id;
                            parents.FatherName = model.FatherName;
                            parents.FatherImage = model.FatherImage;
                            parents.FatherOccupation = model.FatherOccupation;
                            parents.FatherCell = model.FatherCell;
                            parents.FatherEmail = model.FatherEmail;
                            parents.MotherName = model.MotherName;
                            parents.MotherImage = model.MotherImage;
                            parents.MotherOccupation = model.MotherOccupation;
                            parents.MotherCell = model.MotherCell;
                            parents.MotherEmail = model.MotherEmail;
                            parents.GuardianName = model.GuardianName;
                            parents.GuardianRelation = model.GuardianRelation;
                            parents.GuardianImage = model.GuardianImage;
                            parents.GuardianCell = model.GuardianCell;
                            _context.Entry(parents).State = EntityState.Modified;
                        }
                        var accountInfo = await _context.StudentAccountInfo.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();

                        if (accountInfo != null)
                        {
                            //accountInfo.Id = model.Id;
                            accountInfo.LastInsertedId = model.LastInsertedId;
                            accountInfo.StudentIDUnique = model.StudentIDUnique;
                            accountInfo.StudentPreviousCode = model.StudentPreviousCode;
                            accountInfo.StudentEmail = model.StudentEmail;
                            accountInfo.BusRoute = model.BusRoute;
                            accountInfo.BusStop = model.BusStop;
                            accountInfo.BusRouteEvening = model.BusRouteEvening;
                            accountInfo.BusStopEvening = model.BusStopEvening;
                            _context.Entry(accountInfo).State = EntityState.Modified;
                        }
                        var address = await _context.StudentAddress.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (address != null)
                        {
                            //address.Id = model.Id;
                            address.StudentId = studentId;
                            address.PermanentProvince = model.PermanentProvince;
                            address.PermanentDistrict = model.PermanentDistrict;
                            address.PermanentMunicipality = model.PermanentMunicipality;
                            address.PermanentAddress = model.PermanentAddress;
                            address.CurrentProvince = model.CurrentProvince;
                            address.CurrentDistrict = model.CurrentDistrict;
                            address.CurrentMunicipality = model.CurrentMunicipality;
                            address.CurrentAddress = model.CurrentAddress;
                            _context.Entry(address).State = EntityState.Modified;
                        }
                        var academicInfo = await _context.StudentAcademicInfo.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (academicInfo != null)
                        {
                            //academicInfo.Id = model.Id;
                            academicInfo.StudentId = studentId;
                            academicInfo.Class = model.Class;
                            academicInfo.Section = model.Section;
                            academicInfo.AdmittedYear = model.AdmittedYear;
                            academicInfo.ClassRollNo = model.ClassRollNo;
                            academicInfo.SymbolNumber = model.SymbolNumber;
                            academicInfo.Team = model.Team;
                            academicInfo.Coaching = model.Coaching;
                            academicInfo.TransportationMode = model.TransportationMode;
                            academicInfo.TeaBreakfast = model.TeaBreakfast;
                            academicInfo.LunchSnacks = model.LunchSnacks;
                            academicInfo.Vegetarian = model.Vegetarian;
                            academicInfo.EnrollmentType = model.EnrollmentType;
                            academicInfo.IEMISNumber = model.IEMISNumber;
                            _context.Entry(academicInfo).State = EntityState.Modified;
                        }

                        var otherDetails = await _context.StudentOtherDetails.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (otherDetails != null)
                        {
                            //otherDetails.Id = model.Id;
                            otherDetails.StudentId = studentId;
                            otherDetails.Religion = model.Religion;
                            otherDetails.Ethnicity = model.Ethnicity;
                            otherDetails.Citizenship = model.Citizenship;
                            otherDetails.DifferentlyAbled = model.DifferentlyAbled;
                            otherDetails.UserCode = model.UserCode;
                            _context.Entry(otherDetails).State = EntityState.Modified;
                        }

                        var previousSchoolDetails = await _context.PreviousSchoolDetails.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                        if (previousSchoolDetails != null)
                        {
                            //previousSchoolDetails.Id = model.Id;
                            previousSchoolDetails.StudentId = studentId;
                            previousSchoolDetails.PreviousSchoolName = model.PreviousSchoolDetailsList.PreviousSchoolName;
                            previousSchoolDetails.PreviousSchoolLevel = model.PreviousSchoolDetailsList.PreviousSchoolLevel;
                            previousSchoolDetails.PreviousSchoolUniversity = model.PreviousSchoolDetailsList.PreviousSchoolUniversity;
                            previousSchoolDetails.PreviousSchoolType = model.PreviousSchoolDetailsList.PreviousSchoolType;
                            previousSchoolDetails.PreviousSchoolSymbolNumber = model.PreviousSchoolDetailsList.PreviousSchoolSymbolNumber;
                            previousSchoolDetails.PreviousSchoolRegistrationNumber = model.PreviousSchoolDetailsList.PreviousSchoolRegistrationNumber;
                            previousSchoolDetails.PreviousSchoolPassedYear = model.PreviousSchoolDetailsList.PreviousSchoolPassedYear;
                            previousSchoolDetails.PreviousSchoolPercentage = model.PreviousSchoolDetailsList.PreviousSchoolPercentage;
                            _context.Entry(previousSchoolDetails).State = EntityState.Modified;
                        }
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return true;
                    }
                    else
                    {
                        var student = new Student()
                        {
                            StudentId = model.StudentId,
                            StudentUniqueId = model.StudentUniqueId,
                            StudentName = model.StudentName,
                            StudentName_Nep = model.StudentName_Nep,
                            Gender = model.Gender,
                            DOB_AD = model.DOB_AD,
                            DOB_BS = model.DOB_BS,
                            BloodGroup = model.BloodGroup,
                            StudentImage = model.StudentImage,
                            PhoneNumber = model.PhoneNumber,
                            Nationality = model.Nationality,
                            Status = model.Status,
                            AdmittedBy = model.AdmittedBy,
                            AdmittedDate = model.AdmittedDate,
                            UpdatedBy = model.UpdatedBy,
                            UpdatedDate = model.UpdatedDate,
                            DeletedBy = model.DeletedBy,
                            DeletedDate = model.DeletedDate,
                        };
                        await _context.Student.AddAsync(student);
                        await _context.SaveChangesAsync();

                        var accountinfo = new Student_AccountInfo()
                        {
                            LastInsertedId = model.LastInsertedId,
                            StudentIDUnique = model.StudentIDUnique,
                            StudentPreviousCode = model.StudentPreviousCode,
                            StudentEmail = model.StudentEmail,
                            BusRoute = model.BusRoute,
                            BusStop = model.BusStop,
                            BusRouteEvening = model.BusRouteEvening,
                            BusStopEvening = model.BusStopEvening,
                        };
                        await _context.StudentAccountInfo.AddAsync(accountinfo);
                        var studentAddress = new Student_Address()
                        {
                            StudentId = student.StudentId,
                            PermanentProvince = model.PermanentProvince,
                            PermanentDistrict = model.PermanentDistrict,
                            PermanentMunicipality = model.PermanentMunicipality,
                            PermanentAddress = model.PermanentAddress,
                            CurrentProvince = model.CurrentProvince,
                            CurrentDistrict = model.CurrentDistrict,
                            CurrentMunicipality = model.CurrentMunicipality,
                            CurrentAddress = model.CurrentAddress,
                        };
                        await _context.StudentAddress.AddAsync(studentAddress);

                        var studentAcademicinfo = new Student_AcademicInfo()
                        {
                            StudentId = student.StudentId,
                            Class = model.Class,
                            Section = model.Section,
                            AdmittedYear = model.AdmittedYear,
                            ClassRollNo = model.ClassRollNo,
                            SymbolNumber = model.SymbolNumber,
                            Team = model.Team,
                            Coaching = model.Coaching,
                            TransportationMode = model.TransportationMode,
                            TeaBreakfast = model.TeaBreakfast,
                            LunchSnacks = model.LunchSnacks,
                            Vegetarian = model.Vegetarian,
                            EnrollmentType = model.EnrollmentType,
                            IEMISNumber = model.IEMISNumber,
                        };
                        await _context.StudentAcademicInfo.AddAsync(studentAcademicinfo);

                        var studentParentsDetails = new Student_ParentsDetails()
                        {
                            StudentId = student.StudentId,
                            FatherName = model.FatherName,
                            FatherImage = model.FatherImage,
                            FatherOccupation = model.FatherOccupation,
                            FatherCell = model.FatherCell,
                            FatherEmail = model.FatherEmail,
                            MotherName = model.MotherName,
                            MotherImage = model.MotherImage,
                            MotherOccupation = model.MotherOccupation,
                            MotherCell = model.MotherCell,
                            MotherEmail = model.MotherEmail,
                            GuardianName = model.GuardianName,
                            GuardianRelation = model.GuardianRelation,
                            GuardianImage = model.GuardianImage,
                            GuardianCell = model.GuardianCell,
                        };
                        await _context.StudentParentsDetails.AddAsync(studentParentsDetails);
                        var studentOtherDetails = new Student_OtherDetails()
                        {
                            StudentId = student.StudentId,
                            Religion = model.Religion,
                            Ethnicity = model.Ethnicity,
                            Citizenship = model.Citizenship,
                            DifferentlyAbled = model.DifferentlyAbled,
                            UserCode = model.UserCode,
                        };
                        await _context.StudentOtherDetails.AddAsync(studentOtherDetails);
                        if (model.PreviousSchoolDetailsList != null)
                        {
                            var previouschoolDetail = new PreviousSchoolDetails()
                            {
                                StudentId = student.StudentId,
                                PreviousSchoolName = model.PreviousSchoolDetailsList.PreviousSchoolName,
                                PreviousSchoolLevel = model.PreviousSchoolDetailsList.PreviousSchoolLevel,
                                PreviousSchoolUniversity = model.PreviousSchoolDetailsList.PreviousSchoolUniversity,
                                PreviousSchoolType = model.PreviousSchoolDetailsList.PreviousSchoolType,
                                PreviousSchoolSymbolNumber = model.PreviousSchoolDetailsList.PreviousSchoolSymbolNumber,
                                PreviousSchoolRegistrationNumber = model.PreviousSchoolDetailsList.PreviousSchoolRegistrationNumber,
                                PreviousSchoolPassedYear = model.PreviousSchoolDetailsList.PreviousSchoolPassedYear,
                                PreviousSchoolPercentage = model.PreviousSchoolDetailsList.PreviousSchoolPercentage,
                            };
                            await _context.PreviousSchoolDetails.AddAsync(previouschoolDetail);
                        }
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        public async Task<bool> DeleteStudent(int? id)
        {
            var student= await _context.Student.Where(x=>x.StudentId == id).FirstOrDefaultAsync();
            try
            {
                if (student!=null)
                {
                    student.Status = false;
                    _context.Entry(student).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }
    }
}
