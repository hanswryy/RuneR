using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    private RoomTemplates templates;
    public int openDirection;
    private int rand;
    private bool spawned = false, colliding = false;
    public RoomTemplates rt;
    public Levels levels;
    // 1 --> Need right
    // 2 --> Need left
    // 3 --> Need Down
    // 4 --> Need Up

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
        rt = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        levels = GameObject.Find("Levels").GetComponent<Levels>();
    }

    void Update() {
        //if (rt.allRooms.Count == levels.sq) {
        //    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}
    }

    void Spawn() {
        if (!spawned && rt.allRooms.Count < levels.sq) {
            if (openDirection == 1) {
                // Need right
                rand = Random.Range(0, templates.rightRooms.Length);
                GameObject g = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                //Instantiate(templates.bg, transform.position + new Vector3(0, 0, 15), Quaternion.identity);
                rt.allRooms.Add(g);
            } else if (openDirection == 2) {
                // Need left
                rand = Random.Range(0, templates.leftRooms.Length);
                GameObject g = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                rt.allRooms.Add(g);
            } else if (openDirection == 3) {
                // Need down
                rand = Random.Range(0, templates.downRooms.Length);
                GameObject g = Instantiate(templates.downRooms[rand], transform.position, templates.downRooms[rand].transform.rotation);
                rt.allRooms.Add(g);
            } else if (openDirection == 4) {
                // Need up
                rand = Random.Range(0, templates.upRooms.Length);
                GameObject g = Instantiate(templates.upRooms[rand], transform.position, templates.upRooms[rand].transform.rotation);
                rt.allRooms.Add(g);
            }
            spawned = true;
        }

        if (rt.allRooms.Count == levels.sq && !colliding ) {
            GameObject g = Instantiate(templates.closedRoom, transform.position + new Vector3(0, 0, 15), Quaternion.identity);
            if (this.transform.position == rt.allRooms[rt.allRooms.Count - 1].transform.position) {
                Destroy(g);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("SpawnPoint")) {
            colliding = true;
            try {
                if (!coll.GetComponent<RoomSpawner>().spawned && !spawned) {
                    Instantiate(templates.closedRoom, transform.position + new Vector3(0, 0, 15), Quaternion.identity);
                    Destroy(gameObject);
                }
            } catch (System.Exception e) {
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
