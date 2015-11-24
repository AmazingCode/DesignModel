using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 使多个对象都有机会处理请求，将所有对象连成一个链，并且沿着这条链传递请求，直到有一个对象处理它为止
    /// </summary>
    class _24_职责链模式
    {
        public void Main()
        {
            Manager m3=new Manager3();
            Manager m2 =new Manager2(m3);
            Manager m1=new Manager1(m2);
            m1.Handle("level2");
        }
    }

    abstract class Manager
    {
        protected Manager MyBoss;
        public abstract void Handle(string oneThing);
    }
    /// <summary>
    /// 级别为1的Manager
    /// </summary>
    class Manager1:Manager
    {
        public Manager1(Manager boss)
        {
            MyBoss = boss;
        }
        //public void SetBoss(Manager boss)//代替构造函数初始化在 客户端调用的时候更加灵活，可以随意的更改传递顺序和请求处理节点
        //{
        //    this.MyBoss = boss;
        //}
        public override void Handle(string oneThing)
        {
            if (oneThing.Equals("level1"))
            {
                Console.WriteLine("I can handle the "+oneThing);
                return;
            }
            Console.WriteLine("I can not handle the"+oneThing);
            MyBoss.Handle(oneThing);
        }
    }

    class Manager2:Manager
    {
        public Manager2(Manager boss)
        {
            MyBoss = boss;
        }
        public override void  Handle(string oneThing)
        {
 	       if (oneThing.Equals("level2"))
 	       {
 	           Console.WriteLine("I can handle"+oneThing);
               return;
 	       }
           Console.WriteLine("I can not Handle the"+oneThing);
           MyBoss.Handle(oneThing);
        }
    }

    class Manager3:Manager
    {
        public Manager3()
        {
            MyBoss = null;
        }
        public override void Handle(string oneThing)
        {
            if (oneThing.Equals("level3"))
            {
                Console.WriteLine("I can handle the "+oneThing+"Because i am CEO");
                return;
            }
        }
    }
}
