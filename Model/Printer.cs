using System;
using System.ComponentModel.DataAnnotations;

namespace TerminalMaster.Model
{
    class Printer
    {
        [Editable(false)]
        [Display(Name = "Принтера Id")]
        public int Id { get; set; }
        [Display(Name = "Бренд")]
        public string BrandPrinter { get; set; } // Фирма
        public string ModelPrinter { get; set; } // Модель принтера
        public string Cartridge { get; set; } // Катридж
        public string NamePort { get; set; } // Имена портов
        public string LocationPrinter { get; set; } // Расположение принтера
        public string OC { get; set; } // Среда ОС
        public string Status { get; set; } // Статус
        public string VendorCodePrinter { get; set; } // Артикули принтера
        public int Сounters { get; set; } // Счетчик страниц
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime DatePrinter { get; set; }
        public string DatePrinterString { get; set; }

        public Printer()
        {
        }
    }
}
