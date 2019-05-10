using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackEnd : MonoBehaviour
{

    private string tema, hilo, url, conversacion;
    private TextAsset conversacionText;

    // Start is called before the first frame update
    void Start()
    {
        RecogerHilo("Penal", "Art.245.2CP");



        //RecogerHilo("Penal", "Art.245.2CP");


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /*
     * 
     * Función encargada de completar la URL y lanzar Corrutina
     * 
     * 
     * */
    public void RecogerHilo (string tema, string hilo)
    {

        url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/" + hilo + ".txt";

        StartCoroutine(CorrutinaRecogerHilo());

    }


    /*
     * 
     * Función encargada de recoger hilos (conversaciones) desde servidor
     * 
     * 
     * */
    IEnumerator CorrutinaRecogerHilo ()
    {
        using (var www = new WWW(url))
        {
            yield return www;

            conversacion = System.Text.Encoding.UTF7.GetString(www.bytes);

        }

        Debug.Log(conversacion);

        EnviarHilo("Penal", "Art.245.2CP");
    }


    /*
  * 
  * Función encargada de completar la URL y lanzar Corrutina
  * 
  * 
  * */
    public void EnviarHilo(string tema, string hilo)
    {

        //url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/" + hilo + ".txt";
        //url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/write.php";
        url = "http://46.183.118.202:6969/Legalhackathon/write.php";

        conversacion += "\n Hola vengo a flotar bueno chau";
        Debug.Log(url);
        StartCoroutine(CorrutinaEnviarHilo());

    }



    /*
     * 
     * Función encargada de enviar hilos (conversaciones) al servidor
     * 
     * 
     * */
    IEnumerator CorrutinaEnviarHilo()
    {
        Debug.Log(conversacion);
        /*
        WWWForm form = new WWWForm();



        form.AddField("fileContent", conversacion);
        form.AddField("fileName", hilo + ".txt");
        */

        WWW www = new WWW(url+"?txt="+conversacion+"?file="+hilo+".txt");
        //WWW www = new WWW(url + "?txt=" + conversacion);
        yield return www;


        /*
        //UnityWebRequest www = new UnityWebRequest(url, conversacion);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(conversacion));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Error" + www.error);
            }
            else if (www.isDone)
            {
                Debug.Log("Bien" + www.error);
            }

        }*/

        /*
        using (var www = new UnityEngine.Networking.UnityWebRequest(url, conversacion))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("Error" + www.error);
            }
            else
            {
                Debug.Log(www);
            }
        }*/




    }




}
