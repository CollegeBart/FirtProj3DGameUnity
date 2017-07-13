using UnityEngine;
using System.Collections;

public class FloorTriggerZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10f;

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
            col.SendMessage((isDamaging)?"TakeDamage":"HealDamage", Time.deltaTime * damage);
    }
}

