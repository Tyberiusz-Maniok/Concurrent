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
        public ICircleRepository CircleRepository { get; protected set; }


        public abstract int RectWidth { get; }
        public abstract int RectHeight { get; }

        public abstract double CircleSpeed { get; }
        
        private ObservableCollection<Circle> items;

        public virtual ObservableCollection<Circle> InitCircles(int number)
        {
            return new ObservableCollection<Circle>(CircleRepository.InitCircles(number));
        }

        public virtual ObservableCollection<Circle> Move()
        {
            CircleRepository.UpdateAllPosition();
            return new ObservableCollection<Circle>(CircleRepository.GetAll());
        }
/*        public ModelPrezentation()
        {
            this.CircleRepository = repository;
        }*/
        //public IPositionGenerator PositionGenerator
        //{
        //    get;
        //}
        //public ICircleMovementService Factory
        //{
        //    get;
        //}
        public static ModelPrezentation CreateApi()
        {
            return new ModelAPI();
        }


    }
    public class ModelAPI : ModelPrezentation
    {

        //private ObservableCollection<Circle> circles;

        public override int RectWidth => 720;
        public override int RectHeight => 405;
        public override double CircleSpeed => 30;
        //public ModelAPI(ICircleRepository repository) : base(repository) { }
        public ModelAPI()
        {
            //IPositionGenerator positionGenerator = new RandomPositionGenerator(50, Circle.radius);
            //ICircleMovementService movementService = new RandomCircleMovementService(positionGenerator, 15);
            this.CircleRepository = new DefaultCircleRepository(LogicFactory.GetRandomCircleMovementService(RectWidth, RectHeight, CircleSpeed));
        }

        //public ObservableCollection<Circle> Circles(int count)
 
        //public override ObservableCollection<CircleDto> Circles(int count)
        //=> factory.InitCircles(count);
        //public override void Move(IList Circles)
        //{
        //    factory.MoveCircle((ObservableCollection<CircleDto>)Circles, RectWidth, RectHeight);
        //}
    }
}

