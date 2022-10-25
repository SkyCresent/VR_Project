using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SH
{
    public abstract class Interactionable : ItemComponent, IInteraction
    {        
        protected void Awake()
        {
            base.Init(ItemOption.INTERACTION);
        }

        public abstract void Interaction();

        public abstract void UnInteraction();

        public abstract bool InteractionUpdate();
    }
}
