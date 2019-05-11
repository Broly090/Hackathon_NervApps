using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPrefabRepuesta : MonoBehaviour
{
    public Text numcolegiadoAnt;
    public Text comentarioAnterio;

    public Text _miNumColegiado;
    public Text _miRespuesta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RellenarPrefab(string numAnte, string comentarioAnte, string miNum, string miRespuesta)
    {
        numcolegiadoAnt.text = numAnte;
        comentarioAnterio.text = comentarioAnte;
        _miNumColegiado.text = miNum;
        _miRespuesta.text = miRespuesta;
    }
}
