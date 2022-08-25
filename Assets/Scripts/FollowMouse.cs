using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 endPos;
    private Vector2 startPos;
    private float desiredLength = 2f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;

    public bool reachedDestination = true;

    private void Start()
    {
        startPos = transform.position;
        endPos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reachedDestination)
        {
            startPos = transform.position;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            elapsedTime = 0f;
            transform.right = endPos - startPos;
        }

        if(new Vector2(transform.position.x, transform.position.y) == endPos)
        {
            reachedDestination = true;
        } else
        {
            reachedDestination = false;
        }

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredLength;

        transform.position = Vector2.Lerp(startPos, endPos, curve.Evaluate(percentageComplete));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
