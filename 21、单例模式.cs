using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 保证类的实例只有一个，并且提供一个全局访问方法
    /// </summary>
    class _21_单例模式
    {
    }
    #region 单线程下可行操作
    class Singleton
    {
        private static Singleton instance;
        private Singleton()//构造函数私有化，防止外界创建新对象
        { }
        public static Singleton GetInstance()//全局访问instance方法
        {
            return instance ?? (instance = new Singleton());//多线程下可能new多次
        }
    }
    #endregion
    #region 多线程可行操作 （lock锁）
    class Singleton1
    {
        private static Singleton1 instance;
        private static readonly  object myLock=new object();
        private Singleton1()
        {}
        public static Singleton1 GetInstance()
        {
            lock (myLock)
            {
                return instance ?? (instance = new Singleton1());
            }
        }
    }
    #endregion
    #region 多线程可行操作（双重lock锁）

    class Singleton2
    {
        private static Singleton2 instance;
        private static readonly object myLock=new object();
        private Singleton2()
        {}
        public static Singleton2 GetInstance()
        {
            if (instance == null)
            {
                lock (myLock)
                {
                    if(instance==null)
                        instance=new Singleton2();
                }
            }
            return instance;
        }
    }
    #endregion
    #region 静态初始化
    public sealed class Singleton3//密封类，防止派生该类
    {
        private static readonly Singleton3 instance=new Singleton3();
        private Singleton3(){}
        public static Singleton3 GetInstance()
        {
            return instance;
        }
    }
    #endregion
}
