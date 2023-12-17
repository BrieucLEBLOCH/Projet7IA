using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class state : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract State RunnCurrentState();
}
