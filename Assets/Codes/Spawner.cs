using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float SpawnInterval_Pedal = 0.7f;
    private float SpawnInterval_Orb = 0.2f;
    private float NextSpawnTime_Pedal = 0;
    private float NextSpawnTime_Orb = 0;
    public GameObject Prefab_Pedal;
    public GameObject Prefab_Orb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextSpawnTime_Pedal)
        {
            NextSpawnTime_Pedal = Time.time + SpawnInterval_Pedal;
            Instantiate(Prefab_Pedal, RandomX(), Quaternion.identity);
        }
        if (Time.time >= NextSpawnTime_Orb)
        {
            NextSpawnTime_Orb = Time.time + SpawnInterval_Orb;
            Instantiate(Prefab_Orb, RandomX(), Quaternion.identity);
        }
    }
    public static Vector2 RandomX()
    {
        Vector2 position = new Vector2(Random.Range(-17, 17), -15);
        return position;
    }
}
