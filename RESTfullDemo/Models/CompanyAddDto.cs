using RESTfullDemo.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RESTfullDemo.Models
{
    public class CompanyAddDto
    {
        [Required(ErrorMessage ="{0}是必填的")]
        [Display(Name = "姓名")]
        [MaxLength(50, ErrorMessage ="{0}的最大长度不能超过{1}")]
        public string Name { get; set; }

        [Display(Name="简介"), StringLength(500, MinimumLength = 10, ErrorMessage = "{0}的长度范围是{2}到{1}")]
        public string Introduction { get; set; }

        public ICollection<EmployeeAddDto>? Employees { get; set; } = new List<EmployeeAddDto>();
    }
}
