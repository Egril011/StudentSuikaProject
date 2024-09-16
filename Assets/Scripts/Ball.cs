using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int ballType; // Le type de la balle (0, 1, 2, etc.)
    bool isFusioning;
    public int ballScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Emp�che la fusion si d�j� en cours
        if (isFusioning)
        {
            return;
        }

        // R�cup�re l'autre balle avec laquelle cette balle entre en collision
        var otherBall = collision.gameObject.GetComponent<Ball>();

        // V�rifie si l'autre objet est bien une balle et que les deux balles sont de m�me type
        if (otherBall != null && ballType == otherBall.ballType && !otherBall.isFusioning)
        {

            FindAnyObjectByType<Score>().AddScore(ballScore);

            // D�but de la fusion
            isFusioning = true;
            otherBall.isFusioning = true;

            // Calcule le point au milieu des deux balles
            Vector3 middlePoint = (transform.position + otherBall.transform.position) / 2F;

            // Nouveau type de balle (balle suivante dans l'ordre)
            int newBallType = ballType + 1;

            // V�rifie que le nouveau type de balle existe dans le tableau des prefabs
            if (newBallType < FindAnyObjectByType<Player>().ballPrefabs.Length)
            {
               

                // Appelle la fonction pour spawn la prochaine balle
                FindAnyObjectByType<Player>().SpawnBall(newBallType, middlePoint);

                // Destruction des deux balles fusionn�es
                Destroy(collision.gameObject); // L'autre balle
                Destroy(gameObject); // Cette balle


            }
            else
            {
                Destroy(collision.gameObject); // L'autre balle
                Destroy(gameObject); // Cette balle
            }
        }


    }
}