﻿using RESTfullDemo.Entities;
using System;

namespace RESTfullDemo.Models
{
    public class EmployeeAddDto
    {
        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
