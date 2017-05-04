namespace PCMarket.Models.Entities
{
    using Common.Enums;

    public class AdminUser : ApplicationUser
    {
        public AdminUser() : base(Role.Admin)
        {
        }
    }
}