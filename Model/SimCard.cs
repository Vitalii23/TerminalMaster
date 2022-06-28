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
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Оператор связи")]
        public string Operator { get; set; } // Оператор связи
        [Display(Name = "Идентификационный номер")]
        public string IdentNumber { get; set; } // Идентификационный номер (ИН)
        [Display(Name ="Фирма")]
        public string Brend { get; set; }
        [Display(Name = "Тип устройства")]
        public string TypeDevice { get; set; } // Тип устройства
        [Display(Name = "Номер телефона (TMS)")]
        public string TMS { get; set; } // Номер телефона (TMS)
        [Display(Name = "Уникальный серийный номер (ICC)")]
        public string ICC { get; set; } // Уникальный серийный номер sim-card (ICC)
        [Display(Name = "Индивидуальный предприниматель (ИП)")]
        public string IndividualEntrepreneur { get; set; } // Индивидуальный предприниматель (ИП)
        [Display(Name = "Статус")]
        public string Status { get; set; } // Статус
        public int IdIndividual { get; set; }

        public SimCard(int iD, string @operator, string identNumber, string typeDevice, string tms, string icc, string individualEntrepreneur, string status)
        {
            Id = iD;
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
