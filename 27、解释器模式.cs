using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 
    /// </summary>
    class _27_解释器模式
    {
    }
    /// <summary>
    /// 抽象解释器接口
    /// </summary>
    abstract class Expression
    {
        public abstract void Interpret(InterPretData data);
    }
    class NonExpression:Expression
    {
        public override void Interpret(InterPretData data)
        {
            Console.WriteLine("Non解释处理data数据");
        }
    }

    class TerExpression:Expression
    {
        public override void Interpret(InterPretData data)
        {
            Console.WriteLine("Ter解释处理data数据");
        }
    }
    class InterPretData
    {
         
    }
}
