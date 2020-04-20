using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float angleDiff0 = Random.Range(-35f, -25f);
        float angleDiff1 = Random.Range(25f, 35f);
        int r = Random.Range(0, 2);
        Vector3 difference = Earth.Instance.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + (r == 0 ? angleDiff0 : angleDiff1);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        float x = Mathf.Cos(rotationZ * Mathf.PI / 180f);
        float y = Mathf.Sin(rotationZ * Mathf.PI / 180f);
        rb.AddForce(new Vector2(x, y) * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void Update()
    {
        // Rotate
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        // Add gravity towards  center
        float dist = Vector2.Distance(Earth.Instance.transform.position, transform.position) + 0.5f;
        Vector2 force = (Earth.Instance.transform.position - transform.position).normalized;
        rb.AddForce(force * 4f * (1f / (dist * dist)) * Time.fixedDeltaTime, ForceMode2D.Impulse);

        rb.velocity = rb.velocity.normalized * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Earth")
            Health.TakeDamage(20);

        DestroyMissile();
    }

    public void DestroyMissile()
    {
        Shaker.Shake(0.1f);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, -2f);
        Transform exp = Instantiate(GameManager.Instance.ExplosionPrefab, pos, Quaternion.identity);
        exp.GetComponent<Explosion>().PlayExplosionSound("small");
        Destroy(gameObject);
    }

}
