using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Axe : MonoBehaviour
{
    [YarnCommand("destroy")]
    public void Destroy() {
        Destroy(gameObject);
    }
}
