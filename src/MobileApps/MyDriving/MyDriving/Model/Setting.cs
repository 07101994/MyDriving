﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System.Collections.Generic;
using System.ComponentModel;

namespace MyDriving.Model
{
    public class Setting : INotifyPropertyChanged
    {
        string _value;

        public string Name { get; set; }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }

        public List<string> PossibleValues { get; set; }

        public bool IsButton { get; set; }
        public bool IsTextField { get; set; }

        public string ButtonUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}