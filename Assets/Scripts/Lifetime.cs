using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField] float lifetime;
    void Update()
    {
        lifetime -= 1 *Time.deltaTime;
        if (lifetime < 0) Destroy(this.gameObject);
    }
}
