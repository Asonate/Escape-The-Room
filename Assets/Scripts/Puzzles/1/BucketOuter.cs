﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BucketOuter : MonoBehaviour
{
    public Text text;
    public Text selection;
    Bucket bucket;

    private void Start()
    {
        bucket = transform.parent.GetComponentInChildren<Bucket>();

        Vector3 startScale = new Vector3(0.1f * 7, 0.1f * bucket.capacity, 1f);
        transform.localScale = new Vector3(startScale.x * 1.2f, startScale.y * 1.2f, startScale.z);
        text.text = "/ " + bucket.capacity.ToString();
        selection.gameObject.SetActive(false);
    }

    public void BucketAction()
    {
        if (!PlayerData.currentlyInMenu)
        {
            if (!PuzzleOne.firstSelected)
            {
                if (bucket.current == 0) return;

                selection.gameObject.SetActive(true);
                PuzzleOne.first = bucket;
                PuzzleOne.firstSelected = true;
            }
            else
            {
                if (PuzzleOne.first == bucket)
                {
                    foreach (BucketOuter b in FindObjectsOfType<BucketOuter>())
                    {
                        b.selection.gameObject.SetActive(false);
                    }
                    PuzzleOne.firstSelected = false;
                    return;
                }
                if (bucket.current == bucket.capacity)
                {
                    foreach (BucketOuter b in FindObjectsOfType<BucketOuter>())
                    {
                        b.selection.gameObject.SetActive(false);
                    }
                    PuzzleOne.firstSelected = false;
                    return;
                }

                foreach (BucketOuter b in FindObjectsOfType<BucketOuter>())
                {
                    b.selection.gameObject.SetActive(false);
                }
                PuzzleOne.first.Transfer(bucket);
                PuzzleOne.firstSelected = false;
            }
        }
    }
}

