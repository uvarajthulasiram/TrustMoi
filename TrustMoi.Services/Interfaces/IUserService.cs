using System;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Interfaces
{
    public interface IUserService
    {
        AdvisorPersonalDetailsVm GetPersonalDetailsByUserId(string userId);
        void SavePersonalDetails(AdvisorPersonalDetailsVm model, string userId);
    }
}