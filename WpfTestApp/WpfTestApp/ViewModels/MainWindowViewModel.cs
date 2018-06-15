using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfTestApp.Models;

namespace WpfTestApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TestModel> _testList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand EditGridCommand { get; set; }

        public ObservableCollection<TestModel> TestList
        {
            get
            {
                return _testList;
            }
            set
            {
                _testList = value;
            }
        }

        #region ctor
        public MainWindowViewModel()
        {
            InitData();
            InitEvents();
            InitCommands(); 
        }

        private void InitCommands()
        {
            EditGridCommand = new RelayCommand(RowEndEvent);
        }

        private void InitEvents()
        {
            TestList.CollectionChanged += TestList_CollectionChanged;
        }
        #endregion

        public void RowEndEvent()
        {
            MessageBox.Show("Row Editing Has Ended" + String.Join(",",TestList.Select(x => x.Value)));
        }

        public void PropWasChanged(object s, PropertyChangedEventArgs e)
        {

        }

        private void TestList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }



        void TestModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListGrid")
            {

            }
        }

        private void InitData()
        {
            _testList = new ObservableCollection<TestModel>() {
                new TestModel() { Name = "testname1", Value = "testvalue1" },
                new TestModel() { Name = "testname2", Value = "testvalue2" },
            };

            foreach(var model in _testList)
            {
                model.PropertyChanged += (s, e) => { PropWasChanged(s,e); };
            }
        }
        
    }
}
