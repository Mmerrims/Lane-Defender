using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
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
}
