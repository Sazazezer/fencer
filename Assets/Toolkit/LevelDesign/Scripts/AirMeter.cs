using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirMeter : MonoBehaviour {

	public float air = 10;
	public float maxAir = 10;
	public float airBurnRate = .5f;

	private Player player;
	private Slider slider;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			return;

		if (air > 0) {
			air -= Time.deltaTime * airBurnRate;
			slider.value = air / maxAir;
		} else {
			var script = player.GetComponent<Explode> ();
			script.OnExplode ();

		}
	}
}
