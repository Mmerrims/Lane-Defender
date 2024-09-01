using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileController : MonoBehaviour
{ 
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2((speed * 100), 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            //Destroy self here
            gameObject.SetActive(false);
            //explosion comes from Enemy Killed script
            collision.gameObject.GetComponent<Enemy>().Killed();
        }
    }


}
