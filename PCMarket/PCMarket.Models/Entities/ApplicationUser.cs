namespace PCMarket.Models.Entities
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;
    using Interfaces;

    public abstract class ApplicationUser : IUser
    {
        private readonly Role role;

        protected ApplicationUser(Role role)
        {
            this.role = role;
            this.RegistrationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [DisplayName("First name")]
        public string Firstname { get; set; }

        [DisplayName("Last name")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Registration date")]
        public DateTime RegistrationDate { get; }

        public string UserRole => this.role.ToString();
        
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [NotMapped]
        public string Fullname => $"{this.Firstname} {this.Lastname}";
    }
}