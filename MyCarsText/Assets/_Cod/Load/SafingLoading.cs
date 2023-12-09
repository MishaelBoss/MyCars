using UnityEngine;
using UnityEngine.UI;

public class SafingLoading : MonoBehaviour {
	public Slider slider;
	public int Level;
	private int slidV;
	private float timer;
	
	// Update is called once per frame
	void Update () {
		slider.value = slidV;
		timer +=6  * Time.deltaTime;
		if (timer >= 2) {
			slidV += 7;
			timer = 0;
		}
		if (slider.value >= 0.9) {
			Application.LoadLevel (Level);
		}
	}
}
