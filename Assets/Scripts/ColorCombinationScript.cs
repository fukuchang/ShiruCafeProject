using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCombinationScript : MonoBehaviour {

    public float m_preCutoff = 10f;
    float m_cutoff;

    private Color[] m_SetColor = new Color[6]; //rgbがカラーセンサから送られてくる基本値(Awake関数で初期設定)
    private Color[] m_LantanumColor = new Color[6];
    private Gradient[] m_grad = new Gradient[6];

	// Use this for initialization
	void Awake () {
        m_cutoff = m_preCutoff / 255f;
        for (int i = 0; i < 6; i++){
            m_grad[i] = new Gradient();
            switch(i)
            {
                case 0: //red
                    m_LantanumColor[i] = new Vector4(226f / 255f, 3f / 255f, 3f / 255f, 1f);
                    m_SetColor[i] = new Vector4(165f / 255f, 48f / 255f, 47f / 255f, 1f);
                    break;
                case 1: //blue
                    m_LantanumColor[i] = new Vector4(0f, 0f, 1f, 1f);
                    m_SetColor[i] = new Vector4(52f / 255f, 86f / 255f, 113f / 255f, 1f);
                    break;
                case 2: //pink
                    m_LantanumColor[i] = new Vector4(1f, 0f, 182f / 255f, 1f);
                    m_SetColor[i] = new Vector4(106f / 255f, 66f / 255f, 82f / 255f, 1f);
                    break;
                case 3: //orange
                    m_LantanumColor[i] = new Vector4(1f, 117f / 255f, 0f, 1f);
                    m_SetColor[i] = new Vector4(140f / 255f, 67f / 255f, 40f / 255f, 1f);
                    break;
                case 4: //green
                    m_LantanumColor[i] = new Vector4(0f, 1f, 0f, 1f);
                    m_SetColor[i] = new Vector4(55f / 255f, 114f / 255f, 75f / 255f, 1f);
                    break;
                default: //yellow
                    m_LantanumColor[i] = new Vector4(1f, 1f, 0f, 1f);
                    m_SetColor[i] = new Vector4(80f / 255f, 89f / 255f, 77f / 255f, 1f);
                    break; 
            }
            m_grad[i].SetKeys(new GradientColorKey[] { new GradientColorKey(m_LantanumColor[i], 1f) },
                   new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) });
            Debug.Log("Color[" + i.ToString() + "]:" + m_SetColor[i]);
        }

	}

    public Gradient getGradient(Color color){
        for (int i = 0; i < 5; i++)
        {
            if (((m_SetColor[i].r - m_cutoff) <= color.r) && ((m_SetColor[i].r + m_cutoff) >= color.r))
            {
                if (((m_SetColor[i].g - m_cutoff) <= color.g) && ((m_SetColor[i].g + m_cutoff) >= color.g))
                {
                    if (((m_SetColor[i].b - m_cutoff) <= color.b) && ((m_SetColor[i].b + m_cutoff) >= color.b))
                    {
                        return m_grad[i];
                    }
                }
            }
        }
        return m_grad[5];
    }

    public Color getColor(Color color){
        for (int i = 0; i < 5; i++)
        {
            if (((m_SetColor[i].r - m_cutoff) <= color.r) && ((m_SetColor[i].r + m_cutoff) >= color.r))
            {
                if (((m_SetColor[i].g - m_cutoff) <= color.g) && ((m_SetColor[i].g + m_cutoff) >= color.g))
                {
                    if (((m_SetColor[i].b - m_cutoff) <= color.b) && ((m_SetColor[i].b + m_cutoff) >= color.b))
                    {
                        return m_LantanumColor[i];
                    }
                }
            }
        }
        return m_LantanumColor[5];
    }
}
