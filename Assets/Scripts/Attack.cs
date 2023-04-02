using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public bool att = false;
    private CircleCollider2D hitb;
    public float timer;

    void Start()
    {
        hitb = GetComponent<CircleCollider2D>();
    }

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            anim.Play("attack");
            att = true;
            hitb.radius = 10;
            hitb.offset = new Vector2(4, 0);
            if (this.isActiveAndEnabled) {
                coll.GetComponent<Enemies>().bar.value -= Time.deltaTime;
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            anim.Play("New State");
            att = false;
            hitb.radius = 5;
            hitb.offset = new Vector2(0, 0);
        }
    }

    void Done() {
        anim.Play("attack");
    }
}
