using UnityEngine;
using System.Collections;

public class depth : MonoBehaviour
{
	// the KinectManager instance
	private KinectManager manager;
	//private KinectWrapper 
	// the foreground texture
	private Texture2D foregroundTex;

	// rectangle taken by the foreground texture (in pixels)
	private Rect foregroundRect;
	private Vector2 foregroundOfs;
	private ushort[] usersDepthMap;
	private int usersMapSize = KinectWrapper.GetDepthWidth() * KinectWrapper.GetDepthHeight();

	void Start()
	{
		// calculate the foreground rectangle
		Rect cameraRect = Camera.main.pixelRect;
		float rectHeight = cameraRect.height;
		float rectWidth = cameraRect.width;

		if (rectWidth > rectHeight)
			rectWidth = rectHeight * KinectWrapper.Constants.DepthImageWidth / KinectWrapper.Constants.DepthImageHeight;
		else
			rectHeight = rectWidth * KinectWrapper.Constants.DepthImageHeight / KinectWrapper.Constants.DepthImageWidth;

		foregroundOfs = new Vector2((cameraRect.width - rectWidth) / 2, (cameraRect.height - rectHeight) / 2);
		foregroundRect = new Rect(foregroundOfs.x, cameraRect.height - foregroundOfs.y, rectWidth, -rectHeight);
	}

	void Update()
	{
		if (manager == null)
		{
			manager = KinectManager.Instance;
		}

		// get the users texture
		if (manager && manager.IsInitialized())
		{
			foregroundTex = manager.GetUsersLblTex();

		}

		if (manager.IsUserDetected())
		{
			uint userId = manager.GetPlayer1ID();
			
			//userTex = new Texture2D(KinectWrapper.GetDepthWidth(), KinectWrapper.GetDepthHeight());
		}
		//int jointsCount = (int)KinectWrapper.NuiSkeletonPositionIndex.Count;

		//for (int i = 0; i < jointsCount; i++)
		//{
		//	int parent = KinectWrapper.GetSkeletonJointParent(i);

	}

	void OnGUI()
	{
		if (foregroundTex)
		{
			GUI.DrawTexture(foregroundRect, foregroundTex);
			//GUI.DrawTexture(foregroundRect, userTex);
		}
	}

}
