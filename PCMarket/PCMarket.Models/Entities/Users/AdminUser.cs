namespace PCMarket.Models.Entities.Users
{
    using System.Collections.Generic;
    using Common.Enums;
    using News;

    public class AdminUser : ApplicationUser
    {
        private ICollection<SoftwareNew> softwareNews;
        private ICollection<HardwareNew> hardwareNews;

        public AdminUser() : base(RoleType.Admin)
        {
            this.softwareNews = new HashSet<SoftwareNew>();
            this.hardwareNews = new HashSet<HardwareNew>();
        }

        public virtual ICollection<SoftwareNew> SoftwareNews
        {
            get { return this.softwareNews; }
            set { this.softwareNews = value; }
        }

        public virtual ICollection<HardwareNew> HardwareNews
        {
            get { return this.hardwareNews; }
            set { this.hardwareNews = value; }
        }
    }
}