using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections;

namespace Bewander
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> userCnxnLookupTable = new Dictionary<string, string>();

        // method for sending a message to all
        public void sendMessage(string senderName, string message)
        {
            Clients.All.displayMessage(senderName, message);
        }

        // method for sending a message to one
        public void sendMessage(string senderName, string message, string targetName)
        {
            if (userCnxnLookupTable.ContainsKey(targetName) == true)
            {
                //look up the current target ConnectionID 
                string targetConxnId = userCnxnLookupTable[targetName].ToString();
                //then send the message to the target, and echo it back to the sender
                Clients.Client(targetConxnId).displayMessage(senderName, message);
                Clients.Caller.displayMessage(senderName, message);
            }
            else
            {
                string error = "DELIVERY FAILED";
                message = targetName + " is not connected.";
                Clients.Caller.displayMessage(error, message);
            }

        }

        //upon connecting, add the user to the lookup table, so senderName can be matched with their ConnectionID
        public void registerConxnId(string userName)
        {
            bool alreadyExists = false;
            if (userCnxnLookupTable.Count == 0)
            {
                userCnxnLookupTable.Add(userName, Context.ConnectionId);
            }
            else
            {
                foreach (string key in userCnxnLookupTable.Keys)
                {
                    if (key == userName)
                    {
                        userCnxnLookupTable[key] = Context.ConnectionId;
                        alreadyExists = true;
                        break;
                    }
                }
                if (!alreadyExists)
                {
                    userCnxnLookupTable.Add(userName, Context.ConnectionId);
                }
            }
        }

    }
}