using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float spd, timer;
    private Vector2 movement;
    public bool seen = false;
    public Slider bar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seen) {
            rb.WakeUp();
            Vector2 dir = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
            dir.Normalize();
            movement = dir;
        } else {
            rb.Sleep();
        }

        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        bar.transform.position = pos + new Vector3(0, 50, 0);

        //Die
        if(bar.value == 0) {
            GameObject.Find("Levels").GetComponent<Levels>().score += 100;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        if (seen) MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 dir) {
        rb.MovePosition((Vector2)transform.position + (dir * spd * Time.deltaTime));
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.tag == "Player") seen = true;
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.tag == "Player")  seen = false;
    }
}
