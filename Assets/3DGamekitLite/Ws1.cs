using UnityEngine;
using Gamekit3D; //Använd för alla script.
using UnityEngine.Events;

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

    private float timer = 0f;
    
    Rigidbody2D rb;

    public UnityEvent onStart;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onStart.Invoke();
        
        rb = GetComponent<Rigidbody2D>();
        speedMultiplier = 2.5f;
        currentSpeed = 5f;
        
        Damageable.DamageMessage dmg = new Damageable.DamageMessage()
        {
            amount = 1
        };
        
        newMethod(dmg);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInY();
        }
        SpeedUp();
    }

    void newMethod(Damageable.DamageMessage damage)
    {
        
    }

    void JumpInY()
    {
        rb.linearVelocityY = jumpforce;
        deathCountdown = Random.Range(1f, 8f);
        //Object.Destroy(this.gameObject, deathCountdown);
        
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
