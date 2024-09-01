using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] float scoreValue;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.FindObjectOfType<GameManager>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2((speed * -100), 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Killed()
    {
        ///Do explosion animation, SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killbox") != false)
        {
            //Take damage
            ///!!!!!!!!!!!!!LOOOOK HERE
            //manager.GetComponent<GameManager>().LoseLife;
            //delete self
            Destroy(gameObject);
        }
    }
}
