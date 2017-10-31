using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject character;
    private List<Transform> checkpoints;
    private Transform currentCheckpoint;
    private static bool initialized = false;
    private bool spawning = false;
    private float timer = 0f;
    [SerializeField]
    private float timeBeforeSpawn = 2.0f;

    void Awake()
    {
        if(initialized)
        {
            Destroy(gameObject);
        } else
        {
            initialized = true;
            DontDestroyOnLoad(gameObject);
            checkpoints = new List<Transform>();
            foreach (Transform child in transform)
            {
                checkpoints.Add(child);
            }
            currentCheckpoint = this.transform;

            currentCheckpoint.GetComponent<Checkpoint>().SpawnPlayer(character);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        currentCheckpoint.GetComponent<Checkpoint>().SpawnPlayer(character);
    }

    // Use this for initialization
    void Start () {
  //      checkpoints = new List<Transform>();
  //      foreach (Transform child in transform)
  //      {
  //          checkpoints.Add(child);
  //      }
  //      currentCheckpoint = this.transform;
  //      currentCheckpoint.GetComponent<Checkpoint>().SpawnPlayer(character);
    }
	
	// Update is called once per frame
	void Update () {
        if(spawning)
        {
            timer += Time.deltaTime;
            if(timer >= timeBeforeSpawn)
            {
                SceneManager.LoadScene("Level Elric");
                timer = 0f;
                spawning = false;
            }
        }
    }

    public void SpawnPlayer()
    {
        spawning = true;
    }

    public void ChangeCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
