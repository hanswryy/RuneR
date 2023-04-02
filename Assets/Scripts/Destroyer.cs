using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "SpawnPoint") {
            Destroy(coll.gameObject);
        }
        
    }
}
