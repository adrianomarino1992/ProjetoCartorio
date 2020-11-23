using System;
using System.Collections.Generic;
using System.Text;
using DataBaseLayer.ORM;
using DataBaseLayer;

namespace BusinessLayer
{
   public class ORMBusiness : DefaultORM
    {
        public ORMBusiness(IConnection connection) : base(connection)
        {

        }

    }
}
