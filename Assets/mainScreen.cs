using UnityEngine;
using System.Collections;

public class mainScreen : MonoBehaviour {

    public GameObject playButton;

    // Use this for initialization
    void Start () {

        Instantiate(playButton, new Vector3(1.5F, 2.5F, -1), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
