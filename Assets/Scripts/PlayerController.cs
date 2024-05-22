using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cactusPrefab;
    [SerializeField] private float speed = 12.0f;
        [SerializeField] private float left = -8.4f;
        [SerializeField] private float right = 8.4f;
        [SerializeField] private float top = 4.5f;
        [SerializeField] private float bottom = -4.5f;
         private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessAxesMovement();

        if(Input.GetMouseButtonDown(0) && CanPlaceCactus())
        {
           Vector3 placementPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           placementPosition.z = 0;
           PlaceCactus(placementPosition);
        }
    }

    private void ProcessAxesMovement()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector2(hMove * speed, vMove * speed);
        float hPos = Mathf.Clamp(transform.position.x, left, right);
        float vPos = Mathf.Clamp(transform.position.y, bottom, top);
        transform.position = new Vector2(hPos, vPos);
    }

        private bool CanPlaceCactus()
        {
            return FindObjectOfType<GameController>().CanPlaceCactus();
        }

        private void PlaceCactus(Vector2 position)
        {
            Instantiate(cactusPrefab, position, Quaternion.identity);
            FindObjectOfType<GameController>().TakeCactus();
        }
    
}
