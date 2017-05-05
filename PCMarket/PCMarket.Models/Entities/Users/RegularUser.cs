namespace PCMarket.Models.Entities.Users
{
    using Common.Enums;

    public class RegularUser : ApplicationUser
    {
        public RegularUser() : base(RoleType.Regular)
        {
        }
    }
}