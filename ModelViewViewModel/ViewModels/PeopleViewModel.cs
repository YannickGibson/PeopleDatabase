using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

// Tohle je třeba nainstalovat přes NuGet, jinak Command dá moc práce
// The MVVM Light Toolkit helps you to separate your View from your Model
// which creates applications that are cleaner and easier to maintain and extend. 
// It also creates testable applications and allows you to have a much thinner user interface
// layer (which is more difficult to test automatically).
// http://www.mvvmlight.net/
using GalaSoft.MvvmLight.Command;

using ModelViewViewModel.Models;
using DependencyInjection.Validators;

namespace ModelViewViewModel.ViewModels
{
    /// <summary>
    /// ViewModel pro aplikaci
    /// </summary>

    public class PeopleViewModel : INotifyPropertyChanged
    {
        // pro navázání komunikace mezi GUI a ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        

        // FirstName, LastName, BirthDate, SocialSecurityNumber jsou bindovány z GUI

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BirthDate)));
            }
        }

        private string socialSecurityNumber;
        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            set
            {
                socialSecurityNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialSecurityNumber)));
            }
        }
        StringValidator stringValidator = new StringValidator();
        BirthDateValidator birthDateValidator = new BirthDateValidator();
        SocialSecurityNumberValidator socialSecurityNumberValidator = new SocialSecurityNumberValidator();

        public PeopleViewModel()
        {
            BirthDate = DateTime.Now - TimeSpan.FromDays(365*19);
        }


        private static ICommand _sendCommand;
        // SendCommand je bindovaný z GUI
        public ICommand SendCommand
        {
            get
            {
                if (_sendCommand == null)
                {
                    // RelayCommand je definovaný v MVVMLight
                    _sendCommand = new RelayCommand(
                        () =>
                        {
                            // Tady je práce, která se má odmakat, když se spustí command
                            Debug.WriteLine(string.Join(", ", FirstName, LastName, BirthDate, SocialSecurityNumber));

                            if(string.IsNullOrEmpty(FirstName)
                            || string.IsNullOrEmpty(LastName)
                            || BirthDate == default(DateTime) // therefore 0001/1/1 12:00AM is not valid
                            || string.IsNullOrEmpty(SocialSecurityNumber))
                            {
                                MessageBox.Show("Fill in all the fields");
                                return;
                            }

                            if (!stringValidator.IsValid(FirstName))
                            {
                                MessageBox.Show("First name is invalid");
                            }
                            else if (!stringValidator.IsValid(lastName))
                            {
                                MessageBox.Show("Last name is invalid");
                            }
                            else if (!birthDateValidator.IsValid(BirthDate))
                            {
                                MessageBox.Show("BirthDate is invalid");
                            }
                            else if (!socialSecurityNumberValidator.IsValid(SocialSecurityNumber, BirthDate))
                            {
                                MessageBox.Show("Social Security Number is invalid");
                            }
                            else
                            {
                                DatabaseModel.Database.AddPerson(FirstName, LastName, BirthDate, SocialSecurityNumber);
                                FirstName = "";
                                LastName = "";
                                BirthDate = DateTime.Now - TimeSpan.FromDays(365*19);
                                SocialSecurityNumber = "";
                                MessageBox.Show("Success!");
                            }
                        });
                }
                return _sendCommand;
            }
        }
    }
}
