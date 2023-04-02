using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpd = 10f;
    public GameObject cross;

    void Start() {
        cross = GameObject.FindGameObjectWithTag("Weapon");
    }

    void LateUpdate() {
        Vector3 desiredPos = new Vector3(player.transform.position.x, player.transform.position
            .y, transform.position.z);
        Vector3 smoothened = Vector3.Lerp(transform.position, desiredPos, smoothSpd * Time.deltaTime);
        transform.position = smoothened;

        // shake
        if (cross.GetComponent<Attack>().isActiveAndEnabled && cross.GetComponent<Attack>().att) {
            float randX = Random.Range(-0.03f, 0.03f);
            float randY = Random.Range(-0.03f, 0.03f);
            transform.localPosition = new Vector3(transform.localPosition.x + randX, transform.localPosition.y + randY);
        }
    }
}
