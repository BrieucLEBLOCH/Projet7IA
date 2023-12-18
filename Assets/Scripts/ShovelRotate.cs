using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelRotate : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f*rotSpeed);
    }
}
