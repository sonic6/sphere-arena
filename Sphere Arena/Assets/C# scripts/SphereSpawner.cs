using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    [SerializeField] int timeGap; //the time gap between the current sphere in the scene and the next one to spawn
    public static int ballsInGame; //the amount of spheres currently in the arena 
    public static SphereSpawner spawner; 

    // Start is called before the first frame update
    void Start()
    {
        spawner = this;
        StartCoroutine(SpawnAfterTime());
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 15 * Time.deltaTime, 0));
    }

    //Spawns new spheres every 'timeGap' time as long as the match is not over yet
    IEnumerator SpawnAfterTime()
    {
        
        while(GameManager.gameOn)
        {
            Spawn();
            yield return new WaitForSeconds(timeGap);
            if(timeGap > 3)
                timeGap = timeGap - 1;
        }
        yield return null;
    }

    //Spawns a sphere immediately when called
    void Spawn()
    {
        Instantiate(spherePrefab, transform.position, transform.rotation);
        ballsInGame++;
    }

    //Decreases the count of spheres in variable 'ballsInGame' and spawns a new sphere if the arena is empty of spheres
    public void SphereOut()
    {
        ballsInGame--;
        if (ballsInGame == 0)
            Spawn();
    }
}
