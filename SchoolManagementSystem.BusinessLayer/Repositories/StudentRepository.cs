using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Model;
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
                                 join a in _context.StudentAccountInfo
                                 on s.StudentId equals a.StudentId into account
                                 from a in account.DefaultIfEmpty()
                                 where s.Status == true
                                 select new StudentViewModel
                                 {
                                     StudentId = s.StudentId,
                                     StudentIDUnique = s.StudentUniqueId,
                                     StudentName = s.StudentName,
                                     StudentName_Nep = s.StudentName_Nep,
                                     Gender = s.Gender,
                                     StudentImage = s.StudentImage,
                                     FatherCell = p != null ? p.FatherCell : null,
                                     MotherCell = p != null ? p.MotherCell : null,
                                     StudentPreviousCode = a != null ? a.StudentPreviousCode : null,
                                 }).ToListAsync() ?? new List<StudentViewModel>();

            return student;
        }

        public async Task<StudentViewModel> GetStudentById(int? id)
        {
            var student = await (from s in _context.Student
                                 join p in _context.StudentParentsDetails
                                 on s.StudentId equals p.StudentId into parents
                                 from p in parents.DefaultIfEmpty()
                                 join a in _context.StudentAccountInfo
                                 on s.StudentId equals a.StudentId into account
                                 from a in account.DefaultIfEmpty()
                                 join ac in _context.StudentAcademicInfo
                                 on s.StudentId equals ac.StudentId into academic
                                 from ac in academic.DefaultIfEmpty()
                                 join ad in _context.StudentAddress
                                 on s.StudentId equals ad.StudentId into address
                                 from ad in address.DefaultIfEmpty()
                                 join o in _context.StudentOtherDetails
                                 on s.StudentId equals o.StudentId into other
                                 from o in other.DefaultIfEmpty()
                                 where s.StudentId == id
                                 select new StudentViewModel()
                                 {
                                     StudentId = s.StudentId,
                                     StudentName = s.StudentName,
                                     StudentImage = s.StudentImage,
                                     StudentName_Nep = s.StudentName_Nep,
                                     Gender=s.Gender,
                                     DOB_AD=s.DOB_AD,
                                     DOB_BS=s.DOB_BS,
                                     BloodGroup=s.BloodGroup,
                                     PhoneNumber=s.PhoneNumber,
                                     Nationality=s.Nationality,
                                     Status=s.Status,
                                     AdmittedBy=s.AdmittedBy,
                                     AdmittedDate=s.AdmittedDate,
                                     //AccountInfo
                                     LastInsertedId=a.LastInsertedId,
                                     StudentIDUnique=a.StudentIDUnique,
                                     StudentPreviousCode=a.StudentPreviousCode,
                                     StudentEmail=a.StudentEmail,
                                     BusRoute=a.BusRoute,
                                     BusStop=a.BusStop,
                                     BusRouteEvening=a.BusRouteEvening,
                                     BusStopEvening=a.BusStopEvening,
                                     //Academicinfo
                                     Class=ac.Class,
                                     Section=ac.Section,
                                     AdmittedYear=ac.AdmittedYear,
                                     LastInsertedRollNo=ac.LastInsertedRollNo,
                                     ClassRollNo=ac.ClassRollNo,                                 
                                     Team = ac.Team,
                                     Coaching = ac.Coaching,
                                     TransportationMode = ac.TransportationMode,
                                     TeaBreakfast = ac.TeaBreakfast,
                                     LunchSnacks = ac.LunchSnacks,
                                     Vegetarian = ac.Vegetarian,
                                     EnrollmentType = ac.EnrollmentType,
                                     IEMISNumber = ac.IEMISNumber,
                                     SymbolNumber=ac.SymbolNumber,
                                     //ParentsDetails
                                     FatherName = p.FatherName,
                                     FatherImage = p.FatherImage,
                                     FatherOccupation = p.FatherOccupation,
                                     FatherCell = p.FatherCell,
                                     FatherEmail = p.FatherEmail,
                                     MotherName = p.MotherName,
                                     MotherImage = p.MotherImage,
                                     MotherOccupation = p.MotherOccupation,
                                     MotherCell = p.MotherCell,
                                     MotherEmail = p.MotherEmail,
                                     GuardianName = p.GuardianName,
                                     GuardianRelation = p.GuardianRelation,
                                     GuardianImage = p.GuardianImage,
                                     GuardianCell = p.GuardianCell,
                                     //OtherDetails
                                     Religion = o.Religion,
                                     Ethnicity = o.Ethnicity,
                                     Citizenship = o.Citizenship,
                                     DifferentlyAbled = o.DifferentlyAbled,
                                     UserCode = o.UserCode,
                                     //addressInfo
                                     PermanentProvince = ad.PermanentProvince,
                                     PermanentDistrict = ad.PermanentDistrict,
                                     PermanentMunicipality = ad.PermanentMunicipality,
                                     PermanentAddress = ad.PermanentAddress,
                                     CurrentProvince = ad.CurrentProvince,
                                     CurrentDistrict = ad.CurrentDistrict,
                                     CurrentMunicipality = ad.CurrentMunicipality,
                                     CurrentAddress = ad.CurrentAddress,
                                     
                                     PreviousSchoolDetailsList = _context.PreviousSchoolDetails
                            .Where(y => y.StudentId == s.StudentId)
                            .Select(y => new PreviousSchoolDetailsViewModel()
                            {
                                Id = y.Id,
                                StudentId = y.StudentId,
                                PreviousSchoolName = y.PreviousSchoolName,
                                PreviousSchoolLevel = y.PreviousSchoolLevel,
                                PreviousSchoolUniversity = y.PreviousSchoolUniversity,
                                PreviousSchoolType = y.PreviousSchoolType,
                                PreviousSchoolSymbolNumber = y.PreviousSchoolSymbolNumber,
                                PreviousSchoolRegistrationNumber = y.PreviousSchoolRegistrationNumber,
                                PreviousSchoolPassedYear = y.PreviousSchoolPassedYear,
                                PreviousSchoolPercentage = y.PreviousSchoolPercentage,
                            }).ToList() ?? new List<PreviousSchoolDetailsViewModel>(),
                                 }).FirstOrDefaultAsync();

            return student ?? new StudentViewModel();
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
                            student.StudentUniqueId = model.StudentIDUnique;
                            student.StudentName = model.StudentName;
                            student.StudentName_Nep = model.StudentName_Nep;
                            student.Gender = model.Gender;
                            student.DOB_AD = model.DOB_AD;
                            student.DOB_BS = model.DOB_BS;
                            student.BloodGroup = model.BloodGroup;
                            student.StudentImage = model.StudentImage;
                            student.PhoneNumber = model.PhoneNumber;
                            student.Nationality = model.Nationality;
                            student.Status =/* model.Status*/ true;
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
                            parents.MotherEmail = model.MotherEmail;
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
                            accountInfo.StudentPreviousCode = model.StudentPreviousCode;
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
                            academicInfo.LastInsertedRollNo=model.LastInsertedRollNo;
                            academicInfo.SymbolNumber = model.SymbolNumber;
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
                        foreach (var item in await _context.PreviousSchoolDetails.Where(x => x.StudentId == studentId).ToListAsync())
                        {
                            if (!model.PreviousSchoolDetailsList.Any(x => x.Id == item.Id))
                            {
                                _context.PreviousSchoolDetails.Remove(item);
                                await _context.SaveChangesAsync();
                            }
                        }
                        foreach (var item in model.PreviousSchoolDetailsList)
                        {
                            var previousSchoolDetails = await _context.PreviousSchoolDetails.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                            if (previousSchoolDetails != null)
                            {
                                //previousSchoolDetails.Id = model.Id;
                                previousSchoolDetails.StudentId = studentId;
                                previousSchoolDetails.PreviousSchoolName = item.PreviousSchoolName;
                                previousSchoolDetails.PreviousSchoolLevel = item.PreviousSchoolLevel;
                                previousSchoolDetails.PreviousSchoolUniversity = item.PreviousSchoolUniversity;
                                previousSchoolDetails.PreviousSchoolType = item.PreviousSchoolType;
                                previousSchoolDetails.PreviousSchoolSymbolNumber = item.PreviousSchoolSymbolNumber;
                                previousSchoolDetails.PreviousSchoolRegistrationNumber = item.PreviousSchoolRegistrationNumber;
                                previousSchoolDetails.PreviousSchoolPassedYear = item.PreviousSchoolPassedYear;
                                previousSchoolDetails.PreviousSchoolPercentage = item.PreviousSchoolPercentage;
                                _context.Entry(previousSchoolDetails).State = EntityState.Modified;
                            }
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
                            StudentUniqueId = model.StudentIDUnique,
                            StudentName = model.StudentName,
                            StudentName_Nep = model.StudentName_Nep,
                            Gender = model.Gender,
                            DOB_AD = model.DOB_AD,
                            DOB_BS = model.DOB_BS,
                            BloodGroup = model.BloodGroup,
                            StudentImage = model.StudentImage,
                            PhoneNumber = model.PhoneNumber,
                            Nationality = model.Nationality,
                            Status = true,
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
                            StudentId = student.StudentId,
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
                        foreach (var item in model.PreviousSchoolDetailsList)
                        {
                            var previouschoolDetail = new PreviousSchoolDetails()
                            {
                                StudentId = student.StudentId,
                                PreviousSchoolName = item.PreviousSchoolName,
                                PreviousSchoolLevel = item.PreviousSchoolLevel,
                                PreviousSchoolUniversity = item.PreviousSchoolUniversity,
                                PreviousSchoolType = item.PreviousSchoolType,
                                PreviousSchoolSymbolNumber = item.PreviousSchoolSymbolNumber,
                                PreviousSchoolRegistrationNumber = item.PreviousSchoolRegistrationNumber,
                                PreviousSchoolPassedYear = item.PreviousSchoolPassedYear,
                                PreviousSchoolPercentage = item.PreviousSchoolPercentage,
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
            var student = await _context.Student.Where(x => x.StudentId == id).FirstOrDefaultAsync();
            try
            {
                if (student != null)
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
