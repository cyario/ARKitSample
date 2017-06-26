using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private bool _startRunning;
    private float _startEulerY;

    void Start()
    {
        _startEulerY = Random.Range(0, 360);
        this.transform.rotation = Quaternion.Euler(0, _startEulerY ,0);
    }

	void Update ()
    {
        if (_startRunning) {
            this.transform.rotation = Quaternion.Euler(0, _startEulerY, 0);
            this.transform.Translate(this.transform.forward * 0.001f, Space.World);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") {
            _startRunning = true;
        }
    }
}