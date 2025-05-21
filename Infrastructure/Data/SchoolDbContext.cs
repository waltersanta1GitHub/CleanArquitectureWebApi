using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SchoolDbContext: DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<RegistredUser> RegistredUsers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }        
        public DbSet<Student> Students { get; set; }       
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One To many

            modelBuilder.Entity<SchoolClass>()
                .HasOne(a => a.Student)
                .WithMany(e => e.SchoolClasses)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchoolClass>()
                .HasOne(a => a.Teacher)
                .WithMany(e => e.SchoolClasses)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            // One to One
            modelBuilder.Entity<RegistredUser>()
               .HasOne(a => a.Profile)
               .WithOne(e => e.RegistredUser)
               .HasForeignKey<UserProfile>(p => p.Id);

            // Optional
            modelBuilder.Entity<Student>()
              .HasOne(a => a.Tutor)
              .WithMany(e => e.Students)
              .HasForeignKey(t => t.TutorId)
              .OnDelete(DeleteBehavior.SetNull); 


            modelBuilder.Entity<RegistredUser>().HasData(
                new { Id = 1, IsActive = true, Name = "Admin", City = "Madrid", Email="usuariouno@school.com", Phone="+3468975642" },               
                new { Id = 3, IsActive = false, Name = "Usuario", City = "Zaragoza", Email = "usuariodos@school.com", Phone = "+349653289995" },
                new { Id = 4, IsActive = true, Name = "Usuario", City = "Pamplona", Email = "usuariotres@school.com", Phone = "+34637574992" },
                new { Id = 8, IsActive = false, Name = "Invitado", City = "Zaragoza", Email = "usuariocuatro@school.com", Phone = "+349653289995" },
                new { Id = 9, IsActive = true, Name = "Invitado", City = "Barcelona", Email = "usuariocinco@school.com", Phone = "+346378974992" },
                new { Id = 10, IsActive = false, Name = "Invitado", City = "Huesca", Email = "usuarioseis@school.com", Phone = "+349651189995" },
                new { Id = 11, IsActive = true, Name = "Invitado", City = "Bilbao", Email = "usuariosiete@school.com", Phone = "+34637334992" }
                );

            modelBuilder.Entity<UserProfile>().HasData(
               new { Id = 1, NickName ="Bathman01", AvatarUrl="https://ejemplo.com/avatar1.png" },             
               new { Id = 3, NickName = "Simpson01", AvatarUrl = "https://ejemplo.com/avatar2.png" },
               new { Id = 4, NickName = "WonderWoman2", AvatarUrl = "https://ejemplo.com/avatar3.png" },
               new { Id = 8, NickName = "Catwoman01", AvatarUrl = "https://ejemplo.com/avatar4.png" },
               new { Id = 9, NickName = "Phinias&Frebs", AvatarUrl = "https://ejemplo.com/avatar5.png" },
               new { Id = 10, NickName = "TomyYDaly", AvatarUrl = "https://ejemplo.com/avatar6.png" },
               new { Id = 11, NickName = "Harrypotter", AvatarUrl = "https://ejemplo.com/avatar7.png" }
               );


            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 8, Name="Ricardo Parra", Age=24, TutorId =1 },
                new Student { Id = 9, Name = "Maria Caro",  Age = 30, TutorId = null },
                new Student { Id = 10, Name = "Jose Botella", Age = 28, TutorId = null },
                new Student { Id = 11, Name = "Marcos Aguilar", Age = 34, TutorId = 2 }
                );

            modelBuilder.Entity<Tutor>().HasData(
               new { Id = 1, Name = "Maria Parra", Description="Madre",Phone = "+3469850245" },
               new { Id = 2, Name = "Pedro Caro", Description = "Tio", Phone = "+3463750285" }             
               );

            modelBuilder.Entity<Teacher>().HasData(
                new { Id = 3, Name="Dr. Fernandez", Speciality = "Matematica" },
                new { Id = 4, Name = "Prof. Gomez", Speciality = "Lengua" }                
                );

            modelBuilder.Entity<SchoolClass>().HasData(
                new SchoolClass { Id = 1, StudentId= 8, TeacherId = 3 },
                new SchoolClass { Id = 2, StudentId = 10, TeacherId = 3 },
                new SchoolClass { Id = 3, StudentId = 9, TeacherId = 4 },
                new SchoolClass { Id = 4, StudentId = 11, TeacherId = 4 }
                );
        }

    }
}
