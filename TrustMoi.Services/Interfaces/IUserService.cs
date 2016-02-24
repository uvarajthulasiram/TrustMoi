using System.Collections.Generic;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Interfaces
{
    public interface IUserService
    {
        PersonDetailsVm GetPersonalDetailsByUserId(string userId);
        IEnumerable<ManagePersonVm> GetAllUsers();
        void SavePersonalDetails(PersonDetailsVm model, string userId);
    }
}