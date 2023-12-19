using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KamikazeState : MonoBehaviour
{
    public abstract KamikazeState RunCurrentState();
}