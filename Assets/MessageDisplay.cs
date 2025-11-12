using TMPro;
using System.Collections;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text messageText;
    [SerializeField] float messageDuration = 2f;

    private Coroutine currentMessage;
    [SerializeField] Transform targetToFollow; // assign your car/player here
    [SerializeField] Vector3 offset = new Vector3(0, 2, 0); // adjust as needed

    void LateUpdate()
    {
        if (targetToFollow != null)
            transform.position = targetToFollow.position + offset;
    }
    public void ShowMessage(string message)
    {
        if (currentMessage != null)
            StopCoroutine(currentMessage);

        currentMessage = StartCoroutine(DisplayMessage(message));
    }

    private IEnumerator DisplayMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(messageDuration);

        messageText.text = ""; // Clear the text instead of deactivating
        
    }
}
