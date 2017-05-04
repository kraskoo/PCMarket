namespace PCMarket.Models.Entities
{
    using Common.Enums;

    public class RegularUser : ApplicationUser
    {
        public RegularUser() : base(Role.Regular)
        {
        }
    }
}