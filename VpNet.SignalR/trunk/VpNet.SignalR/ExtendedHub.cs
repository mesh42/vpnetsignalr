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

    This file is part of VPNET JQuery Version 0.0.1

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
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

namespace VpNet.SignalR
{
    public abstract class ExtendedHub<THub> : Hub
    {
        public static Dictionary<string, CallerContext> _callerContexts = new Dictionary<string, CallerContext>();


        public abstract void Ping();

        public void Subscribe(string args)
        {
                System.Diagnostics.Debug.WriteLine("subscribe");
            _callerContexts[Context.ConnectionId].Subscribe(args);
        }

        public void Unsubscribe(string args)
        {
                    System.Diagnostics.Debug.WriteLine("Unsubscribe");
            _callerContexts[Context.ConnectionId].Unsubscribe(args);
        }


        private CallerContext ClientContext()
        {
            return _callerContexts[Context.ConnectionId];
        }
    }
}