using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.Model
{
    class Cartridge
    {
        public List<string> NameDisplayList = new List<string>() { "Бренд", "Модель", "Артикуль", "Статус" };
        public List<string> ElementContent = new List<string>() { "ComboBox", "ComboBox", "TextBox", "ComboBox" };
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name ="Бренд")]
        public string Brand { get; set; } // Бренд устройства
        [Display(Name = "Модель")]
        public string Model { get; set; } // Модель устройства
        [Display(Name = "Артикуль")]
        public string VendorCode { get; set; } // Артикуль
        [Display(Name = "Статус")]
        public string Status { get; set; } // Состояние
        public Cartridge(int id, string brand, string model, string vendorCode, string status)
        {
            Id = id;
            Brand = brand;
            Model = model;
            VendorCode = vendorCode;
            Status = status;
        }


        public Cartridge()
        {
        }
    }

}
