using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 一个作用于某对象结构中各元素的操作，它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作
    /// 利用双分派技术 实现处理与数据机构的分离
    /// </summary>
    class _28_访问者模式
    {
        public void Main()
        {  
           //特点：Action和Human抽象类中的函数互为各自的参数，但是要保证Action中的方法是稳定的。是两个方法就是2个方法，万一增加了双性恋者，就不适用了
           //如果要增加一种"结婚"状态，只要重写一个"结婚"类继承自Action就可以
        }
    }
    /// <summary>
    /// 状态类（访问者）（个人感觉将Action看成一种数据更易理解）  增加访问者很方便
    /// </summary>
    abstract class Action
    {
        public abstract void GetManConclusion(Human human);
        public abstract void GetWomanConclusion(Human human);
    }
    abstract class Human
    {
        public abstract void Accept(Action action);
    }
    class Success:Action
    {
        public override void GetManConclusion(Human human)
        {
            Console.WriteLine("Man Success");
        }
        public override void GetWomanConclusion(Human human)
        {
            Console.WriteLine("Woman Sucess");
        }
    }
    class Fail:Action
    {
        public override void GetManConclusion(Human human)
        {
            Console.WriteLine("Man Faile");
        }
        public override void GetWomanConclusion(Human human)
        {
            Console.WriteLine("Woman Fail");
        }
    }
    class Man:Human
    {
        public override void Accept(Action action)
        {
            action.GetManConclusion(this);
        }
    }

    class Woman:Human
    {
        public override void Accept(Action action)
        {
            action.GetWomanConclusion(this);
        }
    }
}
