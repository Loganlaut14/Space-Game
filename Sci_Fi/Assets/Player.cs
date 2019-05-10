using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 40;

    public void SavePlayer()
    {
        SavedSystem.SavePlayer(this);

    }

    public void LoadPlayer ()
    {
        PlayerData data = SavedSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            //healthText.GetComponent<Text>().text = "Health" + health;
           //healthSlider.GetComponent<Slider>().value = health;
        }
        if (health <= 0)
        {
            //reload the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
