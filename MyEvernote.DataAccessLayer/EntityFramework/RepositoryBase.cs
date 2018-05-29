using MyEvernote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        protected static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            //Context oluşturulurken başka işlem yapmaması için
            if (context == null)
            {
                lock (_lockSync)
                {
                    //Her ihtimale karşı ikinci bir güvenlik önlemi için double kontrol
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }

            }
        }
    }
}
