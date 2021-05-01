using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public static class EventHelpers
    {
        public static void RaiseEvent(Object objectRaisingEvent,
                                      EventHandler<AccessTypeEventArgs> eventHandlerRaised,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            if (eventHandlerRaised != null) //Check if any subscribed to this event
            {
                eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); //Notify all subscribers
            }
        }

        //HelpAbout deve chamar esse evento.
        public static void RaiseEvent(Object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs)
        {
            if (eventHandlerRaised != null)//Check if any subscribed to this event
            {
                eventHandlerRaised(objectRaisingEvent, eventArgs);//Notify all subcribers
            }
        }
    }
}
