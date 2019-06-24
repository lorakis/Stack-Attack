using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public string jump = " ";
    public string movment = " ";

    public int jumpPhase = 70;
    int jumpSpeed = 70;
    public int movmentPhase = 64;
    int moveSpeed = 64;

    void Update()
    {
        PlayerFall();
        PlayerJump();
        PlayerMove();
        if (End())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void PlayerJump()
    {
        if (jumpPhase < jumpSpeed && jump == "Up")
        {
            jumpPhase++;
            transform.position += new Vector3(0, 2f / Package.fallTime, 0);
            transform.position += new Vector3(0, 2f / Package.fallTime, 0);
        }
        else if (jumpPhase == jumpSpeed && jump != " ")
            jump = " ";
    }
    void PlayerMove()
    {
        if (movmentPhase < moveSpeed && movment != " ") // ruch
        {
            Move();
            if (!ValidMove())
            {
                MoveBack();
            }
        }
        else if (movmentPhase == moveSpeed && movment != " ")
            movment = " ";
    }
    void PlayerFall() // spadanko
    {
        transform.position += new Vector3(0, -1f / Package.fallTime, 0);
        if (!ValidFall())
        {
            transform.position -= new Vector3(0, -1f / Package.fallTime, 0);
        }
    }
    bool End()
    {
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (Mathf.Abs(obj.transform.position.x - transform.position.x) < 1 && obj.transform.position.y <= transform.position.y + 1.5f && obj.transform.position.y >= transform.position.y + 1.4f )
                return true;
        }
        return false;
    }
    void Move()
    {
        float delta = 2f / 128; // ????????
        if (movment == "Left")
            transform.position += new Vector3(-delta, 0, 0);
        if (movment == "Right")
            transform.position += new Vector3(delta , 0, 0);
        movmentPhase++;
    }
    void MoveBack()
    {
        movmentPhase = moveSpeed;
        float delta = 2f / 128;
        if (movment == "Left")
            transform.position -= new Vector3(-delta, 0, 0);
        if (movment == "Right")
            transform.position -= new Vector3(delta, 0, 0);
    }
    bool ValidFall()
    {
        if (transform.position.x < 0 || transform.position.x > Package.width || transform.position.y < 0.5 || transform.position.y >= Package.height)
        {
            return false;
        }
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.transform.position.y + 1.5f > transform.position.y  && Mathf.Abs(obj.transform.position.x - transform.position.x) < 1 )
                return false;
        }
        return true;
    }
    bool ValidMove()
    {
        
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            
            if ((obj.transform.position.x + 0.5) > (transform.position.x - 0.5) && (obj.transform.position.y + 0.5) > (transform.position.y - 1) 
                && (obj.transform.position.x - 0.5) < (transform.position.x + 0.5) && (obj.transform.position.y - 0.5) < (transform.position.y + 1))
            {
                if (obj.GetComponent<Package>().pushPhase < obj.GetComponent<Package>().pushSpeed)
                    return true;
                if (obj.transform.position.x < 1 || obj.transform.position.x > 10)
                    return false;
                if(obj.GetComponent<Package>().Pushable && (int)obj.transform.position.y == (int)(transform.position.y - 0.5))
                {
                    obj.GetComponent<Package>().pushment = movment;
                    obj.GetComponent<Package>().pushPhase = 0;
                    return true;
                }
                return false;
            }
            
                
        }
        
        return true;
    }
    public bool isInAir()
    {
        var objects = GameObject.FindGameObjectsWithTag("Package");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (obj.transform.position.y + 1.5 == transform.position.y && Mathf.Abs(obj.transform.position.x - transform.position.x) < 1)
                return false;
        }
        return !isOnGround();
    }
    public bool isOnGround()
    {
        if ( System.Math.Abs(transform.position.y - 0.5) == 0)
            return true;
        return false ;
    }

}
