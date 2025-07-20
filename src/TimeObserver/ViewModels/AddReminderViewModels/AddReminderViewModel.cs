using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeObserver.Models.Reminders;

namespace TimeObserver.ViewModels.AddReminderViewModels {
    public abstract partial class AddReminderViewModel : ViewModel {
        [RelayCommand(CanExecute = nameof(CanConstruct))]
        private void Add() {
            var reminder = ConstructReminder();
            App.RemindersSystem.AddReminder(reminder);
        }

        protected abstract bool CanConstruct();

        protected abstract Reminder ConstructReminder();
    }
}
