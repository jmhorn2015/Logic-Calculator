using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRender{
    public static Variable[] assumptions = new Variable[3];
    public static Variable conclusion;

    public static string Print()
    {
        string output = "";
        for(int x = 0; x < 3; x++)
        {
            Debug.Log(assumptions[x].PrintLine());
            Debug.Log(x);
            output += assumptions[x].PrintLine() + "\n";
        }
        output += conclusion.PrintLine();
        return output;
    }
}
