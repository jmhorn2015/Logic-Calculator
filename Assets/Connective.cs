using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connective{
    public int degree = 0;
    Variable valueA;
    Variable valueB;
    char connective;
    public Connective(Variable x, Variable y, char z)
    {
        valueA = x;
        valueB = y;
        if (x.degree > y.degree)
        {
            degree = x.degree;
        }
        else
        {
            degree = y.degree;
        }
        connective = z;
    }
    public Connective(Variable d, char e)
    {
        connective = 'n';
        valueA = d;
        degree = d.degree + 1;
    }
    public Connective(char f)
    {
        connective = f;
    }
    public string PrintLine()
    {
        Debug.Log("run connective");
        string output = "";
        if(valueA.degree > 0)
        {
            output += "(" + valueA.PrintLine() + ")";
        }
        else
        {
            output += valueA.PrintLine();
        }
        output += " " + connective + " ";
        if (valueB.degree > 0)
        {
            output += "(" + valueB.PrintLine() + ")";
        }
        else
        {
            output += valueB.PrintLine();
        }
        return output;
    }
}
