using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons.DomainServices
{
    public interface IPersonManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitPerson();

    }
}
