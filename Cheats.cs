using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
	public string[] cheats;//an array of string to hold our cheats
	public string activeCheat;//which cheat is being added
	public int index;//which letter of the active cheat is being written
	public float TotalDelay = 1;//allowed time between two click
	public float curDelay;//how much time has passed by after the click
	bool add = false;//should we add time to the curdelay
    
    void Awake()
    {
		index = 0;
		activeCheat = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(add)
		{
			curDelay += Time.deltaTime;
		}
		
		if(Input.anyKeyDown)
		{
			if (activeCheat == null)
			{
				for (int i = 0; i < cheats.Length; i++)
				{
					if (Input.GetKeyDown(cheats[i][0].ToString()))
					{
						
						SetActiveCheat(cheats[i]);
					}
				}
			}
			else 
			{
				
				if (TotalDelay>curDelay)
				{
					
					if (Input.GetKeyDown(activeCheat[index].ToString()))
					{
						add = false;
						index++;
						curDelay = 0;
						add = true;
					}
					else
					{
						ResetActiveCheat();
					}
					if (index == activeCheat.Length)
					{
						DoneCheat();
					}

				}
			}
				
		
			 
			
		}
		if (curDelay > TotalDelay)
		{
			ResetActiveCheat();
		}
	}
	void SetActiveCheat(string cheat)
	{
		activeCheat = cheat;
		index++;
		add = true;
		curDelay = 0;
	}
	void ResetActiveCheat()
	{
		activeCheat = null;
		index = 0;
		add = false;
		curDelay = 0;
	}
	void DoneCheat()
	{
		activeCheat = null;
		index = 0;
		curDelay = 0;
		add = false;
		Debug.Log("Cheat activated");
	}
}
