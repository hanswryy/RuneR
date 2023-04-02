using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWay : MonoBehaviour
{
    private Levels levels;

    void Start() {
        levels = GameObject.Find("Levels").GetComponent<Levels>();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player") {
            levels.levelUp = true;
            SceneManager.LoadScene("GamePlay");
        }
    }
}
