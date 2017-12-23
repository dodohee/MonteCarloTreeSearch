﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloLib.Models
{
    public   class Player
    { 

        public NodeAction LastAction { set; get; }

        public bool TakeAction(Node node, NodeAction action)
        {

            if (action == null)
                return true;
            LastAction = action;
            node.AvalableActions.Remove(action);
            return action.Terminal;  
        }


    }
}
