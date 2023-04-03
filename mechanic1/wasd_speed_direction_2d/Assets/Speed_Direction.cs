using UnityEngine;

public class Speed_Direction : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb2d;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        // Change Speed
        if (Input.GetKey(KeyCode.W)) {
            speed += 0.1f;
        } else if (Input.GetKey(KeyCode.S)) {
            if (speed - 2 < 0 ) {
                speed = 0f;
            } else {
                speed -= 0.1f;
            }
        }

        // Change direction based on mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        rb2d.velocity = transform.up * speed;
    }
}