using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 建造者模式：用于创建一些复杂的对象，这些对象内部构建间的建造顺序较稳定，但是内部的构建过程是复杂变化的。
    /// 建造者模式的好处就是使得建造代码和具体的表示代码分离，由于建造者隐藏了该产品的具体实现，如果需要改变一个产品的内部表示，只需要重新再定义一个建造者就行了，或者在同一个建造者内部重新写一个方法
    /// 建造者Builder更像是一种对现有方法的有顺序整合
    /// </summary>
    class _13_建造者模式
    {
    }
   public abstract class Person
    {
        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildLag();
    }
    public class TinPerson:Person
    {
        public override void BuildHead()
        {
            Console.WriteLine("TinHead");
        }
        public override void BuildBody()
        {
            Console.WriteLine("TinBody");
        }
        public override void BuildLag()
        {
            Console.WriteLine("TinLag");
        }
    }
    public class FatPerson:Person
    {
        public override void BuildHead()
        {
            throw new NotImplementedException();
        }
        public override void BuildBody()
        {
            throw new NotImplementedException();
        }
        public override void BuildLag()
        {
            throw new NotImplementedException();
        }
    }
    public class Builder
    {
        public  Person Person {get; private set; }
        public Builder(Person person)
        {
            this.Person = person;
        }
        public void Build(Person person)
        {
            person.BuildHead();
            Person.BuildBody();
            person.BuildLag();
        }
        
    }
}
