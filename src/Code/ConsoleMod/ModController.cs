using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Show to the user a window where the Buildron events will be logged. 
/// It's a very simple Unity3d MonoBehaviour that use some GUILayout stuffs to build its UI.
/// </summary>
public class ModController : MonoBehaviour
{
	#region Fields
	private string m_title;
	private Rect m_windowRect = new Rect(10, 10, 400, 300);
	private List<string> m_msgs = new List<string>();
	#endregion

	#region Constructors
	public ModController()
	{
		m_title = "Console mod (v.{0})".With(GetType().Assembly.GetName().Version);
	}
    #endregion

    #region Methods    
    /// <summary>
    /// Adds the message to the console window.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The arguments.</param>
    public void AddMessage(string message, params object[] args)
	{
		var formattedMessage = message.With(args);
		m_msgs.Insert(0, "[{0:HH:mm:ss}] {1}".With(DateTime.Now, formattedMessage));

		if (m_msgs.Count > 10)
		{
			m_msgs.RemoveAt(10);
		}
	}

	void OnGUI()
	{
		GUILayout.Window(1, m_windowRect, HandleWindowFunction, m_title, GUILayout.MinWidth(100), GUILayout.MinHeight(100));
	}

	void HandleWindowFunction(int id)
	{
		GUILayout.BeginVertical();

		foreach (var msg in m_msgs)
		{
			GUILayout.Label(msg);
		}

		GUILayout.EndVertical();
	}
	#endregion
}