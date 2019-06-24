using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    private float time = -50f;
    public float interpolationPeriod = 12.0f;
    public static int x;
    public int nr;
    public GameObject Package;
    void Start()
    {
        SetSpawningPoint();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = -50;
            SetSpawningPoint();
        }
    }
    public void SetSpawningPoint()
    {
        x = Random.Range(0, 12);
        while(x%2 != nr)
            x = Random.Range(0, 12);
        transform.position = new Vector3(x, 8, 0);
    }
    public void NewPackage()
    {
        time = 0.0f;
        Score.scoreValue += 2;
        Instantiate(Package, transform.position, Quaternion.identity);
    }
}
