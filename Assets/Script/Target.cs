using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private gameManager GM;
    private Rigidbody rb;
    private float maxForce = 15f;
    private float minForce = 12f;
    private float maxTorque = 5f;
    private float xpos = 4f;
    private float ypos = -6f;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<gameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(randomForce(), ForceMode.Impulse);
        rb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomPos();
    }

    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 randomPos()
    {
        return new Vector3(Random.Range(-xpos, xpos), ypos, -1f);
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            GM.updateScore(1);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            GM.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Good"))
            {
                GM.GameOver();
            }
        }
    }
}
