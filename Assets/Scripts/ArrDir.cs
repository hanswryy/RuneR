using UnityEngine;

public class ArrDir : MonoBehaviour
{
    GameObject exot;
    bool present = false;

    // Update is called once per frame
    void Update()
    {
        if (!present) {
            exot = GameObject.FindGameObjectWithTag("Exit");
            if (exot != null)
                present = true;
        }

        Vector2 dir = exot.transform.position - transform.position;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);
    }
}
