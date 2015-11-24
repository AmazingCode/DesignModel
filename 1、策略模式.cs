using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 什么是策略模式？
    /// 策略模式就是在简单工厂模式的基础上，对factory内部同时封装具体的子类的方法实现，
    /// 但是策略模式和工厂模式 还是没从根本上消除switch语句
    /// </summary>
    class 策略模式
    {
        public void Main()
        {
            var c = new Context_Cl("1");
            c.GetResult(1,6);//这里调用相对于简单工厂模式就更加统一了
        }
    }
   abstract class Operat_Cl
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            return 0;
        }
    }
    class Add_Cl:Operat_Cl
    {
        public Add_Cl(double numberA, double numberB) 
        {
        }
        public Add_Cl()
        {}
        public override double GetResult()
        {
            return NumberA+NumberB;
        }
    }
    class Sub_Cl:Operat_Cl
    {
        public override double GetResult()
        {
            return NumberA-NumberB;
        }
    }
    class Context_Cl
    {
        public Operat_Cl oper { get; set; }
        public Context_Cl(string flag)
        {
            switch (flag)
            {
                case "1":
                    oper=new Add_Cl();
                    break;
                case "2":
                    oper=new Sub_Cl();
                    break;
                default:;
                    break;
            }
        }
        public void GetResult(double numberA,double numberB)
        {
            oper.NumberA = numberA;
            oper.NumberB = numberB;
            oper.GetResult();
        }
    }

    #region 可以改进Context_CL类，感觉像是策略模式了。不过无所谓，合理即可
    abstract class Context_Fac
    {
       public abstract  Operat_Cl GetObject();
        public abstract double GetResult(double numberA,double numberB);
    }

    class Sub_Fac:Context_Fac
    {
        private Operat_Cl operatCl;
        public override Operat_Cl GetObject()
        {
           return  operatCl=new Sub_Cl();
        }
        public override double GetResult(double numberA,double numberB)
        {
            operatCl.NumberA=numberA;
            operatCl.NumberB = numberB;
            return operatCl.GetResult();
        }
    }
    #endregion

}
