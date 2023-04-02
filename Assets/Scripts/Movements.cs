using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Movements : MonoBehaviour
{
    public float speed, spd2;
    public Animator anim;
    public GameObject cross;
    private float timer;
    private bool startt = false, dash = false;
    private float max_dash = 0;
    Button dashButton;
    [SerializeField] private Text tek;

    void Start() {
        spd2 = speed;
        dashButton = GameObject.Find("DashButton").GetComponent<Button>();
        dashButton.interactable = false;
    }
  
    void Update() {
        //Vector3 move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        MoveCrossHair();

        //anim.SetFloat("Horizontal", move.x);
        //anim.SetFloat("Vertical", move.y);
        //anim.SetFloat("Magnitude", move.magnitude);

        transform.position = transform.position + move * Time.deltaTime * speed;

        // Dash

        if (max_dash < 2) max_dash += Time.deltaTime;

        tek.text = max_dash.ToString("0.0");

        if (max_dash > 1) {
            dashButton.interactable = true;
        } else dashButton.interactable = false;
        if (timer <= 0.1f && dash) {
            speed = 25;
            timer = timer + Time.deltaTime;
        } else {
            speed = spd2;
            timer = 0;
            dash = false;
        }
    }

    void MoveCrossHair() {
        Vector3 aim = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"));
        Vector3 dir = cross.transform.position - transform.position;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        cross.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
        if (cross.transform.localPosition == new Vector3(0.0f, 0.0f, 2.0f)) {
            cross.GetComponent<Attack>().enabled = false;
            cross.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            cross.GetComponent<Attack>().enabled = true;
            cross.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (aim.magnitude >= 0.0f) {
            aim.Normalize();
            aim *= 12f;
            cross.transform.localPosition = aim;
            cross.transform.localPosition = new Vector3(cross.transform.localPosition.x, cross.transform.localPosition.y, 2f);
        }
    }

    void Shift() {
        dash = true;
        max_dash -= 1;
    }

}
