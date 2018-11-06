using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class share : MonoBehaviour {

    // facebook variables
    string AppID = "2861153000577617";

    string Link = "https://google.com";

    string caption = "Share my game";

	// Facebook
	public void fbShare () {
        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link + "&caption=" + caption);
	}
	
}
