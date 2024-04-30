using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola<T>
{
    private List<T> items;

    public Cola()
    {
        items = new List<T>();
    }

    public void Encolar(T item)
    {
        items.Add(item);
    }

    public T Desencolar()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("cola vacia");
        }

        T item = items[0];
        items.RemoveAt(0);
        return item;
    }

    public T Tomar()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("cola vacia");
        }

        return items[0];
    }

    public int Count => items.Count;

    public bool EstaVacia => items.Count == 0;

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in items)
        {
            yield return item;
        }
    }
}

