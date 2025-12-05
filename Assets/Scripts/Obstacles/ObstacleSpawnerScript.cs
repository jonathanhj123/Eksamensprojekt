    using UnityEngine;
    using System.Collections.Generic;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> Groundobstacles;
    public List<GameObject> Airobstacles;
    public float spawnRate = 2;
    private float timer = 0;
    private PlayerScript playerscript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerscript = player.GetComponent<PlayerScript>();
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.IsAlive)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (GameData.Instance.RoundScore > 50)
                {
                    if(GameData.Instance.RoundScore < 250)
                    {
                    
                    if (Random.Range(1,3) == 1)
                    {
                        spawnMeteor();
                        timer = 0;
                    } else
                    {
                            spawnGroundObstacle();
                            timer = 0;
                    }
                    }
                    else
                    {
                    if (Random.Range(1,3) == 1)
                    {
                        spawnAirObstacle();
                        timer = 0;
                    } else
                        {
                            spawnGroundObstacle();
                            timer = 0;
                        }
                    }

                } else
                
                spawnGroundObstacle();
                timer = 0;
            }
        }
    }

    void spawnGroundObstacle()
    {
    Instantiate(Groundobstacles[Random.Range(0,4)], new Vector3(transform.position.x, -3, 0), transform.rotation);
    } 

    void spawnMeteor()
    {
    Instantiate(Airobstacles[0], new Vector3(transform.position.x, 3, 0), transform.rotation);
    }

    void spawnAirObstacle()
    {
    Instantiate(Airobstacles[Random.Range(0,2)], new Vector3(transform.position.x, 3, 0), transform.rotation);
    }
}
