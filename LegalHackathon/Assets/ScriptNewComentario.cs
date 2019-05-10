using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptNewComentario : MonoBehaviour
{
    public InputField textComentario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnviamosComentarioHilo()
    {
        /*
         * Aqui llamaremos al script backend, para enviar el mensaje y añadirlo al hilo
         * 
         * */
    }

    public void BorrarTodoComentario()
    {
        textComentario.text = "";
    }


}
