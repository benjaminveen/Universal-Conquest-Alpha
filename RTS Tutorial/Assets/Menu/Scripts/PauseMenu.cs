using UnityEngine;
using RTS;

public class PauseMenu : Menu {

	private Player player;
	
	protected override void Start () {
		base.Start();
		player = transform.root.GetComponent<Player>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) Resume();
	}
	
	protected override void SetButtons () {
		buttons = new string[] {"Resume", "Exit Game"};
	}
	
	protected override void HandleButton (string text) {
		switch(text) {
			case "Resume": Resume(); break;
			case "Exit Game": ReturnToMainMenu(); break;
			default: break;
		}
	}
	
	private void Resume() {
		Time.timeScale = 1.0f;
		GetComponent<PauseMenu>().enabled = false;
		if(player) player.GetComponent<UserInput>().enabled = true;
		Screen.showCursor = false;
		ResourceManager.MenuOpen = false;
	}
	
	private void ReturnToMainMenu() {
		Application.LoadLevel("MainMenu");
		Screen.showCursor = true;
	}
	
}