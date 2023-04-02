using UnityEngine;
//using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 center;
    public GameObject[] enemies;
    public GameObject chest;
    private int spawned = 0, maxSp;
    bool s_chest = false;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;

        //random coordinate : x -> (-7) - 7; y -> (-3) - 3
        maxSp = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!s_chest && Random.value > 0.6) {
            Instantiate(chest, new Vector3(transform.position.x + 4f, transform.position.y + 3f, 2f), Quaternion.identity);
        }

        s_chest = true;

        if (spawned <= maxSp) {
            int rand = Random.Range(0, enemies.Length);
            int randX = Random.Range(-7, 7);
            int randY = Random.Range(-3, 3);
            Instantiate(enemies[rand], new Vector3(transform.position.x + randX, transform.position.y + randY, 2f), transform.rotation);
            GameObject.Find("Identifier").GetComponent<EnemyIdentifier>().spawned++;
            spawned++;
        } else {
            this.GetComponent<EnemySpawner>().enabled = false;
        }
    }
}
