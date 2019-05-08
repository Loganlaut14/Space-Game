using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    public int health = 10;
    public Text healthText;
    public Slider healthSlider;

    void Start()
    {
        healthSlider.GetComponent<Slider>().value = health;
        healthText.GetComponent<Text>().text = "Health" + health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            healthText.GetComponent<Text>().text = "Health" + health;
            healthSlider.GetComponent<Slider>().value = health;
        }
        if(health <= 0)
        {
            //reload the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
