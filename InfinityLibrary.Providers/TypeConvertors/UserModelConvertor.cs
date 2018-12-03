using System;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers.TypeConvertors
{
    internal static class UserModelConvertor
    {
        internal static User ToUser(this UserModel model)
        {
            if (model is null) { return null; }

            return new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                DateOfBirth = new DateTime(model.YearOfBirth, model.MonthOfBirth, model.DayOfBirth),
                MembershipValidTill = new DateTime(model.MembershipExpirationYear, model.MembershipExpirationMonth, model.MembershipExpirationDay)
            };
        }

        internal static UserModel ToModel(this User user)
        {
            if (user is null) { return null; }

            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                DayOfBirth = user.DateOfBirth.Day,
                MonthOfBirth = user.DateOfBirth.Month,
                YearOfBirth = user.DateOfBirth.Year,
                MembershipExpirationYear = user.MembershipValidTill.Year,
                MembershipExpirationMonth = user.MembershipValidTill.Month,
                MembershipExpirationDay = user.MembershipValidTill.Day
            };
        }
    }
}