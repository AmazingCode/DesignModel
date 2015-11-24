using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class 简单工厂模式
    {
        public void Main()
        {
            var oper = Factory.GetOperat("1");
            oper.NumberA = 10;
            oper.NumberB = 5;
            oper.GetResult();
        }
    }
   abstract  class Operat
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public virtual double GetResult()
        {
            return 0;
        }
    }
    class Add : Operat
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Sub : Operat
    {
        public override double GetResult()
        {
            return this.NumberA - this.NumberB;
        }
    }
    /// <summary>
    /// 工厂类
    /// </summary>
    class Factory
    {

        public static Operat GetOperat(string flag)
        {
            switch (flag)
            {
                case "1":
                    return new Add();
                case "2":
                    return new Sub();
                default:
                    return null;
            }
        }
    }
}
