using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Day_4.Resource;
namespace Day_4.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }
    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameRequired")]
    [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameMaxLength")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRequired")]
    [Range(18, 65, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AgeRange")]
    public int Age { get; set; }

    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CityRequired")]
    [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CityMaxLength")]
    public string City { get; set; } = null!;

    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DepartmentRequired")]
    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
