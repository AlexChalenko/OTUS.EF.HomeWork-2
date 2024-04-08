using Otus.Teaching.PromoCodeFactory.Core.Domain;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static IEnumerable<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                RoleId = Roles.FirstOrDefault(x => x.Name == "Admin").Id,
                AppliedPromocodesCount = 5
            },
            new Employee()
            {
                Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                RoleId = Roles.FirstOrDefault(x => x.Name == "PartnerManager").Id,
                AppliedPromocodesCount = 10
            },
        };

        public static IEnumerable<Role> Roles => new List<Role>()
        {
            new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Admin",
                Description = "Администратор",
            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "PartnerManager",
                Description = "Партнерский менеджер"
            }
        };

        public static IEnumerable<Preference> Preferences => new List<Preference>()
        {
            new Preference()
            {
                Id = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                Name = "Театр",
            },
            new Preference()
            {
                Id = Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                Name = "Семья",
            },
            new Preference()
            {
                Id = Guid.Parse("76324c47-68d2-472d-abb8-33cfa8cc0c84"),
                Name = "Дети",
            }
        };

        public static IEnumerable<Customer> Customers
        {
            get
            {
                var customerId = Guid.Parse("a6c8c6b1-4349-45b0-ab31-244740aaf0f0");
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = customerId,
                        Email = "ivan_sergeev@mail.ru",
                        FirstName = "Иван",
                        LastName = "Петров",
                        
                        //CustomerPreferences = new List<CustomerPreference>()
                        //{
                        //    Preferences.FirstOrDefault(x => x.Name == "Театр"),
                        //    Preferences.FirstOrDefault(x => x.Name == "Семья")
                        //},
                    }
                };

                return customers;
            }
        }

        public static List<CustomerPreference> CustomerPreferences
        {
            get
            {
                var customerPereference = new List<CustomerPreference>()
                {
                    new CustomerPreference()
                    {
                        Id = Guid.NewGuid(),
                        CustomerId=Guid.Parse("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                        PreferenceId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")
                    },
                    new CustomerPreference()
                    {
                        Id = Guid.NewGuid(),
                        CustomerId=Guid.Parse("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                        PreferenceId=Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd")
                    },

                };
                return customerPereference;
            }
        }

        public static IEnumerable<PromoCode> PromoCodes => new List<PromoCode>()
        {
            new PromoCode()
            {
                Id = Guid.NewGuid(),
                Code = "THEATER-123",
                ServiceInfo = "Скидка 10% на театральные услуги",
                PartnerManagerId = Employees.FirstOrDefault(x => x.RoleId == Roles.Where(r=> r.Name == "PartnerManager").First().Id).Id,
                PreferenceId = Preferences.FirstOrDefault(x => x.Name == "Театр").Id,
                CustomerId = Customers.FirstOrDefault().Id,
                BeginDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(30)
            },
            new PromoCode()
            {
                Id = Guid.NewGuid(),
                Code = "FAMILY-456",
                ServiceInfo = "Скидка 20% на все семейные услуги",
                PartnerManagerId = Employees.FirstOrDefault(x => x.RoleId == Roles.Where(r=> r.Name == "PartnerManager").First().Id).Id,
                PreferenceId = Preferences.FirstOrDefault(x => x.Name == "Семья").Id,
                CustomerId = Customers.FirstOrDefault().Id,
                BeginDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(60)
            }
        };
    }
}