using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 原型模式：从一个对象创建另一个可以定制的对象，而且不需要知道任何创建的细节
    /// </summary>
    class 原型模式
    {
        public void Main()
        {
            var s = new ConcretePrototype1("id");
            ((ProtoType) s).Idd();//访问父类被隐藏的Idd方法
            s.Idd();//默认访问新类的Idd方法
            var sClone=s.Clone();
        }
    }
    #region 例子1
    abstract class ProtoType
    {
        private string Id;
        protected ProtoType(string id)
        {
            this.Id = id;
        }
        public string Idd()
        {
            return Id;
        }
        public abstract ProtoType Clone();
    }

    class ConcretePrototype1:ProtoType
    {
        public ConcretePrototype1(string id) : base(id)
        {
        }
        public override ProtoType Clone()
        {
            return (ProtoType)this.MemberwiseClone();//浅表复制，值类型复制具体的值，引用类型复制引用！
        }
        public new string Idd()
        {
            return "ConcretePrototype1";
        }
    }
    #endregion
    #region 例子2  深复制和浅复制
    class WorkExperice:ICloneable
    {
        public string Name { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public object Clone()
        {
            return new WorkExperice(){Name = this.Name,StarTime = StarTime,EndTime = EndTime};//深度复制
            //return this.MemberwiseClone();如果属性只有值类型，用这个方法就可以实现浅表复制
        }
    }

    #endregion
    /// <summary>
    /// 由于Clone非常常见，所以.Net已经提供了这个Clone接口
    /// </summary>
    class MyClass:ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();//浅复制
        }
    }
}
