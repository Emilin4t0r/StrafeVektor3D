using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleControl : MonoBehaviour
{
    void Awake() {
        Destroy(gameObject, 0.5f);
    }
}
