using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneAnimation : MonoBehaviour
{
    public int lr = 0;
    public GameObject Spawn;

    void Update()
    {
        float delta = 2f / 128; // ????????
        if (lr == 1)
            transform.position += new Vector3(-delta, 0, 0);
        else if( lr == -1 )
            transform.position += new Vector3(delta, 0, 0);
        if (Spawn.GetComponent<SpawnBlock>().transform.position.x == transform.position.x)
        {
            Spawn.GetComponent<SpawnBlock>().NewPackage();
        }
        if( transform.position.x < -2)
        {
            Spawn.GetComponent<SpawnBlock>().SetSpawningPoint();
            transform.position = new Vector3(13, 8.74f, 0);
        }
        if ( transform.position.x > 13)
        {
            Spawn.GetComponent<SpawnBlock>().SetSpawningPoint();
            transform.position = new Vector3(-2, 8.74f, 0);
        }

    }

}
