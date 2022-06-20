using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TerminalMaster.Model
{
    class CashRegister
    {
        public List<string> NameDisplayList = new List<string>() { "ККМ", "Бренд", "Заводской номер", "Серийный номер", "Номер счета", 
            "Владелец", "Пользователь", "Дата получения", "Место нахождения" };
        public List<string> ElementContent = new List<string>() { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "CalendarDatePicker", "TextBox" };
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ККМ")]
        public string Name { get; set; } // ККМ
        [Display(Name = "Бренд")]
        public string Brend { get; set; } // Бренд устройства
        [Display(Name = "Заводской номер")]
        public string FactoryNumber { get; set; } // Заводской номер
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; } // Серийный номер
        [Display(Name = "Номер счета")]
        public string PaymentNumber { get; set; } // Номер счета
        [Display(Name = "Владелец")]
        public string Holder { get; set; } // Владелец по договору
        [Display(Name = "Пользователь")]
        public string User { get; set; } // Пользователь
        [Display(Name = "Дата получения")]
        public DateTime DateReception { get; set; } // Дата получения
        [Display(Name = "Место нахождения")]
        public string Location { get; set; } // Место нахождения
        public CashRegister(int id, string name, string brend, string factoryNumber, string serialNumber, 
            string paymentNumber, string holder, string user, DateTime dateReception, string location)
        {
            Id = id;
            Name = name;
            Brend = brend;
            FactoryNumber = factoryNumber;
            SerialNumber = serialNumber;
            PaymentNumber = paymentNumber;
            Holder = holder;
            User = user;
            DateReception = dateReception;
            Location = location;
        }

        public CashRegister()
        {
        }
    }
}
