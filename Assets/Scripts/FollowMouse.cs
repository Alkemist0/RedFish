using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 endPos;
    private Vector2 startPos;
    private float desiredLength = 2f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = transform.position;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            elapsedTime = 0f;
            transform.right = endPos - startPos;
        }

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredLength;

        transform.position = Vector2.Lerp(startPos, endPos, curve.Evaluate(percentageComplete));
    }
}
