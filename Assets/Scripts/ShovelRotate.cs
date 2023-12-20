using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelRotate : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 1.0f;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f*(rotSpeed*player.GetWeaponSpeed()));
    }
}
