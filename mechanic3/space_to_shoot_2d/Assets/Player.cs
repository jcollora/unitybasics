using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float speed = 7f;
    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 1f;
    private float cooldown = 0.01f;
    private float nextFire = 0f;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }
	
    void Update () {
      UpdateMotion();
      ProcessBulletSpwan();
    }

    private void UpdateMotion() {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
    
    private void ProcessBulletSpwan() {
      if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Time.time > nextFire) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.UpArrow)) {
          re.velocity = Vector2.up * bulletSpeed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
          re.velocity = Vector2.down * bulletSpeed;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
          re.velocity = Vector2.left * bulletSpeed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
          re.velocity = Vector2.right * bulletSpeed;
        }
        nextFire = Time.time + cooldown;
      }
    }
}
