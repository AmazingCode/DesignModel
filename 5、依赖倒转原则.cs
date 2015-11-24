using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 针对接口编程，不要针对实现编程
    /// 不管是高层次模块还是低层次模块，都要依赖于接口或者抽象类，只要接口保持稳定，那么任何一个更改都不用担心其他模块受到影响。
    /// 例如：第一种情况类A实现接口I，类B继承自类A，如果类A改变了会不会影响类B呢，如果类B也实现接口I是不是就比较好了。
    /// 谁也不依赖于谁，除了约定的接口，大家都可以灵活自如
    /// </summary>
    class _5_依赖倒转原则
    {

    }
    /// <summary>
    /// 里氏替换原则：子类必须能够替换掉他们的父类
    /// 一个类要继承一个父类，那么这个类继承自这个父类的所有方法和属性都应该是合理的。子类可以替换掉父类。
    /// 只有当子类可以替换掉父类，软件单位的功能不受到影响时，父类才能被真正的复用，而子类可以在父类的基础上增加新的方法和属性。
    /// 面向对象编程，要针对抽象编程而不是针对细节编程。即程序中所有的依赖关系都要终止于抽象类或者接口。
    /// </summary>
    class 里氏替换原则
    {
        public void readMe()
        {
            //如果需求变化，需要将Dog变成Cat对象，其他不用改，只要将Dog改成Cat即可。
            //Anmial animal=new Dog();
            //animal.eat();
            //animal.drink();
        }
    }

}
