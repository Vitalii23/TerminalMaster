namespace TerminalMaster.Model
{
    class Printer
    {
        public int Id { get; set; }
        public string ModelPrinter { get; set; } // Модель принтера
        public string NamePort { get; set; } // Имена портов
        public string LocationPrinter { get; set; } // Расположение принтера
        public string OC { get; set; } // Среда ОС
        public string Status { get; set; } // Статус

        public Printer()
        {
        }
    }
}
