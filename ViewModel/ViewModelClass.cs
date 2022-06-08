using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Model;
using Logic.Service;
using Model.Dao;

namespace ViewModel
{
    public class ViewModelClass : ObservalbeObject
    {
        private int count;
        private readonly int _rectWidth;
        private readonly int _rectHeight;
        private readonly ModelPrezentation _model;
        private Thread circleUpdater;
        private bool _keepUpdating;
        private ObservableCollection<Circle> _circles;
        public ObservableCollection<Circle> Circles
        {
            get => _circles;
            set
            {
                if (value.Equals(_circles))
                    return;
                _circles = value;
                OnPropertyChanged(nameof(Circles));
            }
        }

        public ViewModelClass() : this(ModelPrezentation.CreateApi()) { }

        public ViewModelClass(ModelPrezentation model)
        {
            _keepUpdating = true;
            _model = model;
            _rectWidth = _model.RectWidth;
            _rectHeight = _model.RectHeight;
            Start = new RelayCommand(() => StartAction());
            Stop = new RelayCommand(() => StopAction());
        }



        public int Count
        {
            get => count;
            set
            {
                if (value.Equals(count))
                    return;
                if (value < 0)
                    value = 0;
                if (value > 2000)
                    value = 2000;
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public ICommand Start { get; set; }

        public ICommand Stop { get; set; }

        private void StopAction()
        {
            _keepUpdating = false;
            if (circleUpdater != null && circleUpdater.IsAlive)
            {
                circleUpdater.Join();
            }
            
        }
        public void StartAction()
        {
            _keepUpdating = true;
            Circles = _model.InitCircles(count);
            if (circleUpdater != null && circleUpdater.IsAlive)
            {
                circleUpdater.Join();
            }
            circleUpdater = new Thread(() => UpdateCircles());
            circleUpdater.Start();
            
        }

        public void UpdateCircles()
        {
            while (_keepUpdating)
            {
                Circles = _model.Move();
                Thread.Sleep(30);
            }
        }
        public int RectWidth
        {
            get => _rectWidth;
        }
        public int RectHeight
        {
            get => _rectHeight;
        }
    }
}

