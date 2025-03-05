using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;   
    }
    public void OnClick(InputAction.CallbackContext context) {
        if (!context.started) return;

        RaycastHit2D[] rayHits = Physics2D.GetRayIntersectionAll(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHits.Length == 0) return;

        foreach (RaycastHit2D rayHit in rayHits) {
            GameObject hitObject = rayHit.collider.attachedRigidbody.gameObject;
            if (hitObject.CompareTag("Worker") && !hitObject.GetComponent<WorkerControl>().IsSelected()) {
                hitObject.GetComponent<WorkerControl>().SetSelected(true);
                break;
            } else {
                GameObject[] workers = GameObject.FindGameObjectsWithTag("Worker");

                foreach (GameObject worker in workers) {
                    if (worker.GetComponent<WorkerControl>().IsSelected()) {
                        worker.GetComponent<WorkerControl>().SetSelected(false);
                    }
                }
            }
        }
    }

    public void OnRightClick(InputAction.CallbackContext context) {
        if (!context.started) return;

        GameObject[] workers = GameObject.FindGameObjectsWithTag("Worker");

        foreach (GameObject worker in workers) {
            if (worker.GetComponent<WorkerControl>().IsSelected()) {
                worker.GetComponent<WorkerControl>().SetTargetPos(_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
            }
        }
    }
}
