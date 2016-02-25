using System.Linq;
using System.Web.Mvc;
using MVCGrid.Models;
using MVCGrid.Web;
using TrustMoi.Services.Interfaces;
using TrustMoi.ViewModels;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TrustMoi.MvcGridConfig), "RegisterGrids")]

namespace TrustMoi
{
    public static class MvcGridConfig
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("ManageUsersGrid", new MVCGridBuilder<ManagePersonVm>()
                .WithAuthorizationType(AuthorizationType.Authorized)
                .WithSorting(true, "FullName")
                .WithPaging(paging: true, itemsPerPage: 2, allowChangePageSize: true, maxItemsPerPage: 50)
                .AddColumns(cols =>
                {
                    cols.Add("FullName").WithHeaderText("Name").WithValueExpression(p => p.FullName).WithFiltering(true);
                    cols.Add("Address").WithHeaderText("Address").WithValueExpression(p => p.Address).WithFiltering(true);
                    cols.Add("Phone").WithHeaderText("Phone").WithValueExpression(p => p.Phone).WithFiltering(true);
                    cols.Add("PhoneConfirmed").WithHeaderText("Phone Confirmed").WithValueExpression(p => p.PhoneConfirmed ? "Yes" : "No").WithFiltering(true);
                    cols.Add("Email").WithHeaderText("Email").WithValueExpression(p => p.Email).WithFiltering(true);
                    cols.Add("EmailConfirmed").WithHeaderText("Email Confirmed").WithValueExpression(p => p.EmailConfirmed ? "Yes" : "No").WithFiltering(true);
                    cols.Add("Gender").WithHeaderText("Gender").WithValueExpression(p => p.Gender).WithFiltering(true);
                }).WithRetrieveDataMethod((context) =>
                {
                    var service = DependencyResolver.Current.GetService<IUserService>();
                    var options = context.QueryOptions;
                    var result = new QueryResult<ManagePersonVm>();

                    if (!options.GetLimitOffset().HasValue) return result;

                    var query = service.GetAllUsers().AsQueryable();
                    var limitOffset = options.GetLimitOffset();
                    var limitRowcount = options.GetLimitRowcount();

                    result.TotalRecords = query.Count();

                    if (limitOffset != null && limitRowcount != null)
                        query = query.Skip(limitOffset.Value).Take(limitRowcount.Value);
                        
                    result.Items = query.ToList();

                    return result;
                }));
        }
    }
}