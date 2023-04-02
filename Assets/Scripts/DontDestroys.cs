using UnityEngine;

public class DontDestroys : MonoBehaviour
{
    public static DontDestroys instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }
}
