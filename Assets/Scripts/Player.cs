using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    public GameObject[] ballPrefabs;
    public int playerScore;
    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        //Faire une copie de la position du joueur
        Vector3 nextPosition = transform.position;

        //Appliquer le deplacement a la copie
        nextPosition += new Vector3(x, 0, 0) * Time.deltaTime * 3;

        //Ajuster la position pour rester entre le minimum et le maximum
        nextPosition.x = Mathf.Clamp(nextPosition.x, -2.5f, 3.3f);

        //Appliquer la nouvelle position
        transform.position = nextPosition;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            int ballIndex = Random.Range(0, ballPrefabs.Length);
            var ballPrefab = ballPrefabs[ballIndex];
            Instantiate(ballPrefab,transform.position, Quaternion.identity);
        }
    }
}
