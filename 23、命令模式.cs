using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 一个类有一些具体的功能（烤肉者）,将这些功能抽象出一个命令类，在通过每一个继承该命令类的具体类 调用  一个具体的功能，然后在定义一个中间类（服务员），接收客户端的命令请求，具体通知各个功能的所有者实现这些功能
    /// </summary>
    class _23_命令模式
    {
        public void Main()
        {
            Barbecuer boy=new Barbecuer();
            Command com1=new BakeChikenCommand(boy);
            Command com2=new BakeChikenCommand(boy);
            Waiter girl=new Waiter();
            girl.SetOrder(com1);
            girl.SetOrder(com2);
            girl.Execute();
        }
        
    }
    /// <summary>
    /// 抽象命令类
    /// </summary>
    public abstract class Command
    {
        protected Barbecuer receiver;
        protected Command(Barbecuer barbecuer)
        {
            this.receiver = barbecuer;
        }
        public abstract void ExecuteCommand();
    }

    class BakeMuttonCommand:Command
    {
         public BakeMuttonCommand(Barbecuer barbecure) : base(barbecure)
         {
             this.receiver = barbecure;
         }
         public override void ExecuteCommand()
         {
            receiver.BakeMutton();
         }
    }

    class BakeChikenCommand:Command
    {
        public BakeChikenCommand(Barbecuer barbecure) : base(barbecure)
        {
            this.receiver = barbecure;
        }
        public override void ExecuteCommand()
        {
           receiver.BakeChicken();
        }
    }
    /// <summary>
    /// 服务员类  可以添加更多的功能函数
    /// </summary>
    public class Waiter
    {
        private IList<Command> commands=new List<Command>();
        public void SetOrder(Command command)
        {
            this.commands.Add(command);
        }
        public void Execute()
        {
            foreach (var  command in commands)
            {
                command.ExecuteCommand();
            }
        }
    }
    /// <summary>
    /// 烤肉者
    /// </summary>
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤肉");
        }
        public void BakeChicken()
        {
            Console.WriteLine("烤鸡翅");
        }
    }
}
