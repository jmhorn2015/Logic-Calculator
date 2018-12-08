using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable{
    char value;
    Connective altValue;
    public bool isValue;
    public int degree = 0;
    public Variable(char x)
    {
        value = x;
        isValue = true;
    }
    public Variable(Connective y)
    {
        altValue = y;
        degree = y.degree + 1;
        isValue = false;
    }
    public T getValue<T> () {
        if (isValue)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        else
        {
            return (T)Convert.ChangeType(altValue, typeof(T));
        }
    }
    public string PrintLine()
    {
        if (isValue)
        {
            return value.ToString();
        }
        else
        {
            return altValue.PrintLine();
        }
    }
}
