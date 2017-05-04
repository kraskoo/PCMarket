namespace PCMarket.Models.Interfaces
{
    using System;

    public interface IUser : IModel<int>
    {
        string Firstname { get; }

        string Lastname { get; }

        string Fullname { get; }

        DateTime RegistrationDate { get; }
    }
}