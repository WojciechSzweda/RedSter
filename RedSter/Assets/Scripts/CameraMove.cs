using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed = 7f;

    void Start() {

    }

    void Update() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }


}
