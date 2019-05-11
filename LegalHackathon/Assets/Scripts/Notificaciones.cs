using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
     * 
     * Función encargada de notificar al usuario en caso de existir algún mensaje nuevo
     * en un hilo al cuál se haya suscrito previamente
     * 
     */
     public void Notificar (string tema, string hilo)
    {
        NativeToolkit.ClearAllLocalNotifications();

        NativeToolkit.ScheduleLocalNotification("Nuevos comentarios en el tema " + tema,
            "Alguien ha comentado en el siguiente hilo al cuál está suscrito " + hilo);
    }

}
