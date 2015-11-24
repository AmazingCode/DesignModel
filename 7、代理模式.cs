using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 什么是代理模式：本来有一个类A可以直接执行自己的方法就可以实现一个功能，现在先将这个类A作为一个属性传递给一个代理类，代理类在通过自己的方法调用A对象的方法，同时可以添加一些新的功能
    /// 为其他对象提供一种代理，用来控制对这个对象的访问。
    /// </summary>
    class _7_代理模式
    {
        public void Main()
        {   
        }
    }

    public interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
    }
    public class Pursuit:IGiveGift
    {
        public void GiveDolls()
        {
            Console.Write("Give Dolls");
        }
        public void GiveFlowers()
        {
            Console.Write("Give Flowers");
        }
    }
    public class Proxy:IGiveGift
    {
        private IGiveGift IGift;
        public Proxy(IGiveGift iGift)
        {
            this.IGift = iGift;
        }
        public void GiveDolls()
        {
            IGift.GiveFlowers();
            Console.WriteLine("proxy can do some badthing in this lol");
        }
        public void GiveFlowers()
        {
            IGift.GiveFlowers();
            Console.WriteLine("hello beauty,the flower is mine,not his");
        }
    }
}
