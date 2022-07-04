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
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime DateReception { get; set; } // Дата получения
        [Display(Name = "Место нахождения")]
        public string Location { get; set; } // Место нахождения
        public int IdHolder { get; set; }
        public int IdUser { get; set; }

        public CashRegister()
        {
        }
    }
}
