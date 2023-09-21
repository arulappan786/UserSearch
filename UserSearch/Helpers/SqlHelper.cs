using Microsoft.Data.SqlClient;
using System.Data;

namespace UserSearch.Helpers
{
    public static class SqlHelper
    {
        public static DataTable GetUserNameList(string? conString)
        {
            DataTable dtUserNameList = new DataTable();

            if (conString == null) return dtUserNameList;            

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmdUserList = new SqlCommand("spGetUserNameList", con);
                    cmdUserList.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpUserList = new SqlDataAdapter(cmdUserList);
                    adpUserList.Fill(dtUserNameList);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return dtUserNameList;
        }

        public static DataTable GetRoleList(string? conString)
        {
            DataTable dtRoleList = new DataTable();

            if (conString == null) return dtRoleList;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();                    
                    SqlCommand cmdRoleList = new SqlCommand("spGetRoleList", con);
                    cmdRoleList.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpRoleList = new SqlDataAdapter(cmdRoleList);
                    adpRoleList.Fill(dtRoleList);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dtRoleList;
        }

        public static DataTable GetDepartmentList(string? conString)
        {
            DataTable dtDepartmentList = new DataTable();

            if (conString == null) return dtDepartmentList;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();                    
                    SqlCommand cmdDepartmentList = new SqlCommand("spGetDepartmentList", con);
                    cmdDepartmentList.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpDepartmentList = new SqlDataAdapter(cmdDepartmentList);
                    adpDepartmentList.Fill(dtDepartmentList);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dtDepartmentList;
        }

        public static DataTable GetUserFieldList(string? conString)
        {
            DataTable dtUserFieldList = new DataTable();

            if (conString == null) return dtUserFieldList;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmdUserFieldList = new SqlCommand("spGetUserFields", con);
                    cmdUserFieldList.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpUserFieldList = new SqlDataAdapter(cmdUserFieldList);
                    adpUserFieldList.Fill(dtUserFieldList);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dtUserFieldList;
        }

        public static object? GetSearchParamsByUserId(string? conString, int UserId)
        {
            object objParams = new object();
            if(conString == null) return objParams;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmdSaveSearchParam = new SqlCommand("spGetSearchParamsByUserId", con);
                    cmdSaveSearchParam.CommandType = CommandType.StoredProcedure;
                    cmdSaveSearchParam.Parameters.Add(new SqlParameter("@UserId", UserId));
                    objParams = cmdSaveSearchParam.ExecuteScalar();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return objParams;
        }

