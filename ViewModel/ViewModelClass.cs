using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;



namespace ViewModel
{
    public class ViewModelClass : ObservalbeObject
    {
        private int count;
        private readonly int _rectWidth;
        private readonly int _rectHeight;
        private readonly ModelPrezentation _model;
        private IList _circles;

        public ViewModelClass() : this(ModelPrezentation.CreateApi()) { }

        public ViewModelClass(ModelPrezentation modelPrezentation)
        {
            _model = modelPrezentation;
            _rectWidth = modelPrezentation.RectWidth;
            _rectHeight = modelPrezentation.RectHeight;
            Start = new RelayCommand(() => StartAction());
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

        public void StartAction()
        {
            //Circles = _model.Circles(count);
            _model.Move(Circles);
        }
        public int RectWidth
        {
            get => _rectWidth;
        }
        public int RectHeight
        {
            get => _rectHeight;
        }
        public IList Circles
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
    }
}

