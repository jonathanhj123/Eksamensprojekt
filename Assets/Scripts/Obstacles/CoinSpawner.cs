using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float timer = 0;
    [SerializeField] private float spawnRate = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinPrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Coin");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.GameRunning) {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else {
                Instantiate(coinPrefab, new Vector3(transform.position.x, -3, 0), transform.rotation);
                timer = 0;
                spawnRate = Random.Range(5, 10);
            }
        }
    }
}
