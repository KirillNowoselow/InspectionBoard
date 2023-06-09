using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Models
{
    class Student
    {
        [Key] 
        public int id_student { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
    }
}
