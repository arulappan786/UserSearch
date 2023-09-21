using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using UserSearch.Helpers;

namespace UserSearch.Controllers
{
    public class UserSearchController : Controller
    {
        private IConfiguration _configuration;

        public UserSearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string? GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        #region User Search Param Entry Screen

        public IActionResult UserSearchParamEntryScreen()
        {
            ViewBag.UserNameList = ConversionHelper.BindDropDown(SqlHelper.GetUserNameList(GetConnectionString()));
            ViewBag.UserFieldList = ConversionHelper.BindDropDown(SqlHelper.GetUserFieldList(GetConnectionString()));
            
            return View();
        }

        [HttpPost]
        public object? GetSearchParamsByUserId(int UserId)
        {
            return SqlHelper.GetSearchParamsByUserId(GetConnectionString(), UserId);            
        }

        [HttpPost]
        public ActionResult SaveUserSearchParamEntry(int UserId, string SearchCriteria) 
        {
            SqlHelper.UpsertSearchPrams(GetConnectionString(), UserId, SearchCriteria);
            return RedirectToAction("UserSearchParamEntryScreen");
        }

        #endregion

        #region User Search Screen

        public IActionResult UserSearchScreen()
        {
            ViewBag.UserNameList = ConversionHelper.BindDropDown(SqlHelper.GetUserNameList(GetConnectionString()));
            ViewBag.RoleList = ConversionHelper.BindDropDown(SqlHelper.GetRoleList(GetConnectionString()));
            ViewBag.DepartmentList = ConversionHelper.BindDropDown(SqlHelper.GetDepartmentList(GetConnectionString()));           

            return View();
        }

        [HttpPost]
        public string SearchUserBySearchParams(int? userid = null, string? username=null, 
            string? role=null, DateTime? lastlogin=null, string? fname=null, string? lname=null, 
            string? department=null, DateTime? doj=null, int? mgrid = null, float? seniority=null, string? empcode = null)
        {
            return SqlHelper.SearchUserBySearchParams(GetConnectionString(), userid, username, role, lastlogin, fname,
                lname, department, doj, mgrid, seniority, empcode);
        }

        #endregion        

    }
}
