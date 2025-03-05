using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorkerControl : MonoBehaviour
{
    float speed = 1f;
    Vector2 targetPos;
    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected() && (Vector2)transform.position != GetTargetPos())
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

    }

    public void SetSelected(bool val) {
        selected = val;
    }

    public bool IsSelected() {
        return selected;
    }

    public void SetTargetPos(Vector2 newPos) {
        targetPos = newPos;
    }

    public Vector2 GetTargetPos() {
        return targetPos;
    }

}
