using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 观察者模式：定义了一种一对多的关系，让多个观察者对象同时监听同一个主题对象，当这个主题对象状态发生改变的时候，会通知所有的观察者对象，使所有的观察者对象执行特定操作
    /// 参数传递尽量依赖于接口和抽象类
    /// </summary>
    class _14_观察者模式
    {
        public void Main()
        {
            ISubject boss=new Boss();
            Observer observer=new Observer1("sss",boss);
            boss.Attach(observer);
            boss.Notify();
        }
    }
    abstract class Observer
    {
        protected string Name;
        protected ISubject Subject;
        public abstract void Update();
    }

    class Observer1:Observer
    {
        public Observer1(string name,ISubject subject)//同样 参数也是接口传递，不依赖于具体的类
        {
            this.Name = name;
            this.Subject = subject;
        }
         public override void Update()
         {
             Console.WriteLine(Name+Subject.Name+"在看股票呢");
         }
    }
    interface ISubject
    {
        string Name { get; set; }
        List<Observer> Observers { get; set; }
        void Attach(Observer observer);//添加
        void Detach(Observer observer);//剔除
        void Notify();//通知
    }
    class Boss:ISubject
    {
        public string Name { get; set; }
        public List<Observer> Observers { get; set; }//这里需要添加继承了Observe抽象类的对象，如果有的类没有继承Observe类，那么建造者模式就失效了！这时可以用委托来实现
        public Boss()
        {
            this.Observers=new List<Observer>();
        }
        public void Attach(Observer observer)//Attach函数的参数 都是接口传递，而不是具体的类，降低类间耦合
        {
            Observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            Observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in Observers)
            {
               observer.Update();
            }
        }
    }

}
