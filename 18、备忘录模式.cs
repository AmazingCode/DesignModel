using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 备忘录模式：在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外进行保存，以后可以将该对象恢复到原先保存的状态了。
    /// 
    /// </summary>
    class _18_备忘录模式
    {
        public void Main()
        {
            var role = new MainRole(){RoleBlood = 10,RoleMagic = 10,RoleName = "name"};//创建一个角色
            var mementoManager = new MementoManager();//创建一个管理备忘录的类
            var roleMemento=role.SetMemento();//保存role角色的部分信息
            mementoManager.Dictionary.Add(role.RoleName,roleMemento);
        }
    }
    /// <summary>
    /// 游戏角色抽象类
    /// </summary>
    abstract class GameRole
    {
        protected string Name;
        protected int Magic;
        protected int Blood;
        public abstract void Display();//展示信息接口
        public abstract Memento SetMemento();//设置备忘录
        public abstract void ReCover(Memento memento);//根据备忘录Memento恢复角色信息

    }
    /// <summary>
    /// 备忘录类
    /// </summary>
    class Memento
    {
        public string Name { get; set; }
        public int Magic { get; set; }
        public int Blood { get; set; }
    }
     class MainRole:GameRole
     {
         public string RoleName
         {
             get { return Name; }
             set { Name = value; }
         }
         public int RoleMagic
         {
             get { return Magic; }
             set { Magic = value; }
         }
         public int RoleBlood
         {
             get { return Blood; }
             set { Blood = value; }
         }
         public override void Display()
         {
             Console.WriteLine(Name+Magic+Blood);
         }
         public override Memento SetMemento()
         {
           return  new Memento(){Blood = this.Blood,Magic = this.Magic,Name = this.Name};
         }
         public override void ReCover(Memento memento)
         {
             this.RoleBlood = memento.Blood;
             this.RoleMagic = memento.Magic;
             this.RoleName = memento.Name;
         }
     }

    class MementoManager
    {
        /// <summary>
        /// 存储一个dictionary key用name表示
        /// </summary>
         public Dictionary<string,Memento> Dictionary=new Dictionary<string, Memento>(); 
    }
}
