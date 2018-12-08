using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger : MonoBehaviour {
	void Update () {
        if (Input.GetButtonDown("Submit") & GameObject.FindGameObjectWithTag("Reader") != null)
        {
            GameObject.FindGameObjectWithTag("Reader").GetComponent<ReaderScript>().enabled = true;
        }
	}
}
