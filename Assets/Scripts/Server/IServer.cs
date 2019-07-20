using System;


public interface IServer
{
    void Connect(Action<bool> callBack);
}
