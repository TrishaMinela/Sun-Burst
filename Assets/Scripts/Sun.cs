using UnityEngine;

public class Sun : MonoBehaviour
{
    public int hitsToDestroy;
    public int score;
    private GameManager gameManager;
    public GameObject sunBurst;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage()
    {
        hitsToDestroy--;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Snow"))
        {

            TakeDamage();


            Destroy(other.gameObject);


            if (hitsToDestroy <= 0)
            {
                Instantiate(sunBurst, transform.position, transform.rotation);
                gameManager.UpdateScore(score);
                Destroy(gameObject);

            }
        }
    }
}
