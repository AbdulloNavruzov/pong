using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

    private int hitCounter = 0;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    // public IEnumerator Launch()
    // {
    //     RestartBall();
    //     hitCounter = 0;
    //     yield return new WaitForSeconds(1);

    //     if(player1Start == true)
    //     {
    //         MoveBall(new Vector2(-1, 0));
    //     }

    //     else
    //     {
    //         MoveBall(new Vector2(1, 0));
    //     }
    // }

    public IEnumerator Launch()
    {
    RestartBall();
    hitCounter = 0;
    yield return new WaitForSeconds(1);

    // Randomize the Y component for different angles
    float randomY = Random.Range(-0.5f, 0.5f); // Random angle between -0.5 and 0.5 on the Y axis

    if(player1Start)
    {
        // Launch to the left with a random Y component
        MoveBall(new Vector2(-1, randomY));
    }
    else
    {
        // Launch to the right with a random Y component
        MoveBall(new Vector2(1, randomY));
    }
    }


    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter + extraSpeed; // increasing speed
        
        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
