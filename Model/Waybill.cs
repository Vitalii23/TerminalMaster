using System;

namespace TerminalMaster.Model
{
    class Waybill
    {
        public int ID { get; set; }
        public string NameDocument { get; set;}
        public int NumberDocument { get; set; }
        public string NumberSuppliers { get; set; }
        public DateTime DateDocument { get; set; }
        public string DateDocumentString { get; set; }
        public string FilePDF { get; set; }
        public int IdHolder { get; set; }
        public string Holder { get; set; }
    }
}
