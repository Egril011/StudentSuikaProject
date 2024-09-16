using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    public GameObject[] ballPrefabs;

    public TMP_Text ballGameOver;


    [SerializeField] AudioSource dropAudio;
    [SerializeField] AudioSource fusionAudio;
    [SerializeField] Transform spawnOffset;

    private GameObject currentBall;

    private void Start()
    {
        // enable GameOvertexte to false
        ballGameOver.enabled = false;
        GrabBall();
    }

    private void GrabBall()
    {
        int ballIndex = UnityEngine.Random.Range(0, ballPrefabs.Length);
        var ballPrefab = ballPrefabs[ballIndex];
        currentBall = Instantiate(ballPrefab, spawnOffset.position, Quaternion.identity, spawnOffset);
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        //Faire une copie de la position du joueur
        Vector3 nextPosition = transform.position;

        //Appliquer le deplacement a la copie
        nextPosition += new Vector3(x, 0, 0) * Time.deltaTime * 3;

        //Ajuster la position pour rester entre le minimum et le maximum
        nextPosition.x = Mathf.Clamp(nextPosition.x, -2.5f, 2.6f);

        //Appliquer la nouvelle position
        transform.position = nextPosition;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            currentBall.transform.parent = null;
            currentBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            dropAudio.Play();
            Invoke("GrabBall", 1.5f);
        }
    }

    internal void SpawnBall(int value, Vector3 spawnPosition)
    {
        // Vérifie que le type de balle est valide
        if (value >= ballPrefabs.Length)
        {
            Debug.Log("Impossible de générer une nouvelle balle. Valeur trop élevée.");
            return;
        }

        // Joue l'audio de fusion
        fusionAudio.Play();

        // Crée la nouvelle balle fusionnée
        var fusionBall = Instantiate(ballPrefabs[value], spawnPosition, Quaternion.identity);

        // Configure le Rigidbody2D pour que la balle soit dynamique
        var rb = fusionBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void GameOver()
    {
        
    }
}
