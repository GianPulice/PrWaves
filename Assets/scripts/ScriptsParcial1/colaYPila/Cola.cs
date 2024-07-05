using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola<T> : IPilayCola<T>, IEnumerable<T>, IEnumerable
{
     private List<T> items;

    public Cola()
    {
        items = new List<T>();
    }

    public void Agregar(T item)
    {
        items.Add(item);
    }

    public T Remover()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Cola vacía");
        }

        T item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public T Tomar()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Cola vacía");
        }

        return items[0];
    }


    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => items.Count;

    public bool EstaVacia => items.Count == 0;
}

