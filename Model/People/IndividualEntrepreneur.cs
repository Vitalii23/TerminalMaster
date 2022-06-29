﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.Model.People
{
    class IndividualEntrepreneur
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; } // Имя
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } // Фамилия 
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } // Отчество
    }
}