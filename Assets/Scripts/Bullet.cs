using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator bulletAnimator;
    public float speed = 40.0f;
    bool destroy = false;

    void FixedUpdate()
    {
        if (!destroy)
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        destroy = true;
        bulletAnimator.SetBool("hit", destroy);
        Destroy(gameObject, 0.2f);
    }
}
