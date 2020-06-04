using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    /// кількість зібраних кубів
    private int count;
    /// Початкова кількість кубів
    private int countCoub;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; /// по замовчуванням зібрано 0 кубів

        countCoub = GameObject.FindGameObjectsWithTag("cubes").Length;
    }

    // Update is called once per frame
    void Update()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cubes")
        {
            Destroy(other.gameObject);
            count++;
        }
    }
}
