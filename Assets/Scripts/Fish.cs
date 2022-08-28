using UnityEngine;

public class Fish : MonoBehaviour
{
    public bool isRed;

    public GameManager GameManager;
    private GameObject target;

    private bool reachedDestination = true;

    private Vector2 endPos;
    private Vector2 startPos;
    private float desiredLength = 0.5f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;

    private void Awake()
    {
        if(!isRed)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Target").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Target")[i].name == gameObject.name) target = GameObject.FindGameObjectsWithTag("Target")[i];
            }
        }
    }

    private void Update()
    {
        if(reachedDestination)
        {
            startPos = transform.position;
            endPos = target.transform.position;
            elapsedTime = 0f;
        } else
        {
            transform.right = endPos - startPos;
        }

        if (new Vector2(transform.position.x, transform.position.y) == endPos)
        {
            reachedDestination = true;
        }
        else
        {
            reachedDestination = false;
        }

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredLength;

        transform.position = Vector2.Lerp(startPos, endPos, curve.Evaluate(percentageComplete));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.aliveFish--;
        Destroy(gameObject);
    }
}