        public static void UpsertSearchPrams(string? conString, int UserId, string SearchCriteria)
        {
            if (conString == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmdSaveSearchParam = new SqlCommand("spUpsertSearchPrams", con);
                    cmdSaveSearchParam.CommandType = CommandType.StoredProcedure;
                    cmdSaveSearchParam.Parameters.Add(new SqlParameter("@UserId", UserId));
                    cmdSaveSearchParam.Parameters.Add(new SqlParameter("@SearchCriteria", SearchCriteria));
                    cmdSaveSearchParam.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string SearchUserBySearchParams(string? conString, int? userid = null, string? username = null,
            string? role = null, DateTime? lastlogin = null, string? fname = null, string? lname = null,
            string? department = null, DateTime? doj = null, int? mgrid = null, float? seniority = null, string? empcode = null)
        {
            string result = string.Empty;
            if (conString == null) return result;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    DataTable dtUserSearchList = new DataTable();
                    SqlCommand cmdUserSearchList = new SqlCommand("spSearchUserBySearchParams", con);
                    cmdUserSearchList.CommandType = CommandType.StoredProcedure;

                    SqlParameter userid_param = new SqlParameter();
                    userid_param.ParameterName = "@userid";
                    userid_param.DbType = DbType.Int32;
                    userid_param.Value = userid == null ? DBNull.Value : userid;
                    userid_param.SqlValue = userid == null ? DBNull.Value : userid;
                    userid_param.IsNullable = true;
                    userid_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(userid_param);

                    SqlParameter username_param = new SqlParameter();
                    username_param.ParameterName = "@username";
                    username_param.DbType = DbType.String;
                    username_param.Value = username == null ? DBNull.Value : username;
                    username_param.SqlValue = username == null ? DBNull.Value : username;
                    username_param.IsNullable = true;
                    username_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(username_param);

                    SqlParameter role_param = new SqlParameter();
                    role_param.ParameterName = "@role";
                    role_param.DbType = DbType.String;
                    role_param.Value = role == null ? DBNull.Value : role;
                    role_param.SqlValue = role == null ? DBNull.Value : role;
                    role_param.IsNullable = true;
                    role_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(role_param);

                    SqlParameter lastlogin_param = new SqlParameter();
                    lastlogin_param.ParameterName = "@lastlogin";
                    lastlogin_param.DbType = DbType.DateTime;
                    lastlogin_param.Value = lastlogin == null ? DBNull.Value : lastlogin;
                    lastlogin_param.SqlValue = lastlogin == null ? DBNull.Value : lastlogin;
                    lastlogin_param.IsNullable = true;
                    lastlogin_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(lastlogin_param);

                    SqlParameter fname_param = new SqlParameter();
                    fname_param.ParameterName = "@fname";
                    fname_param.DbType = DbType.String;
                    fname_param.Value = fname == null ? DBNull.Value : fname;
                    fname_param.SqlValue = fname == null ? DBNull.Value : fname;
                    fname_param.IsNullable = true;
                    fname_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(fname_param);

                    SqlParameter lname_param = new SqlParameter();
                    lname_param.ParameterName = "@lname";
                    lname_param.DbType = DbType.String;
                    lname_param.Value = lname == null ? DBNull.Value : lname;
                    lname_param.SqlValue = lname == null ? DBNull.Value : lname;
                    lname_param.IsNullable = true;
                    lname_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(lname_param);

                    SqlParameter department_param = new SqlParameter();
                    department_param.ParameterName = "@department";
                    department_param.DbType = DbType.String;
                    department_param.Value = department == null ? DBNull.Value : department;
                    department_param.SqlValue = department == null ? DBNull.Value : department;
                    department_param.IsNullable = true;
                    department_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(department_param);

                    SqlParameter doj_param = new SqlParameter();
                    doj_param.ParameterName = "@doj";
                    doj_param.DbType = DbType.Date;
                    doj_param.Value = doj == null ? DBNull.Value : doj;
                    doj_param.SqlValue = doj == null ? DBNull.Value : doj;
                    doj_param.IsNullable = true;
                    doj_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(doj_param);

                    SqlParameter mgrid_param = new SqlParameter();
                    mgrid_param.ParameterName = "@mgrid";
                    mgrid_param.DbType = DbType.Int16;
                    mgrid_param.Value = mgrid == null ? DBNull.Value : mgrid;
                    mgrid_param.SqlValue = mgrid == null ? DBNull.Value : mgrid;
                    mgrid_param.IsNullable = true;
                    mgrid_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(mgrid_param);

                    SqlParameter seniority_param = new SqlParameter();
                    seniority_param.ParameterName = "@seniority";
                    seniority_param.DbType = DbType.Decimal;
                    seniority_param.Value = seniority == null ? DBNull.Value : seniority;
                    seniority_param.SqlValue = seniority == null ? DBNull.Value : seniority;
                    seniority_param.IsNullable = true;
                    seniority_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(seniority_param);

                    SqlParameter empcode_param = new SqlParameter();
                    empcode_param.ParameterName = "@empcode";
                    empcode_param.DbType = DbType.String;
                    empcode_param.Value = empcode == null ? DBNull.Value : empcode;
                    empcode_param.SqlValue = empcode == null ? DBNull.Value : empcode;
                    empcode_param.IsNullable = true;
                    empcode_param.Direction = ParameterDirection.Input;
                    cmdUserSearchList.Parameters.Add(empcode_param);

                    SqlDataAdapter adpUserSearchList = new SqlDataAdapter(cmdUserSearchList);
                    adpUserSearchList.Fill(dtUserSearchList);

                    result = ConversionHelper.ConvertIntoJson(dtUserSearchList);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
