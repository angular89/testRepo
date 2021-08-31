using api.Models;
using api.Models.HumanResource;
using api.Models.SchoolManagement;
using api.Models.StudentInformation;
using api.Models.UserManagment;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //Unique Keys
                /*
                 * School
                 */
                modelBuilder.Entity<School>(etb =>
                           {
                               etb.HasIndex(t => t.Name)
                                  .IsUnique();
                                etb.HasIndex(t => t.Number)
                                  .IsUnique();
                               etb.HasIndex(t => t.Email)
                                  .IsUnique();
                          });

                modelBuilder.Entity<Section>(etb =>
                           {
                               etb.HasIndex(t => t.Name)
                                  .IsUnique();
                                etb.HasIndex(t => t.Number)
                                  .IsUnique();
                               etb.HasIndex(t => t.Email)
                                  .IsUnique();
                          });
                
                modelBuilder.Entity<Department>(etb =>
                           {
                               etb.HasIndex(t => t.Name)
                                  .IsUnique();
                                etb.HasIndex(t => t.Number)
                                  .IsUnique();
                               etb.HasIndex(t => t.Email)
                                  .IsUnique();
                          });
                modelBuilder.Entity<Grade>()
                                .HasIndex(p => new { p.Name })
                                .IsUnique();
                modelBuilder.Entity<OtherSchool>()
                                .HasIndex(p => new { p.Name })
                                .IsUnique();
                /*
                 * HRMS
                 */
                modelBuilder.Entity<Employee>(etb =>
                           {
                               etb.HasIndex(t => t.Identity)
                                  .IsUnique();
                                etb.HasIndex(t => t.Mobile1)
                                  .IsUnique();
                               etb.HasIndex(t => t.Email)
                                  .IsUnique();
                          });
                modelBuilder.Entity<Job>()
                                .HasIndex(p => new { p.Title })
                                .IsUnique(); 

                                
        //=============================================================================================                       
                //Employee Country Foreign key
                modelBuilder.Entity<Employee>()
                                .HasOne(m => m.EmployeeCountry)
                                .WithMany(t => t.EmployeeCountries)
                                .HasForeignKey(m => m.EmployeeCountryId)
                                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Employee>()
                                .HasOne(m => m.BirthCountry)
                                .WithMany(t => t.BirthCountries)
                                .HasForeignKey(m => m.BirthCountryId)
                                .OnDelete(DeleteBehavior.Cascade);
                //Student Country Foreign key
                modelBuilder.Entity<Student>()
                                .HasOne(m => m.StudentCountry)
                                .WithMany(t => t.StudentCountries)
                                .HasForeignKey(m => m.StudentCountryId)
                                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Student>()
                                .HasOne(m => m.PlaceCountry)
                                .WithMany(t => t.PlaceCountries)
                                .HasForeignKey(m => m.PlaceCountryId)
                                .OnDelete(DeleteBehavior.Cascade);
        }

//==========================================================================
        /* Module No. 0
         * General Models   
         */
        public DbSet<Country> Countries { get; set; }

//==========================================================================
        /* Module No. 1
         * SIS School Information System 
         */
        public DbSet<Year> Years { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<OtherSchool> OtherSchools { get; set; }
        public DbSet<Term> Terms { get; set; }

//==========================================================================
        /* Module No. 2
         * HMS HR Management System 
         */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<TimeOff> TimeOffs { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }

//==========================================================================
        /* Module No. 3
         * SMS Student Management System
         */
        public DbSet<Student> Students { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Class> Classes { get; set; }

//==========================================================================
        /* Module No. 4
         * USM User Support Management
         */
        public DbSet<User> Users { get; set; }
        
//==========================================================================
        /* Module No. 5 
         * Learning Management System
         */

//==========================================================================
        /* Module No. 6
         * EP Employee’s Portal
         */

//==========================================================================
        /*Module No. 7
         * Accounting Information System
         */

//==========================================================================
        /* Module No. 8
         * Parent’s Portal
         */

//==========================================================================
        /* Module No. 9
         * Student’s Corner
         */
         
//==========================================================================
        /* Module No. 10
         * Inventory Management System
         */ 

//==========================================================================
        /* Module No. 11
         * Procurement Management System
         */

//==========================================================================
        /* Module No. 12
         * Digital Cloud
         */
    }
}