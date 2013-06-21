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
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;

namespace VpNet.SignalR
{
    [HubName("vphub")]
    public class Vp : ExtendedHub<Vp>
    {
        private static VpNet.Instance _vp;
        private static Timer _t;

        public override void Ping()
        {
            Instance.ClickObject(0);
            Clients.Caller.onPing();
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static VpNet.Instance Instance
        {
            get
            {
                return _vp;
            }

        }

        private static void Wait(object state)
        {
            if (state == null)
            {
                _t.Dispose();
                return;
            }
            ((VpNet.Instance)state).Wait();
        }


        public override System.Threading.Tasks.Task OnDisconnected()
        {
            //TODO: remove all event subscriptions.
            _callerContexts.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            lock (Clients)
            {
                if (Instance == null)
                {
                    var l = 1;
                }
                _callerContexts.Add(Context.ConnectionId, new CallerContext(Clients.Caller));
                return base.OnConnected();
            }
        }

        public void Login(string userName, string password, string botName, string world)
        {
            try
            {
                _vp = new VpNet.Instance();
                _vp.Connect();
                _vp.Login(userName, password, botName);
                _vp.Enter(world);
                _vp.UpdateAvatar();
                _t = new Timer(Wait, Instance, 0, 30);
                Clients.Caller.onLogin();
            }
            catch (VpException ex)
            {
                Clients.Caller.onException(ex);
            }
        }

        public void LogOut()
        {
            _vp.ReleaseEvents();
            if (_vp !=null)
            {
                _vp.Dispose();
            }
                
        }


        public void Say(string message)
        {
            Instance.Say(message);
        }


        public void Boot(string version)
        {
            Clients.Caller.init("0.0.1");
        }

        public void ConsoleMessage(int session, string name, string message, bool isBold, bool isItalic, byte red, byte green, byte blue)
        {
            Instance.ConsoleMessage(session, name, message, 0, red, green, blue);
        }

        public void AvatarClick(int session)
        {
            Instance.AvatarClick(new VpNet.Avatar<VpNet.Vector3>() { Session = session });
        }

        public void TeleportAvatar(int targetSession, string world, float x, float y, float z, float yaw, float pitch)
        {
            Instance.TeleportAvatar(targetSession, world, x, y, z, yaw, pitch);
        }

        public void ChangeObject(VpNet.VpObject<VpNet.Vector3> vpObject)
        {
            Instance.ChangeObject(vpObject);
        }

        public void DeleteObject(int id)
        {
            Instance.DeleteObject(new VpObject<VpNet.Vector3>() { Id = id });
        }

        public void AddObject(VpObject<VpNet.Vector3> vpObject)
        {
            Instance.AddObject(vpObject);
        }
    }
}