using UnityEngine;

public class Ws1 : MonoBehaviour
{
    private bool lovesBurgers = true;
    private float currentPressurePsi = 6.7f;
    [SerializeField] int myAge = 20;
    public string myName = "Gabriel";
    private float currentSpeed;
    private float speedMultiplier;
    private float jumpforce = 5f;
    private float deathCountdown;
    
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedMultiplier = 2.5f;
        currentSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInY();
        }
        SpeedUp();
    }

    void JumpInY()
    {
        rb.linearVelocityY = jumpforce;
        deathCountdown = Random.Range(1f, 8f);
        Object.Destroy(this.gameObject, deathCountdown);
        
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("warning death in" + deathCountdown);
        }
    }

    void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            jumpforce = currentSpeed * speedMultiplier;
        }
        else
        {
            jumpforce = currentSpeed;
        }
    }
}
