using UnityEngine;
using UnityEditor;

namespace ToonyColorsPro
{
	public class Tooltip : EditorWindow
	{
		static bool assemblyReload;
		static Tooltip instance;
		static GUIContent guiContent = new GUIContent();
		static float closeTime;
		const float closeDelay = 0.1f;
		static bool updateEvent;
		static bool isHiding;

		static GUIStyle _style;
		static GUIStyle style
		{
			get
			{
				if (_style == null)
				{
					_style = new GUIStyle(EditorStyles.wordWrappedLabel);
					_style.richText = true;
				}
				return _style;
			}
		}

		public static void Show(Vector2 position, string message)
		{
			Show(position, 250, message);
		}

		public static void Show(Vector2 position, float width, string message)
		{
			if (instance == null)
			{
				var windows = Resources.FindObjectsOfTypeAll<Tooltip>();

				if (windows.Length > 0)
				{
					// destroy any lingering window
					for (int i = 1; i < windows.Length; i++)
					{
						windows[i].Close();
						DestroyImmediate(windows[i]);
					}

					instance = windows[0];
				}
				else
				{
					instance = CreateInstance<Tooltip>();
					instance.minSize = Vector2.zero;
				}
			}


			guiContent.text = message.Replace("  ", "\n");
			float height = style.CalcHeight(guiContent, width) + 4;
			instance.position = new Rect(position.x, position.y, width, height);
			instance.ShowPopup();
			isHiding = false;
		}

		public static void Hide()
		{
			if (!isHiding && instance != null)
			{
				isHiding = true;
				closeTime = Time.realtimeSinceStartup + closeDelay;

				if (!updateEvent)
				{
					EditorApplication.update += applicationUpdate;
					updateEvent = true;
				}
			}
		}

		static void applicationUpdate()
		{
			if (Time.realtimeSinceStartup > closeTime)
			{
				instance.Close();

				EditorApplication.update -= applicationUpdate;
				updateEvent = false;
			}
		}

		void OnGUI()
		{
			// draw background
			EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), new Color(1,1,1,0.1f));

			// draw border
			EditorGUI.DrawRect(new Rect(0, 0, position.width, 1), Color.black);
			EditorGUI.DrawRect(new Rect(0, 0, 1, position.height), Color.black);
			EditorGUI.DrawRect(new Rect(position.width-1, 0, 1, position.height), Color.black);
			EditorGUI.DrawRect(new Rect(0, position.height-1, position.width, 1), Color.black);

			// label
			GUILayout.Label(guiContent, style);
		}
	}
}