using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPilayCola<T>
{
    void Agregar(T item);
    T Remover();
    T Tomar();
    int Count { get; }
    bool EstaVacia { get; }
}
