using System;
using UnityEngine;

namespace Assets.Scripts.Architecture.ReactiveProperty
{
    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }

        public ReactiveProperty(T startValue)
        {
            Value = startValue;
        }
    }
}
