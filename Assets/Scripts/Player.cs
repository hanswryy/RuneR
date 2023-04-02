using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool hit = false, drain = true;
    public bool paused = false;
    private float timer = 0;
    private Animator anim;
    private GameOver_Buttons btn_func;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        anim = GetComponent<Animator>();
        btn_func = GameObject.Find("Button_functions").GetComponent<GameOver_Buttons>();
    }

    // Update is called once per frame
    void Update() {
        //Resume
        if (paused) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                btn_func.pause_panel.SetActive(false);
                btn_func.pause_btn.GetComponent<Image>().enabled = true;
                Time.timeScale = 1;
                paused = false;
            }
        }

        if (hit) {
            timer += Time.deltaTime;
            if (timer < 3f) {
                drain = false;
            } else {
                drain = true;
                hit = false;
                timer = 0;
            }
        }

        if (GameObject.Find("Levels").GetComponent<Levels>().hp == 0)
            Die();
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            anim.Play("invin");
            hit = true;
            if (drain)
                GameObject.Find("Levels").GetComponent<Levels>().hp--;
        }
    }

    void Die() {
        //Destroy(GameObject.Find("Levels"));
        panel.gameObject.SetActive(true);
        GameObject.Find("score").GetComponent<Text>().text = GameObject.Find("Levels").GetComponent<Levels>().score.ToString();
        GameObject.Find("highest_floor").GetComponent<Text>().text = "Highest Floor : " + GameObject.Find("Levels").GetComponent<Levels>().floor.ToString();
        Time.timeScale = 0;
    }
}
