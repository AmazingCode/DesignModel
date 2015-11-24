using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 适配器模式：将一个类的接口转换成客户希望的另外一个接口。适配器模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
    /// 需要的东西在面前，但是却不能用，我们可以想办法适配它
    /// 系统的数据和行为都正确，但是接口不符时，可以考虑适配器模式。目的是使控制范围外的一个原有对象与某个接口匹配。可以起到复用一些现存类的作用。
    /// 有点亡羊补牢的意思~~
    /// 应用场景：一般用在后期的系统维护阶段，接口改变的情况下使用！但是当我们设计一个系统，调用第三方组件时，第三方的组件往往和我们需要的接口是不一致的，此时就可以用适配器模式
    /// </summary>
    class _17_适配器模式
    {
    }
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("客户期待的接口");
        }
    }
    class Adaptee
    {
         public void SpecificQuest()
         {
             Console.WriteLine("需要适配的接口，即现在已经存在的一些功能");
         }
    }
    class Adapter:Target
    {
        //接口达到了Target的要求，同时调用了现有的Adaptee类功能
        public override void Request()
        {
            new Adaptee().SpecificQuest();
        }
    }
    #region 示例2

    /// <summary>
    /// 球员类
    /// </summary>
    abstract class Player
    {
        protected string Name;

        protected Player(string name)
        {
            this.Name = name;
        }
        public abstract void Attratk();
        public abstract void Defend();
    }
    /// <summary>
    /// 前锋类
    /// </summary>
    class ForWard:Player
    {
        public ForWard(string name) : base(name)
        {
            this.Name = name;
        }
        public override void Attratk()
        {
            Console.WriteLine("ForWard Attrack");
        }
        public override void Defend()
        {
            Console.WriteLine("ForWard Defend!");
        }
    }
    /// <summary>
    /// 中国球员
    /// </summary>
    class ChinaPlayer
    {
        public string Name { get; set; }
        public ChinaPlayer(string name)
        {
            Name = name;
        }
        public void ChineseStyleAttratk()
        {
            Console.WriteLine("中国球员式进攻！");
        }
        public void ChineseStyleDefend()
        {
            Console.WriteLine("中国球员式防守");
        }
    }
    /// <summary>
    /// 同化中国球员类ChinaPlayer，也就是复用ChinaPlayer
    /// </summary>
    class AssimilationChinesePlayer:Player
    {
        private ChinaPlayer Player;
        public AssimilationChinesePlayer(string name) : base(name)
        {
            this.Name = name;
            this.Player=new ChinaPlayer(name);
        }
        public override void Attratk()//接口保持了一致，同时内部调用了现有的ChinaPlayer
        {
            Player.ChineseStyleAttratk();
        }
        public override void Defend()
        {
            Player.ChineseStyleDefend();
        }
    }
    #endregion
}
