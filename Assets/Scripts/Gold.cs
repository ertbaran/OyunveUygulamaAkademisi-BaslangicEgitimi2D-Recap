using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    Rigidbody2D _rigid;
    int point = 0;
    [SerializeField] AudioClip _goldSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            point++;
            AudioSource.PlayClipAtPoint(_goldSound, collision.transform.position);
        }
    }
}
