using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 模板模式：通过定义一个抽象类，抽象类里的一个方法A内部调用了另一个虚方法B，就可以通过继承这个抽象类，然后重写这个虚方法，达到控制方法A的目的。最大程度上减少了类B的代码重复量
    /// 定义一个一个类的基本骨架，然后通过虚函数将部分差异性方法或者属性在子类中重新定义，使得子类可以不改变父类的基本骨架即可重新定义从父类继承过来的一些方法。
    /// 也就是说模板方法通过将不变的行为搬移到父类中，去除了子类中的重复代码，代码复用程度较高。
    /// </summary>
    class _10_模板方法模式
    {
        public void Main()
        {
            var t = new TestPaper1();
            t.QuestionOneAnswer("26");
            t.QuestionOne();
        }
    }
    abstract class TestPaper
    {
        protected string Age;
        public void QuestionOne()
        {
            Console.WriteLine("how old are you!"+QuestionOneAnswer(Age));
        }
        public virtual string QuestionOneAnswer(string age)
        {
            return "";
        }
    }

    class TestPaper1:TestPaper
    {
        public override string QuestionOneAnswer(string age)
        {
            this.Age = age;
            return age;
        }
    }
}
