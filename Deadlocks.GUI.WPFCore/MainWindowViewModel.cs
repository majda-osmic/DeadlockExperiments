using Deadlocks.DAL;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Deadlocks.GUI.WPFCore
{
    public class MainWindowViewModel : NotificationObject
    {
        private readonly AsyncDataAccessWrapper _dal;

        public ICommand Version1AsyncCommand { get; }
        public ICommand Version2AsyncCommand { get; }
        public ICommand Version3AsyncCommand { get; }
        public ICommand Version4AsyncCommand { get; }

        public ICommand SurpriseCommand { get;  }
        public ICommand Version1Command { get; }
        public ICommand Version2Command { get; }
        public ICommand Version3Command { get; }
        public ICommand Version4Command { get; }

        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set => SetField(ref _text, value);
        }

        public MainWindowViewModel()
        {
            #region async delegates
            Version1AsyncCommand = new DelegateCommand(async () => await OnVersion1AsyncSelected());
            Version2AsyncCommand = new DelegateCommand(async () => await OnVersion2AsyncSelected());
            Version3AsyncCommand = new DelegateCommand(async () => await OnVersion3AsyncSelected());
            Version4AsyncCommand = new DelegateCommand(async () => await OnVersion4AsyncSelected());
            #endregion

            #region sync delegates
            Version1Command = new DelegateCommand(OnVersion1Selected);
            Version2Command = new DelegateCommand(OnVersion2Selected);
            Version3Command = new DelegateCommand(OnVersion3Selected);
            Version4Command = new DelegateCommand(OnVersion4Selected);
            #endregion

            _dal = new AsyncDataAccessWrapper();
        }


        #region async

        private async Task OnVersion1AsyncSelected()
        {
            Reset();
            Text = await _dal.GetDataAsync_V1();
        }

        private async Task OnVersion2AsyncSelected()
        {
            Reset();
            Text = await _dal.GetDataAsync_V2();
        }

        private async Task OnVersion3AsyncSelected()
        {
            Reset();
            Text = await _dal.GetDataAsync_V3();
        }

        private async Task OnVersion4AsyncSelected()
        {
            Reset();
            Text = await _dal.GetDataAsync_V4();
        }

        #endregion


        #region sync
        private void OnVersion1Selected()
        {
            Reset();
            Text = Task.Run(async () => await _dal.GetDataAsync_V1()).Result;
        }

        private void OnVersion2Selected()
        {
            Reset();
            Text = Task.Run(async () => await _dal.GetDataAsync_V2()).Result;
        }

        private void OnVersion3Selected()
        {
            Reset();
            Text = Task.Run(async () => await _dal.GetDataAsync_V3()).Result;
        }
        private void OnVersion4Selected()
        {
            Reset();
            Text = Task.Run(async () => await _dal.GetDataAsync_V4()).Result;
        }

        #endregion

        private void Reset() => Text = "Getting Data";
    }

}
