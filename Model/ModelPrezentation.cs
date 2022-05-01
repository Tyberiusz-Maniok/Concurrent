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
        //public ICircleRepository CircleRepository { get; protected set; }

        public abstract int RectWidth { get; }
        public abstract int RectHeight { get; }

        public abstract double CircleSpeed { get; }
        
        private ObservableCollection<Circle> items;

        public virtual ObservableCollection<Circle> InitCircles(int number)
        {
            //return new ObservableCollection<Circle>(CircleRepository.InitCircles(number));
            throw new NotImplementedException();
        }

        public virtual ObservableCollection<Circle> Move()
        {
            //CircleRepository.UpdateAllPosition();
            //return new ObservableCollection<Circle>(CircleRepository.GetAll());
            throw new NotImplementedException();
        }
        public static ModelPrezentation CreateApi()
        {
            return new ModelAPI();
        }


    }
    public class ModelAPI : ModelPrezentation
    {

        public override int RectWidth => 720;
        public override int RectHeight => 405;
        public override double CircleSpeed => 10;
        public ModelAPI()
        {
            //this.CircleRepository = new DefaultCircleRepository(LogicFactory.GetRandomCircleMovementService(RectWidth, RectHeight, CircleSpeed));
        }

    }
}

