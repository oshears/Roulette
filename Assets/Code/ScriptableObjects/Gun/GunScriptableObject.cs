using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "ScriptableObjects/GunScriptableObject")]
public class GunScriptableObject : ScriptableObject
{
	public int numBullets {get; private set;}
	
	public UnityEvent<bool> fireGunEvent;
	public UnityEvent addBulletEvent;
	public UnityEvent shuffleGunEvent;
	public UnityEvent initGunEvent;
	public UnityEvent<int> updateGunRotationEvent;
	
	public UnityEvent<int> numBulletsUpdatedEvent;
	public UnityEvent<bool> setGunActiveEvent;
	
	// public Vector3 gunRotation {get; private set;}
	
	Queue<bool> _bulletQueue = new Queue<bool>();
	
	int _currentTarget;
	
	public void OnInitializeGun()
	{
		_bulletQueue.Clear();
		numBullets = 0;
		initGunEvent.Invoke();
		OnSetGunActive(false);
	}
	
	public void SetNumBullets(int numBullets)
	{
		if (numBullets > 5)
		{
			Debug.LogError("The gun is filled with bullets!!");
		}
		
		this.numBullets = numBullets;
		_bulletQueue.Clear();
		for (int i = 0; i < numBullets; i++)
		{
			_bulletQueue.Enqueue(true);
		}
		while(_bulletQueue.Count < 6)
		{
			_bulletQueue.Enqueue(false);
		}
		
		numBulletsUpdatedEvent.Invoke(numBullets);
	}
	
	public bool OnFireGunEvent()
	{
		bool bulletFired = _bulletQueue.Dequeue();
		fireGunEvent.Invoke(bulletFired);
		return bulletFired;
	}
	
	public void OnAddBullet()
	{
		addBulletEvent.Invoke();
		
		_bulletQueue.Enqueue(true);
	}
	
	public void OnShuffleGun()
	{
		shuffleGunEvent.Invoke();
		
		// Fisher-Yates shuffle:
		bool[] tmpBulletArray = _bulletQueue.ToArray();
		int n = tmpBulletArray.Length;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0, n + 1);  
			bool card = tmpBulletArray[k];  
			tmpBulletArray[k] = tmpBulletArray[n];  
			tmpBulletArray[n] = card;  
		}
		
		_bulletQueue = new Queue<bool>(tmpBulletArray);  
	}
	
	public void OnUpdateGunRotation(int targetId)
	{
		// this.gunRotation = gunRotation;
		_currentTarget = targetId;
		updateGunRotationEvent.Invoke(targetId);
	}
	
	public bool HasOnlyBulletsLeft()
	{
		return !_bulletQueue.Contains(false);
	}
	
	public int GetNumEmptyShells()
	{
		return _bulletQueue.Where(x => x == false).Count();
	}
	
	public void OnSetGunActive(bool active)
	{
		setGunActiveEvent.Invoke(active);
	}
	
}