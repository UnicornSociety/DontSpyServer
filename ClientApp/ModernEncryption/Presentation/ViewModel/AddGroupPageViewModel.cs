﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    class AddGroupPageViewModel : INotifyPropertyChanged
    {
        private AddGroupPage _view;

        public string Title { get; set; } = "AddGroupPage";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public ObservableCollection<User> Contacts { get; }

        public AddGroupPageViewModel()
        {
            Contacts = new ObservableCollection<User>();

            Contacts.Add(new User("Lukas", "Ruf", "lukas.ruf@sfzlab.de"));
            Contacts.Add(new User("Mai", "Saito", "mai.saito@sfzlab.de"));
            Contacts.Add(new User("Max", "Mustermann", "max@mustermann.de"));
            Contacts.Add(new User("Tobias", "Straub", "tobias.straub@sfzlab.de"));
            Contacts.Add(new User("Helmut", "Ruf", "helmut.ruf@sfzlab.de")); Surname = "Mustermann";
        }
        public void SetView(AddGroupPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
