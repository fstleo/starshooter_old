using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UGUIMenu : MonoBehaviour
{
    [MenuItem("UI/Anchor To Center Object")]
    static void uGUIAnchorToCenterObject()
    {
        var o = Selection.activeGameObject;
        if (o != null && o.GetComponent<RectTransform>() != null)
        {
            var r = o.GetComponent<RectTransform>();
            var p = o.transform.parent.GetComponent<RectTransform>();
            Vector2 size = r.sizeDelta;
            var offsetMin = r.offsetMin;
            var offsetMax = r.offsetMax;
            var _anchorMin = r.anchorMin;
            var _anchorMax = r.anchorMax;

            var parent_width = p.rect.width;
            var parent_height = p.rect.height;

            var anchorMin = new Vector2(_anchorMin.x + (offsetMin.x / parent_width),
                                        _anchorMin.y + (offsetMin.y / parent_height));
            var anchorMax = new Vector2(_anchorMax.x + (offsetMax.x / parent_width),
                                        _anchorMax.y + (offsetMax.y / parent_height));

            r.anchorMin = (anchorMin + anchorMax)/2;
            r.anchorMax = r.anchorMin;
            r.sizeDelta = size;
            //r.offsetMin = new Vector2(0, 0);
            //r.offsetMax = size;
            r.pivot = new Vector2(0.5f, 0.5f);

        }
    }

    [MenuItem("UI/Unmark raycast target")]
    static void uGUIUnmarkRaycast()
    {
        var o = Selection.activeGameObject;
        if (o != null && o.GetComponent<RectTransform>() != null)
        {
            var r = o.GetComponent<RectTransform>();
            var p = o.transform.parent.GetComponent<RectTransform>();

            var childrens = o.GetComponentsInChildren<Graphic>();
            foreach (Graphic c in childrens)
                c.raycastTarget = false;

        }
    }

    [MenuItem("UI/Anchor Around Object")]
    static void uGUIAnchorAroundObject()
    {
        var o = Selection.activeGameObject;
        if (o != null && o.GetComponent<RectTransform>() != null)
        {
            var r = o.GetComponent<RectTransform>();
            var p = o.transform.parent.GetComponent<RectTransform>();

            var offsetMin = r.offsetMin;
            var offsetMax = r.offsetMax;
            var _anchorMin = r.anchorMin;
            var _anchorMax = r.anchorMax;

            var parent_width = p.rect.width;
            var parent_height = p.rect.height;

            var anchorMin = new Vector2(_anchorMin.x + (offsetMin.x / parent_width),
                                        _anchorMin.y + (offsetMin.y / parent_height));
            var anchorMax = new Vector2(_anchorMax.x + (offsetMax.x / parent_width),
                                        _anchorMax.y + (offsetMax.y / parent_height));

            r.anchorMin = anchorMin;
            r.anchorMax = anchorMax;

            r.offsetMin = new Vector2(0, 0);
            r.offsetMax = new Vector2(1, 1);
            r.pivot = new Vector2(0.5f, 0.5f);

        }
    }

    [MenuItem("UI/Anchor Object With Center X")]
    static void uGUIAnchorObjectX()
    {
        var o = Selection.activeGameObject;
        if (o != null && o.GetComponent<RectTransform>() != null)
        {
            var r = o.GetComponent<RectTransform>();
            var p = o.transform.parent.GetComponent<RectTransform>();

            var offsetMin = r.offsetMin;
            var offsetMax = r.offsetMax;
            var _anchorMin = r.anchorMin;
            var _anchorMax = r.anchorMax;

            var parent_width = p.rect.width;
            var parent_height = p.rect.height;

            var anchorMin = new Vector2((_anchorMin.x + (offsetMin.x / parent_width) + _anchorMax.x + (offsetMax.x / parent_width)) / 2,
                                        _anchorMin.y + (offsetMin.y / parent_height));
            var anchorMax = new Vector2((_anchorMin.x + (offsetMin.x / parent_width) + _anchorMax.x + (offsetMax.x / parent_width)) / 2,
                                        _anchorMax.y + (offsetMax.y / parent_height));

            r.anchorMin = anchorMin;
            r.anchorMax = anchorMax;

            r.offsetMin = new Vector2(0, 0);
            r.offsetMax = new Vector2(1, 1);
            r.pivot = new Vector2(0.5f, 0.5f);

        }
    }


    [MenuItem("UI/Anchor Object With Center Y")]
    static void uGUIAnchorObjectY()
    {
        var o = Selection.activeGameObject;
        if (o != null && o.GetComponent<RectTransform>() != null)
        {
            var r = o.GetComponent<RectTransform>();
            var p = o.transform.parent.GetComponent<RectTransform>();

            var offsetMin = r.offsetMin;
            var offsetMax = r.offsetMax;
            var _anchorMin = r.anchorMin;
            var _anchorMax = r.anchorMax;

            var parent_width = p.rect.width;
            var parent_height = p.rect.height;

            var anchorMin = new Vector2(_anchorMin.x + (offsetMin.x / parent_width),
                                        (_anchorMin.y + (offsetMin.y / parent_height) + _anchorMax.y + (offsetMax.y / parent_height)) / 2);
            var anchorMax = new Vector2(_anchorMax.x + (offsetMax.x / parent_width),
                                        (_anchorMin.y + (offsetMin.y / parent_height) + _anchorMax.y + (offsetMax.y / parent_height)) / 2);

            r.anchorMin = anchorMin;
            r.anchorMax = anchorMax;

            r.offsetMin = new Vector2(0, 0);
            r.offsetMax = new Vector2(1, 1);
            r.pivot = new Vector2(0.5f, 0.5f);

        }
    }
}