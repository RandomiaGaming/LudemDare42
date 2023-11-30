using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum HealthBarDirection { RightToLeft, LeftToRight };
public class HealthBar : MonoBehaviour
{
    public HealthBarDirection healthBarDirection = HealthBarDirection.RightToLeft;
    public HealthController targetHealthController;
    [Space]
    public Sprite fullHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite emptyHeartSprite;
    [Space]
    public GameObject heartContainer;

    private Image[] heartContainers = new Image[0];
    private void Start()
    {
        RefreshHeartContainers();
    }
    private void Update()
    {
        if (targetHealthController is null)
        {
            Debug.LogWarning("targetHealthController is null on HealthBar.");
            return;
        }
        RefreshHeartContainers();
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (targetHealthController.GetHealth() >= (i + 1) * 2)
            {
                heartContainers[i].sprite = fullHeartSprite;
            }
            else if (targetHealthController.GetHealth() >= ((i + 1) * 2) - 1)
            {
                heartContainers[i].sprite = halfHeartSprite;
            }
            else
            {
                heartContainers[i].sprite = emptyHeartSprite;
            }
        }
    }
    private void RefreshHeartContainers()
    {
        int requiredHeartContainers = targetHealthController.GetHeartContainers();
        if (heartContainers.Length == requiredHeartContainers)
        {
            return;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        heartContainers = new Image[requiredHeartContainers];
        for (int i = 0; i < requiredHeartContainers; i++)
        {
            GameObject heartContainGameObject = Instantiate(heartContainer, transform);
            Image heartContainerImage = heartContainGameObject.GetComponent<Image>();
            if (healthBarDirection == HealthBarDirection.RightToLeft)
            {
                heartContainers[i] = heartContainerImage;
            }
            else
            {
                heartContainers[requiredHeartContainers - i - 1] = heartContainerImage;
            }
        }
    }
}
