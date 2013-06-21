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
(function vp($) {
    // client/Server hub connection entry points.
    var clientVersion = "0.0.1";
    var c = $.connection.vphub.client;
    var s = $.connection.vphub.server;

    // client/server event declarations for vp instance.
    // for args argument objects, please look at the technical documentation of the VPNET SDK the objects are
    // serialized transparantly to JSON and exposed as Javascript objects.
    c.onException = function (args) { $.vp.onException(args); };
    c.onLogin = function (args) { $.vp.onLogin(args); };
    c.onAvatarEnter = function (args) { $.vp.onAvatarEnter(args); };
    c.onAvatarChange = function (args) { $.vp.onAvatarChange(args); };
    c.onAvatarLeave = function (args) { $.vp.onAvatarLeave(args); };
    c.onChatMessage = function (args) { $.vp.onChatMessage(args); };
    c.onWorldSettingsChanged = function (args) { $.vp.onWorldSettingsChanged(args); };
    c.onWorldList = function (args) { $.vp.onWorldList(args); };
    c.onWorldDisconnect = function (args) { $.vp.onWorldDisconnect(args); };
    c.onUniverseDisconnect = function (args) { $.vp.onUniverseDisconnect(args); };
    c.onTeleport = function (args) { $.vp.onTeleport(args); };
    c.onQueryResult = function (args) { $.vp.onQueryResult(args); };
    c.onObjectDeleteCallback = function (args) { $.vp.onObjectDeleteCallback(args); };
    c.onObjectDelete = function (args) { $.vp.onObjectDelete(args); };
    c.onQueryCellEnd = function (args) { $.vp.onQueryCellEnd(args); };
    c.onObjectCreateCallback = function (args) { $.vp.onObjectCreateCallback(args); };
    c.onObjectCreate = function (args) { $.vp.onObjectCreate(args); };
    c.onObjectClick = function (args) { $.vp.onObjectClick(args); };
    c.onObjectChangeCallback = function (args) { $.vp.onObjectChangeCallback(args); };
    c.onObjectChange = function (args) { $.vp.onObjectChange(args); };
    c.onPing = function (args) { $.vp.onPing(args); };

    c.init = function () { $.vp.initialize(); };

    c.initialize = function (args) { };

    $.vp = {
        onLogin: function (args) { },
        onException: function (args) { },
        onAvatarEnter: function (args) { },
        onAvatarLeave: function (args) { },
        onAvatarChange: function (args) { },
        onChatMessage: function (args) { },
        onWorldSettingsChanged: function (args) { },
        onWorldList: function (args) { },
        onWorldDisconnect: function (args) { },
        onUniverseDisconnect: function (args) { },
        onTeleport: function (args) { },
        onQueryResult: function (args) { },
        onObjectDeleteCallback: function (args) { },
        onObjectDelete: function (args) { },
        onQueryCellEnd: function (args) { },
        onObjectCreateCallback: function (args) { },
        onObjectCreate: function (args) { },
        onObjectClick: function (args) { },
        onObjectChangeCallback: function (args) { },
        onObjectChange: function (args) { },

        // Network specific implementation.
        onPing: function (args) { },
        ping: function () {
            s.ping();
        },

        login: function (userName, password, botName, world) {
            s.login(userName, password, botName, world);
        },

        logout: function () {
            s.logOut();
        },

        init: function (args) {
            s.boot(args);
        },

        subscribe: function (event) {
            s.subscribe(event);
        },
        unsubscribe: function (event) {
            s.unsubscribe(event);
        },
        say: function (event) {
            s.say(event);
        },
        save: function (d) {
            s.store(d);
        },
        consoleMessage: function (session, name, message, isBold, isItalic, red, green, blue) {
            s.consoleMessage(session, name, message, isBold, isItalic, red, green, blue);
        },
        avatarClick: function (session) {
            s.avatarClick(session);
        },
        teleportAvatar: function (targetSession, world, x, y, z, yaw, pitch) {
            s.teleportAvatar(targetSession, world, x, y, z, yaw, pitch);
        },
        changeObject: function (vpObject) {
            s.changeObject(vpObject);
        },
        deleteObject: function (id) {
            s.deleteObject(id);
        },
        addObject: function (vpObject) {
            s.addObject(vpObject);
        },
        queryCell: function (cellX, cellZ) {
            s.queryCell(cellX, cellZ);
        },
        initialize: function () {
            alert('you need to implement your initialize function in your bot.');
        },
    };
})(jQuery);