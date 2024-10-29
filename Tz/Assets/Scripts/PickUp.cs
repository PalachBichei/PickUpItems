using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform m_PickUpPosition;
    public List<GameObject> PickUps;
    public List<GameObject> PutPos;
    [SerializeField] private TMP_Text Tutorial;
    [SerializeField] private GameObject WinPanel;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Finish"&&PickUps.Count==0)
        {
            Tutorial.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E)&&PickUps.Count==0)
            {
                other.gameObject.transform.SetParent(m_PickUpPosition);
                other.gameObject.transform.localPosition=Vector3.zero;
                PickUps.Add(other.gameObject);
            }
        }if (other.tag=="Put"&&PickUps.Count!=0)
        {
            Tutorial.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E)&&PickUps.Count!=0)
            {
                PickUps[0].transform.SetParent(null);
                PickUps[0].gameObject.transform.SetParent(PutPos[0].transform);
                PickUps[0].gameObject.transform.localPosition=Vector3.zero;
                PickUps.RemoveAt(0);
                PutPos.RemoveAt(0);
                Tutorial.gameObject.SetActive(false);
                CheckWin();
            }
        }
    }

    public void CheckWin()
    {
        if (PutPos.Count==0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<CameraController>().enabled = false;
            WinPanel.transform.DOScale(Vector3.one, 0.3f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Tutorial.gameObject.SetActive(false);
    }
}
