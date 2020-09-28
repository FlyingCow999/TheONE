using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flying_Cow_TMSAPI.Model
{
    public class TMSDBContext :DbContext
    {
        public TMSDBContext()
        {
        }

        public TMSDBContext(DbContextOptions<TMSDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Abnormal> Abnormal { get; set; }
        public virtual DbSet<Address> Addresse { get; set; }
        public virtual DbSet<Anomaly> Anomaly { get; set; }
        public virtual DbSet<Carrier_Profit> Carrier_Profit { get; set; }
        public virtual DbSet<Dispatch> Dispatch { get; set; }
        public virtual DbSet<Consignee> Consignee { get; set; }
        public virtual DbSet<Driver_Quotation> Driver_Quotation { get; set; }
        public virtual DbSet<Entrust> Entrust { get; set; }
        public virtual DbSet<Inquiry> Inquiry { get; set; }
        public virtual DbSet<Jurisdiction> Jurisdiction { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleJurisdiction> RoleJurisdiction { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Takegoods> Takegoods { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Img> Img { get; set; }
    }
}
