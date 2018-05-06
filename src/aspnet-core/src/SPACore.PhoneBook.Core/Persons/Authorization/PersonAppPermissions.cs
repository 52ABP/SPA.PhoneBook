using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PersonAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class PersonAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// Person管理权限_自带查询授权
        /// </summary>
        public const string Person = "Pages.Person";

        /// <summary>
        /// Person创建权限
        /// </summary>
        public const string Person_CreatePerson = "Pages.Person.CreatePerson";
        /// <summary>
        /// Person修改权限
        /// </summary>
        public const string Person_EditPerson = "Pages.Person.EditPerson";
        /// <summary>
        /// Person删除权限
        /// </summary>
        public const string Person_DeletePerson = "Pages.Person.DeletePerson";

        /// <summary>
        /// Person批量删除权限
        /// </summary>
        public const string Person_BatchDeletePersons = "Pages.Person.BatchDeletePersons";

    }

}

