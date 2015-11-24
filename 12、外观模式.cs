using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 通过一个类对多个类进行集成，用户只需要知道一个方法，就可以调用多个被继承类的功能
    /// 对于老系统，如果要进行扩展修改可以采用这种模式
    /// </summary>
    class _12_外观模式
    {
        
    }

    class Facade
    {
        public Writer1 Writer1 { get; set; }
        public Writer2 Writer2 { get; set; }
        public void Write()
        {
            Writer1.Write();
            Writer2.Write();
        }
    }

    interface IWriter
    {
        void Write();
    }
    class Writer1:IWriter
    {
        public void Write()
        {
            Console.WriteLine("hello writer1");
        }
    }
    class Writer2:IWriter
    {
        public void Write()
        {
            Console.WriteLine("hello writer2"); 
        }
    }
}
