using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dsr_betalling.Annotations;
using dsr_betalling.Common;
using dsr_betalling.Handler;
using dsr_betalling.Model;

namespace dsr_betalling.ViewModel
{
    class vmAddEditAccount : INotifyPropertyChanged
    {
        private bool _loadingIcon;
        private ObservableCollection<Chip> _chipObservableCollection;

        public ObservableCollection<Chip> ChipObservableCollection
        {
            get { return _chipObservableCollection; }
            set
            {
                _chipObservableCollection = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }
        public string AccountHolderName { get; set; }
        public float Balance { get; set; }
        public float Funds { get; set; }

        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set
            {
                _loadingIcon = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand AddChipCommand { get; set; }
        public ICommand DeleteChipCommand { get; set; }
        public ICommand AddFundsCommand { get; set; }

        public vmAddEditAccount()
        {
            ChipObservableCollection = new ObservableCollection<Chip>();

            //Only for EditAccount
            Populate();
        }

        public async void AddFunds(float funds)
        {
            // point to handler which have the add funds method.
        }

        //AddAccount
        public async void AddAccount()
        {
            await AccountHandler.CreateAccountAsync(new Account(Id, AccountHolderName, Balance));
        }

        //EditAccount
        public async void EditAccount()
        {
            await AccountHandler.UpdateAccountAsync(new Account(Id, AccountHolderName, Balance));
        }

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private async void Populate()
        {
            try
            {
                LoadingIcon = true;
                var listOfChips = await Facade.GetListAsync(new Chip());
                //var listOfChips = AccountObservableCollection;
                foreach (var chip in listOfChips)
                {
                    ChipObservableCollection.Add(chip);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }
        #region NotifyPropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
