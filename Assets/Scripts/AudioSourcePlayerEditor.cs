#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayRandomSound))]
public class AudioSourcePlayerEditor : Editor
{
	private void OnEnable()
	{
		//Debug.Log("AudioSourcePlayerEditor: OnEnable");
		//Debug.Log(target);
		//Debug.Log(target.name);            
	}


	public override void OnInspectorGUI()
	{
		//Debug.Log("AudioSourcePlayerEditor: OnInspectorGUI");

		//this will draw the default inspector for the component you are inspecting
		//instead of using a new custom object, you could add editor options to AudioSource
		//DrawDefaultInspector would add the default inspection controls with our custom button at the bottom
		//I find it easier to use the custom component, add it above the AudiSource in the editor
		//that makes the play button easier to spot and click            
		DrawDefaultInspector();


		if (GUILayout.Button("Play Audio Source"))
		{
			//button logic
			//Debug.Log("AudioSourcePlayerEditor: OnInspectorGUI: Play Audio Source");

			var player = (PlayRandomSound)target;
			player.Play_Audio_Source();
		}


		if (GUILayout.Button("Stop Audio Source"))
		{
			var player = (PlayRandomSound)target;
			player.Stop_Audio_Source();
		}
	}
}
#endif