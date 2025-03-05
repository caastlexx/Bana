using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += moveVec * speed * Time.deltaTime;

        if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.5f) != null) {
            Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.5f);
            GameObject chunk = collider.attachedRigidbody.gameObject;
            ChunkCreator.checkChunkNeighbors(chunk);
        }
    }
}
