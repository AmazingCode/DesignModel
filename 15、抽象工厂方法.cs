using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

    class _15_抽象工厂方法
    {
        public void Main()
        {
            IFactoryDatabase factory=new SqlServerFac();
            IDepartMent sqlServer=factory.GetInstance();
            sqlServer.Insert("helloworld!");
        }
    }
    interface IDepartMent
    {
        void Insert(string sql);//在数据库中插入一条记录
    }
    class SqlServer:IDepartMent
    {
        public void Insert(string sql)
        {
            Console.WriteLine("sqlServer执行sql插入语句！");
        }
    }

    class Access:IDepartMent
    {
         public void Insert(string sql)
         {
             Console.WriteLine("Access执行sql插入语句！");
         }
    }

    interface IFactoryDatabase
    {
        IDepartMent GetInstance();
    }

    class SqlServerFac:IFactoryDatabase
    {
        public IDepartMent GetInstance()
        {
            return new SqlServer();
        }
    }

    class AccessFac:IFactoryDatabase
    {
        public IDepartMent GetInstance()
        {
            return new Access();
        }
    }
}
