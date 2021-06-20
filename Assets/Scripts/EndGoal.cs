using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    private bool inGoal = false;

    public float timer = 3;
    private float TimerValue;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        TimerValue = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGoal == true)
        {
            timerText.gameObject.SetActive(true);
            timerText.text = Mathf.RoundToInt(timer).ToString();
            timer -= Time.deltaTime;
        }
        if(inGoal == false && timer < TimerValue)
        {
            timer += Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timer).ToString();
            if(timer >= TimerValue)
            {
                timerText.gameObject.SetActive(false);
            }
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");

        if(collision.CompareTag("Player") == true)
        {
            inGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inGoal = false;
    }
}
