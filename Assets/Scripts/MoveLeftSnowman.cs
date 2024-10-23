using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftSnowman : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the left side of the screen
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
