using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalMaster.Model;

namespace TerminalMaster.ViewModel
{
    class DataGets : INotifyPropertyChanged
    {
        public DataGets()
        {
          
        }

        private readonly Cartridge cartridge = new Cartridge();
        private readonly CashRegister cashRegister = new CashRegister();
        private readonly PhoneBook phoneBook = new PhoneBook();
        private readonly Printer printer = new Printer();
        private readonly SimCard simCard = new SimCard();

        public Dictionary<string, string> ElementCartridgeDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> ElementCashRegisterDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> ElementPhoneBookDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> ElementPrinterDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> ElementSimCardDictionary = new Dictionary<string, string>();

        public ObservableCollection<Cartridge> _cartridges = new ObservableCollection<Cartridge>();
        public ObservableCollection<CashRegister> _cashRegister = new ObservableCollection<CashRegister>();
        public ObservableCollection<PhoneBook> _phoneBook = new ObservableCollection<PhoneBook>();
        public ObservableCollection<Printer> _printer = new ObservableCollection<Printer>();
        public ObservableCollection<SimCard> _simCard = new ObservableCollection<SimCard>();
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
        public ObservableCollection<Cartridge> CartridgesList
        {
            get
            {
                //if(_cartridges != null)
                //{
                //    for(int i = 0; i <= 50; i++)
                //    {
                //        _cartridges.Add(new Cartridge(i, "Kyocera" + i, "TK-3190" + i, "КВ-00004" + i, "в работе"));
                //    }
                //}
                return _cartridges;
            }
            set
            {
                _cartridges = value;
                OnPropertyChanged("CartridgesList");
            }
        }
        public ObservableCollection<CashRegister> CashRegisterList
        {
            get { return _cashRegister; }
            set
            {
                _cashRegister = value;
                OnPropertyChanged("CashRegisterList");
            }
        }
        public ObservableCollection<PhoneBook> PhoneBookList
        {
            get { return _phoneBook; }
            set
            {
                _phoneBook = value;
                OnPropertyChanged("PhoneBookList");
            }
        }
        public ObservableCollection<Printer> PrinterList
        {
            get { return _printer; }
            set
            {
                _printer = value;
                OnPropertyChanged("PrinterList");
            }
        }
        public ObservableCollection<SimCard> SimCardList
        {
            get { return _simCard; }
            set
            {
                _simCard = value;
                OnPropertyChanged("SimCardList");
            }
        }

        /// <summary>
        /// List Element
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetElementCartridesList()
        {
            return ElementCartridgeDictionary;
        }
        public Dictionary<string, string> GetElementCashRegisterList()
        {
            return ElementCashRegisterDictionary;
        }
        public Dictionary<string, string> GetElementPhoneBookList()
        {
            return ElementPhoneBookDictionary;
        }
        public Dictionary<string, string> GetElementPrinterList()
        {
            return ElementPrinterDictionary;
        }
        public Dictionary<string, string> GetElementSimCardList()
        {
            return ElementSimCardDictionary;
        }

        /// <summary>
        /// Void add elment to dictionary
        /// </summary>
        /// /// <returns></returns>
        public void WriteElementList()
        {
            if (cartridge.NameDisplayList.Count == cartridge.ElementContent.Count)
            {
                for (int i = 0; i < cartridge.NameDisplayList.Count; i++)
                {
                    ElementCartridgeDictionary.Add(cartridge.NameDisplayList[i], cartridge.ElementContent[i]);
                }
            }

            if (cashRegister.NameDisplayList.Count == cashRegister.ElementContent.Count)
            {
                for (int i = 0; i < cashRegister.NameDisplayList.Count; i++)
                {
                    ElementCashRegisterDictionary.Add(cashRegister.NameDisplayList[i], cashRegister.ElementContent[i]);
                }
            }

            if (phoneBook.NameDisplayList.Count == phoneBook.ElementContent.Count)
            {
                for (int i = 0; i < phoneBook.NameDisplayList.Count; i++)
                {
                    ElementPhoneBookDictionary.Add(phoneBook.NameDisplayList[i], phoneBook.ElementContent[i]);
                }
            }

            if (printer.NameDisplayList.Count == printer.ElementContent.Count)
            {
                for (int i = 0; i < printer.NameDisplayList.Count; i++)
                {
                    ElementPrinterDictionary.Add(printer.NameDisplayList[i], printer.ElementContent[i]);
                }
            }

            if (simCard.NameDisplayList.Count == simCard.ElementContent.Count)
            {
                for (int i = 0; i < simCard.NameDisplayList.Count; i++)
                {
                    ElementSimCardDictionary.Add(simCard.NameDisplayList[i], simCard.ElementContent[i]);
                }
            }

        }
    }
}
