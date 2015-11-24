using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
    /// <summary>
    /// 通过共享实例对象，减少对象的创建，降低内存的损耗。
    /// </summary>
    class _26_享元模式
    {
        public void  Main()
        {
           FlyWeight a=new FlyWeightA();
           FlyWeight b=new FlyWeightB();
           FlyWeightFactory fac=new FlyWeightFactory();
           fac.AddFlyWeight("a",a);
           fac.AddFlyWeight("b",b);
           var flyWeightA=  fac.Get("a") as FlyWeightA;//通过fac工厂的get方法在其他位置调用get方法 也会得到同一个对象，减少了创建对象的开销
           flyWeightA.Operator(new Data());//通过客户端传递外部数据进行处理
        }
    }
    public class Data
    {
        public string str;
    }
    abstract class FlyWeight
    {
        public abstract void Operator(Data data);
    }
    class FlyWeightA:FlyWeight
    {
        public override void Operator(Data data)
        {
            //使用data里的数据
            Console.WriteLine("FlyWeightA");
        }
    }
    class FlyWeightB:FlyWeight
    {

        public override void Operator(Data data)
        {
            //使用data里的数据
            Console.WriteLine("FlyWeightB");
        }
    }

    class FlyWeightFactory
    {
        private Dictionary<string,FlyWeight> dic=new Dictionary<string, FlyWeight>();
        public void AddFlyWeight(string key,FlyWeight flyWeight)
        {
            if(!dic.Keys.Contains(key))
              dic.Add(key,flyWeight);
        }
        public FlyWeight Get(string key)
        {
            return dic.Keys.Contains(key) ? dic[key] : null;
        }
    }
}
