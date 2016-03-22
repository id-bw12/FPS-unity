using UnityEngine;
using UnityEngine.UI;
using System.IO;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;

public class UIMakerScript : MonoBehaviour {

	//http://chikkooos.blogspot.com/2015/03/new-ui-implementation-using-c-scripts.html

	private const int LayerUI = 5;

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
        
        canvasObject.AddComponent<GraphicRaycaster>();

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

        panelObject.AddComponent<CanvasRenderer>();
        
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

        textObject.AddComponent<CanvasRenderer>();
        
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

        buttonObject.AddComponent<CanvasRenderer>();

        Image image = buttonObject.AddComponent<Image>();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/UISprite.psd");

		image.type = Image.Type.Sliced;

        Button button = buttonObject.AddComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(eventListner);

		CreateText(buttonObject.transform, new Vector2(0,0), size, "buttonText",
                                                   message, 16);

        return buttonObject;
    }

	public GameObject CreateScaler(Transform parent, Vector2 position){
	
		GameObject scalerObject = new GameObject ("Slider");

        var background = MakeScalerBackgorund(scalerObject.transform);
        var fillArea = MakeFillArea(scalerObject.transform);
        var fill = MakeFill(fillArea.transform);
        var slideArea = MakeHandleSlideArea(scalerObject.transform);
        var handle = MakeHandle(slideArea.transform);

        scalerObject.transform.SetParent (parent);

		scalerObject.layer = LayerUI;

		RectTransform rect = scalerObject.AddComponent<RectTransform> ();
        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(160,20);
        rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Image handleImage = handle.GetComponent<Image>();

        Slider slider = scalerObject.AddComponent<Slider> ();

        slider.fillRect = fill.GetComponentInChildren<RectTransform>();
        slider.handleRect = handle.GetComponent<RectTransform>();
        slider.targetGraphic = handleImage;
        slider.direction = Slider.Direction.LeftToRight;

		return scalerObject;
	}

	private GameObject MakeScalerBackgorund(Transform parent){

		GameObject scalerBackground = new GameObject ("Background");

		scalerBackground.transform.SetParent (parent);

        scalerBackground.layer = LayerUI;

		RectTransform trans = scalerBackground.AddComponent<RectTransform> ();

        trans.anchoredPosition = new Vector3(0.0f, 0.0f);
        trans.sizeDelta = new Vector2(0.0f, 0.0f);
		trans.anchorMin = new Vector2 (0.0f,0.25f);
		trans.anchorMax = new Vector2 (1.0f,0.75f);
		trans.pivot = new Vector2 (0.5f,0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        scalerBackground.AddComponent<CanvasRenderer> ();

		Image image = scalerBackground.AddComponent<Image> ();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");

        image.type = Image.Type.Sliced;

        return scalerBackground;
	}

    private GameObject MakeFillArea(Transform parent) {

        GameObject areaObject = new GameObject("Fill Area");

        areaObject.transform.SetParent(parent);

        areaObject.layer = LayerUI;

        RectTransform trans = areaObject.AddComponent<RectTransform>();
        trans.offsetMin = new Vector2(5, 0);
        trans.offsetMax = new Vector2(-15, 0);
        //trans.anchoredPosition = new Vector3(5.0f, 0.0f,0.0f);

        trans.anchorMin = new Vector2(0.0f, 0.25f);
        trans.anchorMax = new Vector2(1.0f, 0.75f);
        trans.pivot = new Vector2(0.5f, 0.5f);

        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        

        return areaObject;

    }

    private GameObject MakeFill(Transform parent) {

        GameObject fillObject = new GameObject("Fill");

        fillObject.transform.SetParent(parent);

        fillObject.layer = LayerUI;

        var trans = fillObject.AddComponent<RectTransform>();

        trans.localPosition = new Vector2(0.0f,0.0f);
        trans.sizeDelta = new Vector2(10, 0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(0.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        fillObject.AddComponent<CanvasRenderer>();

        var image = fillObject.AddComponent<Image>();

        image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

        image.type = Image.Type.Sliced;

        return fillObject;

    }

    private GameObject MakeHandleSlideArea(Transform parent) {

        GameObject slideArea = new GameObject("Handle Slide Area");

        slideArea.transform.SetParent(parent);

        slideArea.layer = LayerUI;

        RectTransform trans = slideArea.AddComponent<RectTransform>();

        trans.offsetMin = new Vector2(10, 0);
        trans.offsetMax = new Vector2(-10, 0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(1.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f,1.0f);
        //trans.right = new Vector3(15.0f, 0.0f, 0.0f);

        //MakeHandle(slideArea.transform);

        return slideArea;
    }

    private GameObject MakeHandle(Transform parent) {

        GameObject handleObject = new GameObject("Handle");

        handleObject.transform.parent = parent;

        handleObject.layer = LayerUI;

        var trans = handleObject.AddComponent<RectTransform>();

        trans.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
        trans.sizeDelta = new Vector2(20,0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(0.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        handleObject.AddComponent<CanvasRenderer>();

        var image = handleObject.AddComponent<Image>();

        image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");

        image.type = Image.Type.Simple;

        return handleObject;
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
