using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefenderWeapons : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 2.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float firingRate = 2.5f;
    private Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();

        if(bullet)
        {
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator FireCoroutine()
    {
        float xOffset = 2.5f;
        while(true)
        {
            // fire a new bullet
        Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
        bullet.transform.position = (Vector2)transform.position + Vector2.right * xOffset;
        Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
        rbb.velocity = Vector2.right * BulletSpeed;

        yield return new WaitForSeconds(1 / firingRate);
        }
    }
}
