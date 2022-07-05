namespace TerminalMaster.Model
{
    class Cartridge
    {
        public int Id { get; set; }
        public string Brand { get; set; } // Бренд устройства
        public string Model { get; set; } // Модель устройства
        public string VendorCode { get; set; } // Артикуль
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
