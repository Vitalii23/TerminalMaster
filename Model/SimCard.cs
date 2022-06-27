using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.Model
{
    internal class SimCard
    {
        public List<string> NameDisplayList = new List<string>() { "Оператор связи", "Идентификационный номер", "Тип устройства", 
                                                                    "Номер телефона (TMS)", "Уникальный серийный номер (ICC)", "Пользователь", "Статус" };
        public List<string> ElementContent = new List<string>() { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "ComboBox"};
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Оператор связи")]
        public string Operator { get; set; } // Оператор связи
        [Display(Name = "Идентификационный номер")]
        public string IdentNumber { get; set; } // Идентификационный номер (ИН)
        [Display(Name ="Фирма")]
        public string Brend { get; set; }
        [Display(Name = "Тип устройства")]
        public string TypeDevice { get; set; } // Тип устройства
        [Display(Name = "Номер телефона (TMS)")]
        public int TMS { get; set; } // Номер телефона (TMS)
        [Display(Name = "Уникальный серийный номер (ICC)")]
        public int ICC { get; set; } // Уникальный серийный номер sim-card (ICC)
        [Display(Name = "Индивидуальный предприниматель (ИП)")]
        public string IndividualEntrepreneur { get; set; } // Индивидуальный предприниматель (ИП)
        [Display(Name = "Статус")]
        public string Status { get; set; } // Статус

        public SimCard(int iD, string @operator, string identNumber, string typeDevice, int tms, int icc, string individualEntrepreneur, string status)
        {
            ID = iD;
            Operator = @operator;
            IdentNumber = identNumber;
            TypeDevice = typeDevice;
            TMS = tms;
            ICC = icc;
            IndividualEntrepreneur = individualEntrepreneur;
            Status = status;
        }

        public SimCard()
        {
        }
    }
}
