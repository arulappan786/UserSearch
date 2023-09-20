use UMS
go

drop proc spGetUserNameList
go

create procedure spGetUserNameList
as
begin

	select distinct UserId, UserName 
	from tbl_User
	order by UserId

end
go

drop procedure spGetRoleList
go

create procedure spGetRoleList
as
begin

	select row_number() over(order by [Role]) as RoleId, [Role] 
	from (
			select distinct [Role]
			from tbl_User
		) a

end
go

drop procedure spGetDepartmentList
go

create procedure spGetDepartmentList
as
begin

	select row_number() over(order by [Department]) as DepartmentId, [Department] 
	from (
			select distinct [Department]
			from tbl_User
		) a
end
go

drop procedure spGetUserFields
go

create procedure spGetUserFields
as
begin

	select column_id as FieldId, [name] as FieldName
	from sys.columns
	where object_id = object_id('tbl_user')
	and [name] not in ('UserId')
	order by column_id

end
go


drop procedure spUpsertSearchPrams
go

create procedure spUpsertSearchPrams
(@UserId int, @SearchCriteria varchar(max))
as
begin

	if exists(select 1 from [dbo].[tbl_SearchParameters] where UserId = @UserId)
	begin
		update [dbo].[tbl_SearchParameters] set [SearchCriteria] = @SearchCriteria
		where UserId = @UserId
	end
	else
	begin	
			INSERT INTO [dbo].[tbl_SearchParameters]
					   ([UserId]
					   ,[SearchCriteria])
				 VALUES
					   (@UserId
					   ,@SearchCriteria)

	end
end
go

drop procedure [dbo].[spGetSearchParamsByUserId]
go

create procedure spGetSearchParamsByUserId
(@UserId int)
as
begin

	select [SearchCriteria] from [dbo].[tbl_SearchParameters] where UserId = @UserId
	
end
go

drop procedure spSearchUserBySearchParams
go

create procedure spSearchUserBySearchParams
(
	@userid int=null, @username varchar(100)=null, @role varchar(50)=null,@lastlogin date=null, 
	@fname varchar(50)=null, @lname varchar(50)=null, @department varchar(50)=null, @doj date= null,
	@mgrid int=null, @seniority decimal(3,2)=null, @empcode varchar(20)=null
)
as
begin

	select * from [dbo].[tbl_User]
	where isnull(UserId,0) = ISNULL(@userid, isnull(UserId,0))
	and trim(lower(isnull(UserName,''))) like '%' + trim(lower(ISNULL(@username, isnull(UserName,'')))) + '%'
	and trim(lower(isnull([Role],''))) like '%'+ trim(lower(ISNULL(@role,isnull([Role],'')))) + '%'
	and cast(isnull(LastLogin,'1900-01-01') as date) = cast(ISNULL(@lastlogin, isnull(LastLogin,'1900-01-01')) as date)
	and trim(lower(isnull(FName,''))) like '%'+ trim(lower(ISNULL(@fname,isnull(FName,'')))) + '%'
	and trim(lower(isnull(LName,''))) like '%'+ trim(lower(ISNULL(@lname,isnull(LName,'')))) + '%'
	and trim(lower(isnull(Department,''))) like '%'+ trim(lower(ISNULL(@department, isnull(Department,'')))) + '%'
	and cast(isnull(DOJ,'1900-01-01') as date) = cast(ISNULL(@doj, isnull(DOJ,'1900-01-01')) as date)
	and trim(lower(isnull(MgrId,0))) = trim(lower(ISNULL(@mgrid, isnull(MgrId,0))))
	and isnull(Seniority,0) = ISNULL(@seniority, isnull(Seniority,0))
	and trim(lower(isnull(EmpCode,''))) like '%'+ trim(lower(ISNULL(@empcode, isnull(EmpCode,'')))) + '%'

end
go