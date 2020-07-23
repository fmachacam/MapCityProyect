using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeoMap : MonoBehaviour {
	private string urlMap = "";

	public RawImage imageMap;
	public Text latitudText;
	public Text longitudtext;

	public int zoom = 20;

	void Start(){
		StartCoroutine ("GetMap");
	}
	public void ZoomInButton(){
		zoom++;
		StartCoroutine ("GetMap");
	}
	public void ZoomOutButton(){
		if(zoom >= 0)zoom--;
		StartCoroutine ("GetMap");
	}
	private IEnumerator GetMap(){

		Input.location.Start ();
		float latitud = Input.location.lastData.latitude;
		yield return latitud;
		float longitud = Input.location.lastData.longitude;
		yield return longitud;

		urlMap = "http://maps.google.com/maps/api/staticmap?center="+latitud+","+longitud+"&markers=color:red%7Clabell:S%"+latitud+","+longitud+"&zoom="+zoom+"&size=350x1080"+"&maptype=hybrid&markers=color:red|label:|"+latitud+","+longitud+"&type=hybrid&sensor=true?a.jpg";
		WWW www = new WWW(urlMap);

		yield return www;

		imageMap.texture = www.texture;
		latitudText.text = "" + latitud;
		longitudtext.text = "" + longitud;
	}
}