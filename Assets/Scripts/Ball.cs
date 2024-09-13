using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballType;
    public Player ball;
    public TMP_Text ballText;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherBall = collision.gameObject.GetComponent<Ball>();
        if (otherBall != null)
        {
            Debug.Log($"Ball {gameObject.name} collide with ball {collision.gameObject.name}");

            if (ballType == otherBall.ballType)
            {
                ball.playerScore++;
                ballText.text = ball.playerScore.ToString();

                Vector3 ballPosition = transform.position;
                Destroy(otherBall.gameObject);
                Instantiate(ball.ballPrefabs[ballType+1], ballPosition, Quaternion.identity);

            }
        }
    }
}
