using UnityEngine;

public class Speed_Direction_Friction : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    public float friction;
    private Rigidbody2D rb2d;

    public Vector2 movement;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        // Change direction based on mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        // Apply friction to the movement
        Vector2 velocity = rb2d.velocity;
        if (velocity.magnitude > 0) {
            velocity -= friction * velocity.normalized * Time.deltaTime;
            if (velocity.magnitude < 0.01f) {
                velocity = Vector2.zero;
            }
        }
        rb2d.velocity = velocity;

        // Change Speed
        if (Input.GetKey(KeyCode.UpArrow)) {
            moveCharacter(transform.up);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            moveCharacter(-transform.up);
        }
    }

    void moveCharacter(Vector3 direction) {
        rb2d.AddForce(direction * speed);
    }
}