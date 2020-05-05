using CFT.NetCore.WebAppDemo.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Entities
{
    public class AuthorDto
    {
        [Required(ErrorMessage ="必须提供姓名")]
        [MaxLength(20,ErrorMessage ="姓名长度必须小于等于20个字符")]
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        [Required(ErrorMessage ="必须提供出生地")]
        [MaxLength(ErrorMessage ="出生地长度必须等于40个字符")]
        public string BirthPlace { get; set; }
        [NoSpace]
        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        public string Email { get; set; }
    }
}
