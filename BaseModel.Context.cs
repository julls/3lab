﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace дэ2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolChildNew1Entities : DbContext
    {
        public SchoolChildNew1Entities()
            : base("name=SchoolChildNew1Entities")
        {
        }
		private static SchoolChildNew1Entities _context;

		public static SchoolChildNew1Entities GetContext()
		{
			if (_context == null)
			{
				_context = new SchoolChildNew1Entities();
			}

			return _context;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Activity_Schedule> Activity_Schedule { get; set; }
        public virtual DbSet<Children> Children { get; set; }
        public virtual DbSet<Date_Of_Enrolment> Date_Of_Enrolment { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Instructors_Assignment> Instructors_Assignment { get; set; }
        public virtual DbSet<Parent_contacts> Parent_contacts { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Role_> Role_ { get; set; }
    }
}
