using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private float rightBound = 30;
    private float leftBound = -10;
    private GameManager gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x < leftBound)
        {

            if (CompareTag("Sun"))
            {
                if (gameManager != null)
                {
                    gameManager.LoseLife();
                }
            }

            Destroy(gameObject);
        }
    }

}
