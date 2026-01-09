using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody body;
    public float minInitialImpulse;
    public float maxInitialImpulse;
    public float maxInitialTorque;
    public float initialXRange;
    public float initialY;
    public int pointValue;
    public ParticleSystem explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        body = GetComponent<Rigidbody>();
        transform.position = new Vector2(RandomInitialX(), initialY);
        body.AddForce(RandomUpwardForce(), 
            ForceMode.Impulse);
        body.AddTorque(RandomTorque(),RandomTorque(), RandomTorque(),
            ForceMode.Impulse);        
    }

    float RandomInitialX() {
        return Random.Range(-initialXRange, initialXRange);
    }

    Vector2 RandomUpwardForce() {
        return Vector2.up * Random.Range(minInitialImpulse, maxInitialImpulse);
    }

    float RandomTorque() {
        return Random.Range(-maxInitialTorque, maxInitialTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.UpdateScore(pointValue);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        if (pointValue < 0)
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
