using UnityEngine;

public class GraplingHook : MonoBehaviour {

    public float speed = 6f;
    public float maxHookLength = 5f;
    public GameObject hookHolder;

    LineRenderer lr;
    bool fired = false;
    bool hooked = false;
    Vector3 targetPosition;
    Vector3 velocity;
    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {



        if (Input.GetButtonDown("Fire1")) {
            if (fired) {
                ResetHook();
            }
            if (fired == false && hooked == false) {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0;
                fired = true;
                transform.SetParent(null);
                Vector3 direction = targetPosition - transform.position;
                velocity = direction.normalized * speed;
            }
        }

        if (fired) {
            lr.positionCount = 2;
            lr.SetPosition(0, hookHolder.transform.position);
            lr.SetPosition(1, transform.position);
            transform.Translate(velocity * Time.deltaTime);
        }

        if (Vector2.Distance(hookHolder.transform.position, transform.position) > maxHookLength) {
            ResetHook();
        }

    }

    void ResetHook() {
        transform.SetParent(hookHolder.transform);
        lr.positionCount = 0;
        transform.position = hookHolder.transform.position;
        fired = false;
    }
}
