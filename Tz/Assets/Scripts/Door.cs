using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private TMP_Text Tutorial;
    public float rotationSpeed = 100f;
    private Vector3 targetRotation = new Vector3(0,0,0);
    private bool isOpening = false;

    void Update()
    {
        if (isOpening)
        {
            Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
            Quaternion currentQuaternion = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentQuaternion, targetQuaternion, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player"&&!isOpening)
        {
            Tutorial.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                isOpening = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Tutorial.gameObject.SetActive(false);
    }
}
