using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonControlls : PlayerMovment
{

    public void getButton(string where)
    {
        if (where == "Up")
        {
            if (!isInAir())
            {
                jump = where;
                jumpPhase = 0;
            }
        }
        else if (movment == " ")
        {
            movment = where;
            movmentPhase = 0;
        }
    }
}
