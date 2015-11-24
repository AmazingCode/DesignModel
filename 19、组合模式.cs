using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 组合模式：可以让客户一致的使用组合结构和单个对象
    /// </summary>
    class _19_组合模式
    {
        public void Main()
        {
            Company c=new ConcreteCompany("一个非叶子部门");
            Company d=new HrCompany("人事部门");
            c.Add(d);
            c.LineOfDuty();
            c.Display();
        }
    }
    abstract class Company
    {
        protected string Name;
        protected Company(string name)
        {
            this.Name = name;
        }
        public abstract void Add(Company a);//添加对象
        public abstract void Remove(Company a);//删除对象
        public abstract void LineOfDuty();//履行职能(整体)
        public abstract void Display();//展示
    }
    /// <summary>
    /// 一个具体的Company
    /// </summary>
    class ConcreteCompany:Company
    {
        private List<Company> children=new List<Company>(); 
        public ConcreteCompany(string name):base(name)
        {}
        public override void Add(Company a)
        {
            children.Add(a);
        }
        public override void Remove(Company a)
        {
            children.Remove(a);
        }
        public override void LineOfDuty()
        {
            foreach (var company in children)
            {
                company.Display();
            }
        }
        public override void Display()
        {
            Console.WriteLine("This is ConcreteCompany display!");
        }
    }

    class HrCompany:Company
    {
        public HrCompany(string name):base(name)
        {
            this.Name = name;
        }
        public override void Add(Company a)
        {
        }
        public override void Remove(Company a)
        {
        }
        public override void LineOfDuty()
        {
        }
        public override void Display()
        {
            Console.WriteLine("HR部门的职责是招人！");
        }
    }
}
