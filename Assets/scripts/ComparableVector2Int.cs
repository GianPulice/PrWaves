using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparableVector2Int : IComparable<ComparableVector2Int>
{
    public Vector2Int Value { get; set; }

    public ComparableVector2Int(Vector2Int value)
    {
        Value = value;
    }

    public int CompareTo(ComparableVector2Int other)
    {
        if (Value.x == other.Value.x)
        {
            return Value.y.CompareTo(other.Value.y);
        }
        return Value.x.CompareTo(other.Value.x);
    }
}
