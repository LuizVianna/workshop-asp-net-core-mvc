using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingsService
    {
        private SalesWebMvcContext _context;

        public SeedingsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.SalesRecord.Any() || _context.Seller.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 1400.0, d2);
            Seller s3 = new Seller(3, "Rogerio Melo", "rogerio@gmail.com", new DateTime(1980, 2, 18), 1600.0, d3);
            Seller s4 = new Seller(4, "Lia Melo", "lia@gmail.com", new DateTime(1992, 10, 02), 10000.0, d4);
            Seller s5 = new Seller(5, "André Rodrigues", "andre@gmail.com", new DateTime(1998, 11, 21), 12000.0, d2);
            Seller s6 = new Seller(6, "Felipe Antunees", "felipe@gmail.com", new DateTime(1997, 9, 21), 1200.0, d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 12, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 12, 25), 11000.0, SaleStatus.Pending, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 12, 25), 11000.0, SaleStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 12, 25), 11000.0, SaleStatus.Pending, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 12, 25), 11000.0, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 12, 25), 15000.0, SaleStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);

            _context.SaveChanges();

        }
    }
}


