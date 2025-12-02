using Il2CppScheduleOne.Interaction;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using System;
namespace simple_modding
{
    public class Class1:MelonPlugin
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Simple Modding Loaded");
        }
        internal class Interaction : MelonPlugin
        {
            public static void New_interaction(string Gameobject, string message, Action InteractedWith)
            {
                GameObject gameobject;
                InteractableObject gameobjectInteraction;
                gameobject = GameObject.Find(Gameobject);
                gameobjectInteraction = gameobject.AddComponent<InteractableObject>();
                gameobjectInteraction.message = message;
                gameobjectInteraction.interactionState = InteractableObject.EInteractableState.Default;
                void CallInteraction() => InteractedWith();
                gameobjectInteraction.onInteractStart.AddListener((UnityAction)CallInteraction);
            }
            public static void New_label(string Gameobject, string message)
            {
                GameObject gameobject;
                InteractableObject gameobjectInteraction;
                gameobject = GameObject.Find(Gameobject);
                gameobjectInteraction = gameobject.AddComponent<InteractableObject>();
                gameobjectInteraction.message = message;
                gameobjectInteraction.interactionState = InteractableObject.EInteractableState.Label;
            }
        }
    }
}
