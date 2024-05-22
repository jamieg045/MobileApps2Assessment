using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private int pointsValue = 10;
    [SerializeField] private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.GetComponent<Bullet>();
        if(bullet)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            FindObjectOfType<GameController>().AddToScore(pointsValue);
        }
    }

}
