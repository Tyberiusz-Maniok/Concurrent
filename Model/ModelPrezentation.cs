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
        public abstract int RectWidth { get; }
        public abstract int RectHeight { get; }
        
        public abstract ObservableCollection<CircleDto> Circles(int count);
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
        // Potrzebuje odwołac sie do funkcji, ktora okresle ile kulek zrobic i w jakim obszarze 
        //private readonly RandomCircleMovement factory = new RandomCircleMovement(positionGenerator, 5);
        //private IPositionGenerator positionGenerator = new RandomPositionGenerator(100, 5);
        //private readonly ICircleMovementService factory = new RandomCircleMovementService(positionGenerator, 5);
        
        public override int RectWidth => 760;
        public override int RectHeight => 310;

        public override ObservableCollection<CircleDto> Circles(int count)
        {
            throw new NotImplementedException();
        }

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

