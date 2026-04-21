using System;
using UnityEngine.Events;

public interface IEventContainer
{
    UnityEvent _event { get; }
}

[Serializable]
public class EventObject
{
    public IEventContainer eventContainer;
}
