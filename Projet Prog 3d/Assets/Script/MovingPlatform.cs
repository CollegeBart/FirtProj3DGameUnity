using UnityEngine;
using System.Collections;


public class MovingPlatform : MonoBehaviour {


    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;

    }

    private void Update()
    {
        transform.position = startPosition + (Vector3.right * Mathf.Sin(Time.time));


    }
}