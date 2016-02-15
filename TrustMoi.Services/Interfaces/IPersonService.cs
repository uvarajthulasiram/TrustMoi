using System;
using TrustMoi.ViewModels;

namespace TrustMoi.Services.Interfaces
{
    public interface IPersonService
    {
        AdvisorPersonalDetailsVm GetPersonalDetailsByUserId(string userId);
    }
}