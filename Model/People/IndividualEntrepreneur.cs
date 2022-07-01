using System.ComponentModel.DataAnnotations;

namespace TerminalMaster.Model.People
{
    class IndividualEntrepreneur
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } // Фамилия 
        [Display(Name = "Имя")]
        public string FirstName { get; set; } // Имя
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; } // Отчество
        [Display(Name = "ОГРНИП")]
        public string PSRNIE { get; set; }  // ОГРНИП
        [Display(Name = "ИНН")]
        public string TIN { get; set; } // ИНН
    }
}
