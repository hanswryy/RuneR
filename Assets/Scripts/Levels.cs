using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public static Levels instance = null;

    public int add, hp, score, sq, floor;
    public bool levelUp = false;

    private Text hpr;

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);

        floor = 1;
        add = 2;
        sq = 6;
        hp = 5;
        score = 0;
    }

    // Update is called once per frame
    void Update() {

        hpr = GameObject.Find("HP").GetComponent<Text>();
        hpr.text = hp.ToString();

        if (levelUp) {
            sq += add;
            floor++;
            levelUp = false;
        }
    }
}
