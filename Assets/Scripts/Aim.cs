using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator gunAnimator;
    public GameObject bullet;
    public GameObject player;
    public Transform shootingPoint;
    public AudioSource shootingSound;
    public AudioClip clip;
    public float weaponCoolDown = 1;
    bool fire = false;
    float lastThrowDate;
    void Start()
    {
        lastThrowDate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
        }
    }
    void FixedUpdate()
    {
        handleAiming();
        handleShooting();
    }
    private void handleShooting()
    {
        if (fire && (Time.time - lastThrowDate > weaponCoolDown))
        {
            gunAnimator.SetTrigger("fire");
            shootingSound.PlayOneShot(clip, 1);
            Instantiate(bullet, shootingPoint.position, transform.rotation);
            fire = false;
            lastThrowDate = Time.time;
        }

    }
    private void handleAiming()
    {
        Vector3 mousePos = getMouseWorldPosition();
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1.0f;
        }
        else
        {
            localScale.y = +1.0f;
        }
        localScale.x *= player.transform.localScale.x;

        transform.localScale = localScale;
    }

    private Vector3 getMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }
}
