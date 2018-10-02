using System.Collections;
using UnityEngine;
 

public class GameController : MonoBehaviour
{
    private ActorController[] players;

    [SerializeField]
    private float gameTime = 25F;

    [SerializeField]
    int numPlayers;
    public float CurrentGameTime { get; private set; }

    public GameObject player;
    public GameObject iA; 

    // Use this for initialization
    private IEnumerator Start()
    {
        numPlayers = Mathf.Clamp(numPlayers, 2, 5);

        CrearPlayers();

        CurrentGameTime = gameTime;

        // Sets the first random tagged player
        players = FindObjectsOfType<ActorController>();

        yield return new WaitForSeconds(0.5F);

        players[Random.Range(0, players.Length)].onActorTagged(true);

    }

    private void Update()
    { 
        if (CurrentGameTime <= 0F)
        {
            foreach(ActorController aC in players)
            { 
                aC.End();
            }
            CurrentGameTime = 0;
            BuscarGanador();
        }
        else
            CurrentGameTime -= Time.deltaTime;
    }

    private void CrearPlayers()
    {
        Instantiate(player, new Vector3(Random.Range(-25 , 25),2, Random.Range(-25, 25)), Quaternion.identity);

        for (int i = 0; i < numPlayers - 1; i++)
        {
            Instantiate(iA, new Vector3(Random.Range(-25, 25), 2, Random.Range(-25, 25)), Quaternion.identity);
        }
    }

    void BuscarGanador()
    {
        int temporal = 100;
        foreach (ActorController aC in players)
        {
            if(aC.timesTagged < temporal)
            {
                temporal = aC.timesTagged;
            }
            
        }

        foreach (ActorController aC in players)
        {
            if (aC.timesTagged == temporal)
            {
                aC.gameObject.GetComponent<Renderer>().material.color = new Color(1,1,0);
            }
        }
    }
}