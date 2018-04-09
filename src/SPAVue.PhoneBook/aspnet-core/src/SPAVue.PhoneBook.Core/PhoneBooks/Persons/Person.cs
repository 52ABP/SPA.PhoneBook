using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using SPAVue.PhoneBook.PhoneBooks.PhoneNumbers;

namespace SPAVue.PhoneBook.PhoneBooks.Persons
{
    /// <summary>
    /// 人员
    /// </summary>
    
    public class Person :FullAuditedEntity
    {

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [MaxLength(PhoneBookConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        [MaxLength(PhoneBookConsts.MaxAddressLength)]
        public string Address { get; set; }



        /// <summary>
        /// 电话号码的属性
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

    }
}
