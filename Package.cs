using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public static int fallTime = 128;
    public static int height = 9;
    public static int width = 11;
    public bool Pushable;
    public int pushPhase = 64;
    public int pushSpeed = 64;
    public string pushment = " ";

    void Update()
    {
            transform.position += new Vector3(0, -1f/fallTime, 0);
            
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1f/fallTime, 0);
            }
        MakePush();
        Pushable = CanBePushed();
        ClearLine();
    }

    bool ValidMove()
    {
       
        if (transform.position.x < 0 || transform.position.x > width || transform.position.y < 0 || transform.position.y > height)
        {
            return false;
        }
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.transform.position.y == transform.position.y && obj.transform.position.x == transform.position.x)
                continue;
            if (obj.transform.position.y + 1 > transform.position.y && Mathf.Abs(obj.transform.position.x - transform.position.x) < 1 && obj.transform.position.y  < transform.position.y)
                return false;
        }
        return true;
    }
    void ClearLine()
    {
        int rob = 0;
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.transform.position.y == 0)
                rob++;
        }
        if (rob == 12)
        {
            foreach (var obj in objects)
            {
                if (obj.transform.position.y == 0)
                    Destroy(obj);
            }
        }
    }
    bool CanBePushed()
    {
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.transform.position.y == transform.position.y && obj.transform.position.x == transform.position.x)
                continue;
            if ( (int)obj.transform.position.y == (int)transform.position.y && Mathf.Abs(obj.transform.position.x - transform.position.x) < 2)
            {
                return false;
            }
            if (obj.transform.position.x == transform.position.x && transform.position.y - obj.transform.position.y < 0 && transform.position.y - obj.transform.position.y > -2)
            {
                return false;
            }
        }
        return true;
    }
    public void MakePush()
    {
        float delta = 2f / 128; // ????????
        if (pushPhase < pushSpeed && pushment != " ") // ruch
        {
            if (pushment == "Left")
                transform.position += new Vector3(-delta, 0, 0);
            if (pushment == "Right")
                transform.position += new Vector3(delta, 0, 0);
            pushPhase++;
        }
        else if (pushPhase == 64 && pushment != " ")
            pushment = " ";
    }
}
