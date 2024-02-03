using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    public enum Side : int
    {
        Heads = 0,
        Tails = 1
    }

    // Subscribe to event to get the result of the flip
    private UnityEvent<Side> flipResult;

    [SerializeField]
    private float rotationSpeed = 1000f;

    [SerializeField]
    private float flipTime = 2f;

    // This allows you to flip the coin from the inspector
#if UNITY_EDITOR
    [SerializeField]
    private bool isFlipped = false;
    void Update()
    {
        if (!isFlipped)
        {
            FlipCoin();
            isFlipped = true;
        }
    }
#endif

    private void RenderCoin(bool isRendered)
    {
        GetComponent<Renderer>().enabled = isRendered;
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = isRendered;
        }
    }

    public void FlipCoin()
    {
        Side side = (Side) Random.Range(0, 2);
        StartCoroutine(StartFlipAnimation(side));
    }

    private IEnumerator StartFlipAnimation(Side side)
    {
        // Show coin
        RenderCoin(true);
        yield return new WaitForSeconds(.1f);
        // Rotate coin for 'waitTime'
        float waitTime = flipTime;
        while (waitTime > 0)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            yield return null;
            waitTime -= Time.deltaTime;
        }
        // End rotation on Heads or Tails
        while(true)
        {
            float xRotation = transform.rotation.eulerAngles.x;
            if (side == Side.Heads && xRotation < 90 && 90 - xRotation < 3)
            {
                transform.eulerAngles = new Vector3(90, 0);
                break;
            }
            else if (side == Side.Tails && xRotation > 270 && xRotation - 270 < 3)
            {
                transform.eulerAngles = new Vector3(270, 0);
                break;
            }
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            yield return null;
        }
        // Hide coin
        yield return new WaitForSeconds(1f);
        RenderCoin(false);
        // Trigger event
        flipResult?.Invoke(side);
    }

}
