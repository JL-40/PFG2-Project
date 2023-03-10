using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifetime = 1f;

    float speed = 1000f;

    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= Time.deltaTime;
            Move();
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
