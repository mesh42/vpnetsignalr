/**@license
____   ___.__         __               .__    __________                        .__.__                
\   \ /   |__________/  |_ __ _______  |  |   \______   _____ ____________    __| _|__| ______ ____   
 \   Y   /|  \_  __ \   __|  |  \__  \ |  |    |     ___\__  \\_  __ \__  \  / __ ||  |/  ____/ __ \  
  \     / |  ||  | \/|  | |  |  // __ \|  |__  |    |    / __ \|  | \// __ \/ /_/ ||  |\___ \\  ___/  
   \___/  |__||__|   |__| |____/(____  |____/  |____|   (____  |__|  (____  \____ ||__/____  >\___  > 
                                     \/                      \/           \/     \/        \/     \/  
 _______ __                   __ ______                
|     __|__.-----.-----.---.-|  |   __ \
|__     |  |  _  |     |  _  |  |      < 
|_______|__|___  |__|__|___._|__|___|__|    
           |_____|                                                              

    This file is part of VPNET SignalR Version 0.0.1

    Copyright (c) 2012-2013 CUBE3 (Cit:36)

    VPNET is free software: you can redistribute it and/or modify it under the terms of the 
    GNU Lesser General Public License (LGPL) as published by the Free Software Foundation, either
    version 2.1 of the License, or (at your option) any later version.

    VPNET is distributed in the hope that it will be useful,but WITHOUT ANY WARRANTY; without even
    the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the LGPL License
    for more details.

    You should have received a copy of the GNU Lesser General Public License (LGPL) along with VPNET.
    If not, see <http://www.gnu.org/licenses/>. 
*/
/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jquery.signalr-1.1.2.min.js" />
/// <reference path="../../VpNet.SignalR/Scripts/jquery.signalR.vpnet-0.0.1.js" />
// Overide this function for your bot entry point.
$.vp.initialize = function() {
    // vp initialized. now we can enable to login function and exception handling.
    $.vp.onException = function(args) { onException(args); };
    $("#loginForm").dialog("open");
    $("#cmdLogin").bind("click", function() {
        $.vp.login($("#txtLoginName").val(), $("#txtLoginPassword").val(), $("#txtLoginBotName").val(), $("#txtLoginWorld").val());
    });
    
    function onException(args) {
        alert("RC Error" + args.Message);
    }
    
    $.vp.onLogin = function(args) {
        $("#loginForm").dialog("close");
        $("#events").dialog("open");
        // overide event callbacks from the hub so we can handle them in our own bot.
        $.vp.onAvatarEnter = function(args) { displayEvent("OnAvatarEnter", args); };
        $.vp.onAvatarLeave = function(args) { displayEvent("OnAvatarLeave", args); };
        $.vp.onObjectClick = function(args) { displayEvent("OnObjectClick", args); };
        $.vp.onObjectChange = function(args) { displayEvent("OnObjectChange", args); };
        $.vp.onObjectCreate = function(args) { displayEvent("OnObjectCreate", args); };
        $.vp.onChatMessage = function(args) { displayEvent("OnChatMessage", args); };

        // now subscribe to some vp instance events. Note that the event names are the same as VPNET SDK.
        $.vp.subscribe("OnAvatarEnter");
        $.vp.subscribe("OnAvatarLeave");
        $.vp.subscribe("OnObjectClick");
        $.vp.subscribe("OnObjectChange");
        $.vp.subscribe("OnObjectCreate");
        $.vp.subscribe("OnChatMessage");

        // create a generic event viewer, showing the events in plain json format.

        function displayEvent(event, args) {
            $("#events").append(event + ": " + JSON.stringify(args) + "<br>");
            $("#events").scrollTop($("#events")[0].scrollHeight);
        }
    };
};