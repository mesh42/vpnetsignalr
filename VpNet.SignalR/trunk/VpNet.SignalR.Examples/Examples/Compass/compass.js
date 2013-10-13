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
/// <reference path="~/Scripts/jquery-1.9.1.min.js" />
/// <reference path="jquery.signalr-1.1.2.min.js" />
/// <reference path="../../VpNet.SignalR/Scripts/jquery.signalR.vpnet-0.0.1.js" />
// Overide this function for your bot entry point.
$.vp.initialize = function () {
    // vp initialized. now we can enable to login function and exception handling.
    $.vp.onException = function (args) { onException(args); };
    init();
    $.vp.onAvatarChange = function (args) { updateCompass(args); };
    $.vp.subscribe("OnAvatarChange");

    function onException(args) {
        alert("RC Error" + args.Message);
    }
    
    function updateCompass(args) {
        clearCanvas();
        // Draw the compass onto the canvas
        ctx.drawImage(img, 0, 0);
        // Save the current drawing state
        ctx.save();
        // Now move across and down half the 
        ctx.translate(100, 100);
        // Rotate around this point
        ctx.rotate(degrees * (Math.PI / 180));
        // Draw the image back and up
        ctx.drawImage(needle, -100, -100);
        // Restore the previous drawing state
        ctx.restore();
        // Increment the angle of the needle by 5 degrees
        degrees = args.Avatar.Rotation.split(',')[1];

    }
};

// Global variable
var img = null,
	needle = null,
	ctx = null,
	degrees = 0;

function init() {
    // Grab the compass element
    var canvas = document.getElementById('compass');

    // Canvas supported?
    if (canvas.getContext('2d')) {
        ctx = canvas.getContext('2d');

        // Load the needle image
        needle = new Image();
        needle.src = 'needle.png';

        // Load the compass image
        img = new Image();
        img.src = 'compass.png';
        img.onload = imgLoaded;
    }
    else {
        alert("Canvas not supported!");
    }

}

function clearCanvas() {
    // clear canvas
    ctx.clearRect(0, 0, 200, 200);
}

function imgLoaded() {
    // Image loaded event complete.  Start the timer
    // setInterval(draw, 100);
    //draw();
}

