using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    public float speed = 5f;
    public Vector2Int sizeMinMax = new Vector2Int(7, 20);

    void Start() {
        var newScale = transform.localScale;
        newScale.x = Random.Range(sizeMinMax.x, sizeMinMax.y);
        transform.localScale = newScale;
    }

    void Update() {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);

    }

    private void FixedUpdate() {
    }
}
