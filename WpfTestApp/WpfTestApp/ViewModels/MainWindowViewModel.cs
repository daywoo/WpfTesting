using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfTestApp.Models;

namespace WpfTestApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TestModel> _testList;

        public event PropertyChangedEventHandler PropertyChanged;

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
            TestList.CollectionChanged += TestList_CollectionChanged; ;
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
