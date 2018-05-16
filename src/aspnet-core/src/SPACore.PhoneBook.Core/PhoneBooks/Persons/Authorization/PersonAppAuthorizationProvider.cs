using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPACore.PhoneBook.Authorization;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PersonAppPermissions"/> for all permission names.
    /// </summary>
    public class PersonAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Person 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var person = administration.CreateChildPermission(PersonAppPermissions.Person, L("Person"));
            person.CreateChildPermission(PersonAppPermissions.Person_CreatePerson, L("CreatePerson"));
            person.CreateChildPermission(PersonAppPermissions.Person_EditPerson, L("EditPerson"));
            person.CreateChildPermission(PersonAppPermissions.Person_DeletePerson, L("DeletePerson"));
            person.CreateChildPermission(PersonAppPermissions.Person_BatchDeletePersons, L("BatchDeletePersons"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PhoneBookConsts.LocalizationSourceName);
        }
    }

}