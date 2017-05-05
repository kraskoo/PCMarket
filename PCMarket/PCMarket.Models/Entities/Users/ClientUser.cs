namespace PCMarket.Models.Entities.Users
{
    using Common.Enums;

    public class ClientUser : ApplicationUser
    {
        public ClientUser() : base(RoleType.Client)
        {
        }
    }
}