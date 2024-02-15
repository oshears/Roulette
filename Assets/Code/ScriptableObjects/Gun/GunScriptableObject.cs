using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "ScriptableObjects/GunScriptableObject")]
public class GunScriptableObject : ScriptableObject
{
	public int numBullets {get; private set;}
	
	public UnityEvent<bool> fireGunEvent;
	public UnityEvent addBulletEvent;
	public UnityEvent shuffleGunEvent;
	
	Queue<bool> _bulletQueue;
	
	void SetNumBullets(int numBullets)
	{
		if (numBullets > 5)
		{
			Debug.LogError("The gun is filled with bullets!!");
		}
		
		this.numBullets = numBullets;
		for (int i = 0; i < numBullets; i++)
		{
			_bulletQueue.Enqueue(true);
		}
		while(_bulletQueue.Count < 6)
		{
			_bulletQueue.Enqueue(false);
		}
	}
	
	void OnFireGunEvent()
	{
		fireGunEvent.Invoke(_bulletQueue.Dequeue());
	}
	
	void OnAddBulletEvent()
	{
		addBulletEvent.Invoke();
	}
	
	public void OnShuffleGun()
	{
		shuffleGunEvent.Invoke();
		
		// Fisher-Yates shuffle:
		bool[] tmpBulletArray = _bulletQueue.ToArray();
		int n = tmpBulletArray.Length;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0,n + 1);  
			bool card = tmpBulletArray[k];  
			tmpBulletArray[k] = tmpBulletArray[n];  
			tmpBulletArray[n] = card;  
		}
		
		_bulletQueue = new Queue<bool>(tmpBulletArray);  
	}
	
}