using Inwentaryzacja.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inwentaryzacja
{
    //The template for the database
    public class InventoryDbContext : IdentityDbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

            #region In-memory database seeding for testing purposes
            var komputer = new DeviceType { Id = Guid.NewGuid(), Type = "Komputer" };
			var monitor = new DeviceType { Id = Guid.NewGuid(), Type = "Monitor" };
			var myszka = new DeviceType { Id = Guid.NewGuid(), Type = "Myszka" };
            DeviceTypes.Add(komputer);
            DeviceTypes.Add(monitor);
            DeviceTypes.Add(myszka);

			var employee1 = new Employee { Id = Guid.NewGuid(), FirstName = "Jan", LastName = "Kowalski", Position = "Programista" };
			var employee2 = new Employee { Id = Guid.NewGuid(), FirstName = "Anna", LastName = "Nowak", Position = "Sekretarka" };
			var employee3 = new Employee { Id = Guid.NewGuid(), FirstName = "Tomasz", LastName = "Zielony", Position = "Prezes" };
            Employees.Add(employee1);
            Employees.Add(employee2);
            Employees.Add(employee3);

			var device1 = new Device { Id = Guid.NewGuid(), Code = "BC145623", SerialNumber = "SN00111", Description = "Komputer Dell", DeviceTypeId = komputer.Id, EmployeeId = employee1.Id, Status = (Status)2 };
			var device2 = new Device { Id = Guid.NewGuid(), Code = "BC456574", SerialNumber = "SN00222", Description = "Monitor IIyama", DeviceTypeId = monitor.Id, EmployeeId = employee2.Id };
            Devices.Add(device1);
            Devices.Add(device2);

            var issuedDevice = new IssuedDevice { Id = Guid.NewGuid(), DeviceId = device1.Id, EmployeeId = employee1.Id, DateOfIssue = DateTime.Now.ToUniversalTime() };
            IssuedDevices.Add(issuedDevice);

			SaveChanges();

			#endregion
		}

		//Tables in the database
		public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<IssuedDevice> IssuedDevices { get; set; }

        // Migration data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var komputer = new DeviceType { Id = Guid.NewGuid(), Type = "Komputer" };
            var monitor = new DeviceType { Id = Guid.NewGuid(), Type = "Monitor" };
            var myszka = new DeviceType { Id = Guid.NewGuid(), Type = "Myszka" };
            modelBuilder.Entity<DeviceType>().HasData(
                komputer,
                monitor,
                myszka
            );

			var employee1 = new Employee { Id = Guid.NewGuid(), FirstName = "Jan", LastName = "Kowalski", Position = "Programista" };
			var employee2 = new Employee { Id = Guid.NewGuid(), FirstName = "Anna", LastName = "Nowak", Position = "Sekretarka" };
			var employee3 = new Employee { Id = Guid.NewGuid(), FirstName = "Tomasz", LastName = "Zielony", Position = "Prezes" };
			modelBuilder.Entity<Employee>().HasData(
                employee1,
                employee2,
                employee3
            );

			var device1 = new Device { Id = Guid.NewGuid(), Code = "BC145623", SerialNumber = "SN00111", Description = "Komputer Dell", DeviceTypeId = komputer.Id, EmployeeId = employee1.Id, Status = (Status)2 };
			var device2 = new Device { Id = Guid.NewGuid(), Code = "BC456574", SerialNumber = "SN00222", Description = "Monitor IIyama", DeviceTypeId = monitor.Id, EmployeeId = employee2.Id };
			modelBuilder.Entity<Device>().HasData(
                device1,
                device2
            );

			var issuedDevice = new IssuedDevice { Id = Guid.NewGuid(), DeviceId = device1.Id, EmployeeId = employee1.Id, DateOfIssue = DateTime.Now.ToUniversalTime() };
			modelBuilder.Entity<IssuedDevice>().HasData(
				issuedDevice
			);
        }

    }
}
