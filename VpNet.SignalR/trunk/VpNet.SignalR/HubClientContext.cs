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
using System;
using System.Collections.Generic;
using System.Reflection;

namespace VpNet.SignalR
{
    public abstract class HubClientContext<T>
    {
        internal Dictionary<string, Delegate> _delegate = new Dictionary<string, Delegate>();

        internal readonly dynamic _caller;

        protected HubClientContext(object caller)
        {
            _caller = caller;

        }

        public abstract void Ping();


        public void Subscribe(string args)
        {
            lock (this)
            {

                MethodInfo method = typeof(T).GetMethod
                    (args, BindingFlags.Public | BindingFlags.Instance);
                // Subscribe to the event
                EventInfo eventInfo = typeof(Instance).GetEvent(args);
                Type type = eventInfo.EventHandlerType;
                Delegate handler = Delegate.CreateDelegate(type, this, method);
                MethodInfo addHandler = eventInfo.GetAddMethod();
                Object[] addHandlerArgs = { handler };
                _delegate[args] = (Delegate)addHandler.Invoke(Vp.Instance, addHandlerArgs);
            }
        }

        public void Unsubscribe(string args)
        {
            lock (this)
            {
                if (_delegate.ContainsKey(args))
                {
                    MethodInfo method = typeof(T).GetMethod
                        (args, BindingFlags.Public | BindingFlags.Instance);
                    // Subscribe to the event
                    EventInfo eventInfo = typeof(Instance).GetEvent(args);
                    Type type = eventInfo.EventHandlerType;
                    Delegate handler = Delegate.CreateDelegate(type, this, method);
                    MethodInfo addHandler = eventInfo.GetRemoveMethod();
                    Object[] addHandlerArgs = { handler };
                    var l = addHandler.Invoke(Vp.Instance, addHandlerArgs);
                    _delegate.Remove(args);
                }
            }
        }
    }
}