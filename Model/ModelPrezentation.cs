using Logic.Dto;
using Logic.Service;
using Model.Dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public abstract class ModelPrezentation
    {
        public ICircleRepository CircleRepository { get;  }


        public int RectWidth { get; }
        public int RectHeight { get; }
        
        private ObservableCollection<Circle> items;

        
        public abstract void Move(IList circles);
        public IPositionGenerator PositionGenerator
        {
            get;
        }
        public ICircleMovementService Factory
        {
            get;
        }
        public static ModelPrezentation CreateApi()
        {
            return new ModelAPI();
        }


    }
    internal class ModelAPI : ModelPrezentation
    {
     

        private ObservableCollection<Circle> circles;
    
        public int RectWidth => 760;
        public int RectHeight => 310;

        //public ObservableCollection<Circle> Circles(int count)
 

        public override void Move(IList circles)
        {
            throw new NotImplementedException();
        }

        
     
        
        //public override ObservableCollection<CircleDto> Circles(int count)
        //=> factory.InitCircles(count);
        //public override void Move(IList Circles)
        //{
        //    factory.MoveCircle((ObservableCollection<CircleDto>)Circles, RectWidth, RectHeight);
        //}
    }
}

