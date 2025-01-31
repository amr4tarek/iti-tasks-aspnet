using Day_4.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day_4.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DepartmentNameRequired")]
    [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DepartmentNameMaxLength")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
