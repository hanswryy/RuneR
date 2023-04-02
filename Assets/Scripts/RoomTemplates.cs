using UnityEngine;
using System.Collections.Generic;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom, exitt, chk;

    public List<GameObject> allRooms;

    private Vector3 exit;
    Levels levels;

    private bool instExit = false, instExit2 = false;
    int ind = 0;
    float timer, cnt;

    Animator anim;

    void Start() {
        anim = GameObject.Find("LoadingPage").GetComponent<Animator>();
        allRooms = new List<GameObject>();
        levels = GameObject.Find("Levels").GetComponent<Levels>();
        cnt = 0.1f + ((levels.sq - 4f) * 0.1f);
        //cnt = ((levels.sq / 4) * 0.1f) + ((levels.sq - 4) * 0.1f);
    }

    void Update() {
        if (!instExit2) timer += Time.deltaTime;
        if (cnt < timer) {
            instExit = true;
            timer = 0;
        }

        exit = allRooms[allRooms.Count - 1].transform.position;
        if (levels.sq >= allRooms.Count && instExit) {
            Instantiate(exitt, exit + new Vector3(0, 0, 2), Quaternion.identity);

            anim.Play("New Animation");

            instExit = false;
            instExit2 = true;
        }
    }
}
