using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccsessLayer.EF
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object lockObject = new object();
        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (context==null)
            {
                lock (lockObject)
                {
                    context = new DatabaseContext();
                }
                
            }
            
        }
    }
}
