using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila<T> :IPilayCola<T>
{
    private List<T> items;

    public Pila()
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
            throw new InvalidOperationException("Pila vacía");
        }

        int lastIndex = items.Count - 1;
        T item = items[lastIndex];
        items.RemoveAt(lastIndex);
        return item;
    }

    public T Tomar()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Pila vacía");
        }

        return items[items.Count - 1];
    }

    public int Count => items.Count;

    public bool EstaVacia => items.Count == 0;
}