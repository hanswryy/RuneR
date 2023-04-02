using UnityEngine;
using UnityEngine.UI;

public class EnemyIdentifier : MonoBehaviour {
    public int spawned;
    public GameObject barr;
    int i = 0;
    bool worldstay = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (i < spawned) {
            //enemiess.Add(GameObject.FindGameObjectWithTag("Enemy"));
            GameObject bar = Instantiate(barr, transform.position, transform.rotation);
            if (GameObject.FindGameObjectsWithTag("Enemy")[i].transform.childCount < 2) {
                bar.transform.SetParent(GameObject.FindGameObjectsWithTag("Enemy")[i].transform);
                Slider bare = bar.GetComponentInParent<Enemies>().bar = bar.GetComponentInChildren<Slider>();
                bare.maxValue = 2;
                bare.minValue = 0;
                bare.value = 2;
                bare.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
                bare.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().enabled = false;
                bare.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().enabled = false;
            }
            i++;
        }

    }
}
