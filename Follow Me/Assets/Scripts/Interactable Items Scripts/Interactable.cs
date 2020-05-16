using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Interactions : UnityEvent<GameObject>
    {
        public GameObject gameObject;
    }
    public float radius = 3f;

    public Interactions OnInteract = new Interactions();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Interact(GameObject g)
    {
        OnInteract.Invoke(g);
    }
}
