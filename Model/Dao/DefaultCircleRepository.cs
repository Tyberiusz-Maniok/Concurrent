using Logic.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> circles;
        private ICircleMovementService circleMovementService;

        //TODO usunac add i delete,init circles z parametrem ile ich ma byc, metoda robiaca wszystkie kolka, getallcircles, updateall, 

        public DefaultCircleRepository(ICircleMovementService circleMovementService)
        {
            this.circleMovementService = circleMovementService;
            this.circles = new List<Circle>();
        }


        public List<Circle> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateAllPosition()
        {
            throw new NotImplementedException();
        }

    }
}
