using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UIScriptableObject", menuName = "ScriptableObjects/UIScriptableObject")]
public class UIScriptableObject : ScriptableObject
{
    //public string prefabName;

    //public int numberOfPrefabsToCreate;
    //public Vector3[] spawnPoints;

    int _rotation = 0;

    public UnityEvent rotateGunEvent;
    public UnityEvent increaseBulletCountEvent;
    public UnityEvent shootGunEvent;
    public UnityEvent dealCardsEvent;
    public UnityEvent resetScoresEvent;

    public void OnRotateGun()
    {
        rotateGunEvent?.Invoke();
    }

    public void OnIncreaseBulletCount()
    {
        increaseBulletCountEvent?.Invoke();
    }

    public void OnShootGun()
    {
        shootGunEvent?.Invoke();
    }
    public void OnResetScores(){
        resetScoresEvent.Invoke();
    }

    public void OnDealCards(){
        dealCardsEvent.Invoke();
    }
}