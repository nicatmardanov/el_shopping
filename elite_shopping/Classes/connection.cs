using elite_shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elite_shopping.Classes
{
    public class connection
    {
        public static elite_shoppingEntities el_entities
        {
            get
            {
                return new elite_shoppingEntities();
            }

        }
    }
}