using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.DbDependencies
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    CountryName = "Bangladesh",
                    CountryCode = "BD",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 2,
                    CountryName = "United States",
                    CountryCode = "USA",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                },
                new Country
                {
                    Id = 3,
                    CountryName = "United Kingdom",
                    CountryCode = "UK",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });

            modelBuilder.Entity<State>().HasData(
            new State
            {
                Id = 1,
                CountryID = 1,
                StateName = "Dhaka",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 2,
                CountryID = 1,
                StateName = "Rajshahi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 3,
                CountryID = 2,
                StateName = "New York",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new State
            {
                Id = 4,
                CountryID = 3,
                StateName = "London",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });

            modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                StateId = 1,
                CityName = "Mohammadpur",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 2,
                StateId = 1,
                CityName = "Dhanmondi",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 3,
                StateId = 2,
                CityName = "Nator",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 4,
                StateId = 2,
                CityName = "Sirajganj",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 5,
                StateId = 3,
                CityName = "Hempstead town",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 6,
                StateId = 3,
                CityName = "South Bucks",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 7,
                StateId = 4,
                CityName = "Huntsville",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new City
            {
                Id = 8,
                StateId = 4,
                CityName = "Montgomery",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                Id = 1,
                ReligionName = "Muslim",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }, new Religion
            {
                Id = 2,
                ReligionName = "hindu",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
            }
            , new Religion
            {
                Id = 3,
                ReligionName = "Christan",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
            }
             , new Religion
             {
                 Id = 4,
                 ReligionName = "Buddhism",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
             });
            modelBuilder.Entity<MaritialStatus>().HasData(
                new MaritialStatus
                {
                    Id = 1,
                    MaritialStatusName = "Married",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                },
                 new MaritialStatus
                 {
                     Id = 2,
                     MaritialStatusName = "UnMarried",
                     CreatedBy = 1,
                     CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                 },
                  new MaritialStatus
                  {
                      Id = 3,
                      MaritialStatusName = "Divorce",
                      CreatedBy = 1,
                      CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                  });
            modelBuilder.Entity<BloodGroup>().HasData(
                new BloodGroup
                {
                    Id = 1,
                    BloodGroupName = "A+",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                },
                new BloodGroup
                {
                    Id = 2,
                    BloodGroupName = "A-",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                },
                new BloodGroup
                {
                    Id = 3,
                    BloodGroupName = "B+",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                },
                new BloodGroup
                {
                    Id = 4,
                    BloodGroupName = "B-",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                }, new BloodGroup
                {
                    Id = 5,
                    BloodGroupName = "O+",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                }, new BloodGroup
                {
                    Id = 6,
                    BloodGroupName = "O-",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                }, new BloodGroup
                {
                    Id = 7,
                    BloodGroupName = "AB+",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                }, new BloodGroup
                {
                    Id = 8,
                    BloodGroupName = "AB-",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),

                });
            modelBuilder.Entity<ZipCode>().HasData(
                new ZipCode
                {
                    Id = 1,
                    CityId = 1,
                    ZipCodeName = "1207/1225",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)

                },
                new ZipCode
                {
                    Id = 2,
                    CityId = 2,
                    ZipCodeName = "1209",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)

                },
                new ZipCode
                {
                    Id = 3,
                    CityId = 3,
                    ZipCodeName = "6400-03",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)

                },
                new ZipCode
                {
                    Id = 4,
                    CityId = 4,
                    ZipCodeName = "6700-02",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)

                },
                new ZipCode
                {
                    Id = 5,
                    CityId = 5,
                    ZipCodeName = "19549-11551",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                },
                new ZipCode
                {
                    Id = 6,
                    CityId = 6,
                    ZipCodeName = "UB8,UB9",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                },
                new ZipCode
                {
                    Id = 7,
                    CityId = 7,
                    ZipCodeName = "35649",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                },
                new ZipCode
                {
                    Id = 8,
                    CityId = 8,
                    ZipCodeName = "36043",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                });

            modelBuilder.Entity<CompanyInfo>().HasData(
                new CompanyInfo
                {
                    Id = 1,
                    CompanyName = "Bashundhara Group",
                    CompanyAddress = "Dhaka Bangladesh",
                    Email = "Bashundhara@gmail.com",
                    CountryId = 1,
                    ZipCodeId = 1,
                    StateId = 1,
                    CityId = 1,
                    ContactNumber = "+88016325152",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                });
            modelBuilder.Entity<BranchInfo>().HasData(
                new BranchInfo
                {
                    Id = 1,
                    BranceName = "Bashundhara Logistics Limited",
                    BranchAddress = "Pushpanjali,Bangladesh",
                    CompanyInfoId = 1,
                    CountryId = 1,
                    ZipCodeId = 1,
                    StateId = 1,
                    CityId = 1,
                    Email = "bashundharaLogistics@gmail.com",
                    ContactNumber = "+8800056254155",
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)
                });
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "Construction",
                    CompanyInfoId = 1,
                    BranchInfoId = 1,
                    ProjectDescription = "Create a beautiful building",
                    Duraction = "1.9 Month",
                    StartDate = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),
                    EndDate = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null),
                    CreatedBy = 1,
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-mm-dd", null)


                });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FirstName = "Hasan",
                MiddleName = "Ali",
                LastName = "Khan",
                DateOfBirth = DateTime.ParseExact("1994-02-01", "yyyy-mm-dd", null),
                NID = "345694565498",
                ReligionId = 1,

                MaritialStatusId = 1,
                Nationalaty = "Bangladeshi",
                Picture = "avatar2.png",
                GenderId = 1,
                CompanyId = 1,
                BrancehId = 1,
                ProjectId = 1,
                JoiningDate = DateTime.ParseExact("2020-02-01", "yyyy-MM-dd", null),
                UserName = "",
                Password = "",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

            });
            modelBuilder.Entity<Gender>().HasData(
            new Gender
            {
                Id = 1,
                GenderName = "Male",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
             new Gender
             {
                 Id = 2,
                 GenderName = "Female",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             },
              new Gender
              {
                  Id = 3,
                  GenderName = "Others",
                  CreatedBy = 1,
                  CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
              });
            modelBuilder.Entity<Designation>().HasData(
           new Designation
           {
               Id = 1,
               DesignationName = "IT Officer",
               CreatedBy = 1,
               CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
           });
            modelBuilder.Entity<Department>().HasData(
          new Department
          {
              Id = 1,
              DepartmentName = "IT",
              CreatedBy = 1,
              CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
          });
            modelBuilder.Entity<ServiceInfo>().HasData(
          new ServiceInfo
          {
              Id = 1,
              EmployeeId = 1,
              DepartmentId = 1,
              DesignationId = 1,
              BranchId = 1,
              Remarks = "Good",
              JoiningDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
              CreatedBy = 1,
              CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
          });
            modelBuilder.Entity<FamilyMember>().HasData(
             new FamilyMember
             {
                 Id = 1,
                 EmployeeId = 1,
                 FamilyMemberName = "Kamal",
                 RelationShipId = 1,
                 ContactNumber = "+88078827371",
                 Address = "Uttara Dhaka 1230",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<RelationShip>().HasData(
             new RelationShip
             {
                 Id = 1,
                 RelationShipName = "Brother",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<Degree>().HasData(
             new Degree
             {
                 Id = 1,
                 DegreeName = "Msc",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<EducationGroup>().HasData(
             new EducationGroup
             {
                 Id = 1,
                 EducationGroupName = "Science",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<AttachmentType>().HasData(
             new AttachmentType
             {
                 Id = 1,
                 AttachmentTypeName = "NID",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             },
             new AttachmentType
             {
                 Id = 2,
                 AttachmentTypeName = "Birth Certificate",
                 CreatedBy = 1,
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<Education>().HasData(
            new Education
            {
                Id = 1,
                EmployeeId = 1,
                DegreeId = 1,
                EducationGroupId = 1,
                InstituteName = "Brac University",
                PassingYear = "2023-09-08",
                Remarks = "Good",
                Result = "Frist Class",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Attachment>().HasData(
            new Attachment
            {
                Id = 1,
                EmployeeId = 1,
                AttachmentTyppeId = 1,
                AttachmentFile = "avatar.png",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Training>().HasData(
            new Training
            {
                Id = 1,
                EmployeeId = 1,
                TrainingName = "Raju",
                StartDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                EndDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                OrganigationName = "Tactsoft",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<LeaveType>().HasData(
           new LeaveType
           {
               Id = 1,
               LeaveTypeName = "Sick",
               CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
           });
            modelBuilder.Entity<AwardType>().HasData(
           new AwardType
           {
               Id = 1,
               AwardTypeName = "Regualar Employee",
               CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
           });
            modelBuilder.Entity<Award>().HasData(
           new Award
           {
               Id = 1,
               AwardTypeId = 1,
               EmployeeId = 1,
               Prize = 2,
               Gift = "Madel",
               Date = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
               CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
           });
           
          
            modelBuilder.Entity<Deduction>().HasData(
                new Deduction
                {
                    Id = 1,
                    DeductionName = "Late Absent",
                    Comment = "4 Days Late",
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });
            modelBuilder.Entity<LeaveApplication>().HasData(
              new LeaveApplication
              {
                  Id = 1,
                  EmployeeId = 1,
                  LeaveTypeId = 1,
                  StartDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                  EndDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                  AttachmentFile = "uhyg",
                  Subject = "abcd",
                  Description = "this is descriptin",
                  CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

              });
            modelBuilder.Entity<Advance>().HasData(
             new Advance
             {
                 Id = 1,
                 EmployeeId = 1,
                 AdvanceTypeId = 1,
                 AdvanceDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                 ApproveAmount = 10000,
                 MonthlyDeduction = 2000,
                 DisburseYear = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                 ApproveBy = "Arif",
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

             });
            modelBuilder.Entity<EmploymentHistory>().HasData(
             new EmploymentHistory
             {
                 Id = 1,
                 EmployeeId = 1,
                 NameOfCompany = "Us Bangla",
                 JobFor = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                 JobTo = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null),
                 Salary = 85000,
                 ReasonForLeaving = "abcd",
                 CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
             });
            modelBuilder.Entity<AdvanceType>().HasData(
            new AdvanceType
            {
                Id = 1,
                AdvanceTypeName = "Advance Salary",
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

            });
            modelBuilder.Entity<Reference>().HasData(
            new Reference
            {
                Id = 1,
                ReferenceName = "Kamal",
                Address = "Mirpur",
                Phone = "01213256442",
                MobileNumber = "023256589522",
                Nid = 56588552685,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

            });
            modelBuilder.Entity<Nominee>().HasData(
           new Nominee
           {
               Id = 1,
               EmployeeId = 1,
               NomineeName = "Kabir",
               Picture="zsdfasdf",
               Address = "Mirpur",
               ContactNumber = "018213256442",
               percentage = "100%",
               RelationShipId = 1,
               CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

           });
            modelBuilder.Entity<Attendance>().HasData(
      new Attendance
      {
          Id = 1,
          EmployeeId = 1,
          CompanyInfoId = 1,
          BranchInfoId = 1,
          Date = DateTime.Today,
          Intime = DateTime.ParseExact("10:00:00", "hh:mm:ss", null),
          IntimeNumber = 5,
          OutTime = DateTime.ParseExact("10:00:00", "hh:mm:ss", null),
          OutTimeNumber = 5,
          EntryType = "Admin",
          CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)

      });
            modelBuilder.Entity<ServiceInformation>().HasData(
                new ServiceInformation
                {
                    Id = 1,
                    EmployeeId=1,
                    DesignationId=1,
                    DepertmentId=1,
                    DateOfJoining=DateTime.ParseExact("2023-03-02","yyyy-mm-dd",null),
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });
            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType
                {
                    Id = 1,
                    Remarks="Good",
                    DateOfParmanent = DateTime.ParseExact("2023-03-02", "yyyy-mm-dd", null),
                    CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });

        }

    }
}
