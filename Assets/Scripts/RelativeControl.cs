using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class RelativeControl : MonoBehaviour
{
    public GameObject move, move_bg;
    bool sw = true;
    Vector3 tp = new Vector3(247f, 270.25f, 0f);

    // Update is called once per frame
    void Update()
    {

        //if (InputHelper.GetTouch(0).phase == TouchPhase.Began && Input.mousePosition.x < 700f && Input.mousePosition.y < 542.5f && sw) {
        //    move.GetComponent<Joystick>().m_StartPos = Input.GetTouch(0).position;
        //    move.transform.position = move.GetComponent<Joystick>().m_StartPos;
        //    sw = false;
        //}

        List<Touch> touches = InputHelper.GetTouches();

        if (touches.Count > 0) {
            foreach (Touch touch in touches) {
                if (touch.phase == TouchPhase.Began && Input.mousePosition.x < 700f && Input.mousePosition.y < 542.5f) {
                    move.GetComponent<Joystick>().m_StartPos = touch.position;
                    move.transform.position = touch.position;
                    move_bg.transform.position = touch.position;
                    sw = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && !sw) {
            move.GetComponent<Joystick>().m_StartPos = tp;
            move.transform.position = tp;
            move_bg.transform.position = tp;
            sw = true;
        }
    }
}
