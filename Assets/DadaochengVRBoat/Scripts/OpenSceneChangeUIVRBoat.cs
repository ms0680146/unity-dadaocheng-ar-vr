﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneChangeUIVRBoat : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject SceneChangeUI;

    public float RayLength = 50f;
    float time;
    float gazeduration = 2;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "SceneChangeIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                OpenSceneUI();
            }

            if (hit.collider.tag == "CloseSceneIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                CloseSceneUI();
            }

        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenSceneUI()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            SceneChangeUI.SetActive(true);
        }
    }

    void CloseSceneUI()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            SceneChangeUI.SetActive(false);
        }
    }
}