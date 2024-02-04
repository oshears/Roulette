using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MenuScriptableObject", menuName = "ScriptableObjects/MenuScriptableObject")]
public class MenuScriptableObject : ScriptableObject
{
    //public string prefabName;

    //public int numberOfPrefabsToCreate;
    //public Vector3[] spawnPoints;

    public int rotation = 0;

    public UnityEvent rotateGunEvent;

    public UnityEvent increaseBulletCountEvent;

    public void rotateGun()
    {
        rotateGunEvent?.Invoke();
    }

    public void increaseBulletCount()
    {
        increaseBulletCountEvent?.Invoke();
    }
}