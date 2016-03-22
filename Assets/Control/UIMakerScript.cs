using UnityEngine;
using UnityEngine.UI;
using System.IO;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;

public class UIMakerScript : MonoBehaviour {

	//http://chikkooos.blogspot.com/2015/03/new-ui-implementation-using-c-scripts.html

	private const int LayerUI = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject CreateCanvas(Transform parent) {
        // create the canvas
        GameObject canvasObject = new GameObject("Canvas");
        canvasObject.layer = LayerUI;

        RectTransform canvasTrans = canvasObject.AddComponent<RectTransform>();
        
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.pixelPerfect = true;

        CanvasScaler canvasScal = canvasObject.AddComponent<CanvasScaler>();
        canvasScal.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScal.referenceResolution = new Vector2(300, 200);
        
        GraphicRaycaster canvasRayc = canvasObject.AddComponent<GraphicRaycaster>();

		//canvasObject.AddComponent<Image> ();

        canvasObject.transform.SetParent(parent);
        
        return canvasObject;
    }

    public GameObject CreateEventSystem(Transform parent) {
        GameObject esObject = new GameObject("EventSystem");

        EventSystem esClass = esObject.AddComponent<EventSystem>();
        esClass.sendNavigationEvents = true;
        esClass.pixelDragThreshold = 5;

        StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule>();
        stdInput.horizontalAxis = "Horizontal";
        stdInput.verticalAxis = "Vertical";

        //TouchInputModule touchInput = esObject.AddComponent<TouchInputModule>();

        esObject.transform.SetParent(parent);

        return esObject;
    }

    public GameObject CreatePanel(Transform parent) {
        GameObject panelObject = new GameObject("Panel");
        panelObject.transform.SetParent(parent);

        panelObject.layer = LayerUI;

        RectTransform trans = panelObject.AddComponent<RectTransform>();
        trans.anchorMin = new Vector2(0, 0);
        trans.anchorMax = new Vector2(1, 1);
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
        trans.anchoredPosition = new Vector2(0, 0);
        trans.offsetMin = new Vector2(0, 0);
        trans.offsetMax = new Vector2(0, 0);
        trans.localPosition = new Vector3(0, 0, 0);
        trans.sizeDelta = new Vector2(0, 0);
        trans.localScale = new Vector3(0.8f, 0.8f, 1.0f);

        CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer>();
        
        Image image = panelObject.AddComponent<Image>();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");

		image.type = Image.Type.Sliced;

		image.color = Color.yellow;

        return panelObject;
    }
    
	public GameObject CreateText(Transform parent,Vector2 position, Vector2 size, string objectName,
		string message, int fontSize) {

        GameObject textObject = new GameObject(objectName);
        textObject.transform.SetParent(parent);

        textObject.layer = LayerUI;

        RectTransform trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta = size;
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = position;
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        trans.localPosition.Set(0, 0, 0);

        CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();
        
        Text text = textObject.AddComponent<Text>();
        text.supportRichText = true;
        text.text = message;
        text.fontSize = fontSize;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.color = new Color(0, 0, 1);

        return textObject;
    }
    
	public GameObject CreateButton(Transform parent, Vector2 position, Vector2 size, string objectName, 
		string message, UnityAction eventListner) {

		GameObject buttonObject = new GameObject(objectName);

        buttonObject.transform.SetParent(parent);

        buttonObject.layer = LayerUI;

        RectTransform trans = buttonObject.AddComponent<RectTransform>();
        SetSize(trans, size);
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = position;
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        trans.localPosition.Set(0, 0, 0);

        CanvasRenderer renderer = buttonObject.AddComponent<CanvasRenderer>();

        Image image = buttonObject.AddComponent<Image>();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/UISprite.psd");

		image.type = Image.Type.Sliced;

        Button button = buttonObject.AddComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(eventListner);

		CreateText(buttonObject.transform, new Vector2(0,0), new Vector2(0,34), "buttonText",
                                                   message, 24);

        return buttonObject;
    }

	public GameObject MakeScaler(Transform parent){
	
		GameObject scalerObject = new GameObject ();

		scalerObject.transform.SetParent (parent);

		scalerObject.layer = LayerUI;

		scalerObject.AddComponent<RectTransform> ();

		scalerObject.AddComponent<Slider> ();

		MakeScalerBackgorund (scalerObject.transform);



		return scalerObject;
	}

	private void MakeScalerBackgorund(Transform parent){

		GameObject scalerBackground = new GameObject ("Background");

		scalerBackground.transform.SetParent (parent);

		RectTransform trans = scalerBackground.AddComponent<RectTransform> ();

		trans.anchorMin = new Vector2 (0.0f,0.25f);
		trans.anchorMax = new Vector2 (0.0f,0.75f);
		trans.pivot = new Vector2 (0.5f,0.5f);

		scalerBackground.AddComponent<CanvasRenderer> ();

		Image image = scalerBackground.AddComponent<Image> ();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
	

	}

    private static void SetSize(RectTransform trans, Vector2 size) {
        Vector2 currSize = trans.rect.size;
        Vector2 sizeDiff = size - currSize;
        trans.offsetMin = trans.offsetMin -
                                  new Vector2(sizeDiff.x * trans.pivot.x,
                                      sizeDiff.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + 
                                  new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
                                      sizeDiff.y * (1.0f - trans.pivot.y));
    }
}
