using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.Model
{
    class PhoneBook
    {
        public List<string> NameDisplayList = new List<string>() { "Имя", "Фамилия", "Отчество", "Должность", "Внутренний номер", "Мобильный номер"};
        public List<string> ElementContent = new List<string>() { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox"};
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; } // Имя
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } // Фамилия 
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } // Отчество
        [Display(Name = "Должность")]
        public string Post { get; set; } // Должность
        [Display(Name = "Внут.номер")]
        public string InternalNumber { get; set; } // Внутренный номер
        [Display(Name = "Моб.номер")]
        public string MobileNumber { get; set; } // Мобильный номер
        public PhoneBook(int id, string firstName, string lastName, string middleName, string post, string internalNumber, string mobileNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Post = post;
            InternalNumber = internalNumber;
            MobileNumber = mobileNumber;
        }

        public PhoneBook()
        {
        }
    }
}
