﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMapUI : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject MapUI;
    public float RayLength = 50f;
    float time;
    float gazeduration = 2;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "MapIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                TeleportMarker.transform.localScale = new Vector3(0.2f, 0, 0.2f);
                OpenMap();
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenMap()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            MapUI.SetActive(true);
        }
    }
}