using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float scoreValue;
    private GameManager manager;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip loseHealthSound;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.FindObjectOfType<GameManager>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2((speed * -25), 0));
    }

    public void Killed()
    {
        ///Do explosion animation, SetActive(false);
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Killbox") != false)
        {
            //Take damage
            //Excuse my language but FUCK THIS. I forgot the () at the end of LoseLife
            //and spent 2 and a half hours trying to fix it only for it to be a FUCKING PARENTHESIS'
            manager.GetComponent<GameManager>().LoseLife();
            
            //delete self
            Destroy(gameObject);
            
        }
         if (collider.gameObject.CompareTag("Projectile") != false)
        {
            collider.gameObject.SetActive(false);
            //Takes Damage Here
            health--;
            //PlayAnimHere
            Debug.Log("Enemy Took Damage");
            AudioSource.PlayClipAtPoint(hitSound, Vector3.zero, 3f);
            //This resets the speed
            GetComponent<Rigidbody2D>().AddForce(new Vector2((speed * 25), 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector2((speed * -25), 0));

            if (health == 0)
            {
                manager.GetComponent<GameManager>().AddScore(scoreValue);
                AudioSource.PlayClipAtPoint(deathSound, Vector3.zero, 3f);
                Debug.Log("EnemyDied");
                Destroy(gameObject);
            }

            
        }
    }


}
