using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Node<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    public Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node<T> Root { get; set; }

    public void Insert(T value)
    {
        Root = InsertRec(Root, value);
    }

    private Node<T> InsertRec(Node<T> root, T value)
    {
        if (root == null)
        {
            root = new Node<T>(value);
            return root;
        }

        if (value.CompareTo(root.Value) < 0)
        {
            root.Left = InsertRec(root.Left, value);
        }
        else if (value.CompareTo(root.Value) > 0)
        {
            root.Right = InsertRec(root.Right, value);
        }

        return root;
    }

    public bool Search(T value)
    {
        return SearchRec(Root, value) != null;
    }

    private Node<T> SearchRec(Node<T> root, T value)
    {
        if (root == null || root.Value.CompareTo(value) == 0)
        {
            return root;
        }

        if (root.Value.CompareTo(value) < 0)
        {
            return SearchRec(root.Right, value);
        }

        return SearchRec(root.Left, value);
    }
}