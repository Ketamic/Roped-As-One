using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject[] links;

    public float timer = 3f;
    private bool dead = false;

    public AudioSource deathsound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hitspike");
        if (collision.gameObject.CompareTag("Player") == true)
        {
            for (int i = 0; i < links.Length; i++)
            {
                links[i].GetComponent<HingeJoint2D>().enabled = false;
            }
            playerOne.GetComponent<DistanceJoint2D>().enabled = false;

            dead = true;
            deathsound.PlayOneShot(deathsound.clip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitspike");
        if (collision.gameObject.CompareTag("Player") == true)
        {
            for (int i = 0; i < links.Length; i++)
            {
                links[i].GetComponent<HingeJoint2D>().enabled = false;
            }
            playerOne.GetComponent<DistanceJoint2D>().enabled = false;

            dead = true;
            deathsound.PlayOneShot(deathsound.clip);
        }
    }
}
