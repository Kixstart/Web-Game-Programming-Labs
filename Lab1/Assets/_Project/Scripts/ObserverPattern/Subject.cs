using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace platformer397
{
    public abstract class Subject : MonoBehaviour
    {
        [SerializeField] private List<IObserver> observers = new List<IObserver>();
        public void AddObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);
        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.OnNotify();
            }
        }


    }
}
