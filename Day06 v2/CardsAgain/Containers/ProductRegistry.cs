using CardsAgain.DAOs;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAgain.Containers
{
    public  class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            string connectionstring = "Data Source=USC-W-CRCTV93-A;Initial Catalog=AdventureWorks2019;Integrated Security=True";

            this.For<IProduct>().Use<DAOProduct>().Ctor<string>("connectionstring").Is(connectionstring);
            this.For<ILogic>().Use<DAOLogic>().Ctor<string>("connectionstring").Is(connectionstring);   // a business layer should not have a connection string, as it should not be accessing the database directly

            this.Policies.SetAllProperties(y => y.WithAnyTypeFromNamespaceContainingType<IProduct>());
            this.Policies.SetAllProperties(y => y.WithAnyTypeFromNamespaceContainingType<ILogic>());
        }
    }
}
