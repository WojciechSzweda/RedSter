using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public float speed = 7f;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = 0.4f;
    [Range(0f, 1f)]
    public float smoothingAirborne = 0.2f;
    [Range(0f, 1f)]
    public float smoothingGrounded = 0.1f;
    float maxJumpVelocity;
    float minJumpVelocity;
    float gravity;
    Vector3 velocity;
    float velocityXSmoothing;
    float moveTime;
    PlayerController controller;

    void Start() {
        controller = GetComponent<PlayerController>();

        gravity = -(2 * maxJumpHeight) / (timeToJumpApex * timeToJumpApex);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    void Update() {

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        float inputX = Input.GetAxisRaw("Horizontal");

        float targetVelocityX = inputX * speed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, controller.collisions.below ? smoothingGrounded : smoothingAirborne);

        if (Mathf.Abs(velocity.x) > 1) {
            moveTime += Time.deltaTime;
        }
        else {
            moveTime = 0f;
        }

        if (Input.GetButtonDown("Jump") && controller.collisions.below) {
            velocity.y = maxJumpVelocity;
        }

        if (Input.GetButtonUp("Jump")) {
            if (velocity.y > minJumpVelocity)
                velocity.y = minJumpHeight;
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
