using Data.Dao;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    public abstract class CircleService : IService<Circle>
    {
        private ICircleRepository circleRepository;
        public CircleService(ICircleRepository circleRepository)
        {
            this.circleRepository = circleRepository;
        }
        public abstract List<Circle> FindAll();

        public abstract Circle findById(int id);

        public abstract void updateAll(Func<Circle> circleUpdateFunc);
    }
}
