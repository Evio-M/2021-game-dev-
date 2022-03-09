using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public Transform respawnPoint;
	public GameObject playerPrefab;

	private void Awake()
	{
		instance = this;
	}

	public void Respawn()
	{
		Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
	}
  
}
