using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            EditGridCommand = new RelayCommand(ClickMeEvent);
            TestList.CollectionChanged += TestList_CollectionChanged; ;
        }

        public void ClickMeEvent()
        {
            MessageBox.Show("BOOM");
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
        }
        #endregion
    }
}
