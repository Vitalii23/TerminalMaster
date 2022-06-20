using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.Model
{
    class Printer
    {
        public List<string> NameDisplayList = new List<string>() { "Имя пользователя", "Имя принтера", "Модель принтера", "Имена портов", "Расположение", "Среда ОС" };
        public List<string> ElementContent = new List<string>() { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox"};
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Имя пользователя")]
        public string NameUser { get; set; } // Имя пользователя
        [Display(Name = "Имя принтера")]
        public string NamePrinter { get; set; } // Имя принтера
        [Display(Name = "Модель принтера")]
        public string Model { get; set; } // Модель принтера
        [Display(Name = "Имена портов")]
        public string NamePort { get; set; } // Имена портов
        [Display(Name = "Расположение")]
        public string Location { get; set; } // Расположение принтера
        [Display(Name = "Среда ОС")]
        public string OC { get; set; } // Среда ОС
        public Printer(int id, string nameUser, string namePrinter, string model, string namePort, string location, string oс)
        {
            Id = id;
            NameUser = nameUser;
            NamePrinter = namePrinter;
            Model = model;
            NamePort = namePort;
            Location = location;
            OC = oс;
        }

        public Printer()
        {
        }
    }
}
