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
namespace VpNet.SignalR
{
    public class CallerContext : HubClientContext<CallerContext>
    {

        public CallerContext(object caller)
            : base(caller)
        {

        }

        public void OnPing()
        {
            _caller.Ping();
        }

        #region event handler proxy

        public void OnAvatarEnter(VpNet.Instance sender, AvatarEnterEventArgsT<Avatar<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onAvatarEnter(args);
        }

        public void OnChatMessage(VpNet.Instance sender, ChatMessageEventArgsT<Avatar<VpNet.Vector3>, ChatMessage, VpNet.Vector3, VpNet.Color> args)
        {
            _caller.onChatMessage(args);
        }

        public void OnAvatarLeave(VpNet.Instance sender, AvatarLeaveEventArgsT<Avatar<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onAvatarLeave(args);
        }

        public void OnAvatarChange(VpNet.Instance sender, AvatarChangeEventArgsT<Avatar<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onAvatarChange(args);

        }

        public void OnWorldSettingsChanged(VpNet.Instance sender, WorldSettingsChangedEventArgs args)
        {
            _caller.onWorldSettingsChanged(args);
        }

        public void OnWorldList(VpNet.Instance sender, WorldListEventArgs args)
        {
            _caller.onWorldList(args);
        }

        public void OnWorldDisconnect(VpNet.Instance sender, WorldDisconnectEventArgs args)
        {
            _caller.onWorldDisconnect(args);
        }

        public void OnUniverseDisconnect(VpNet.Instance sender, UniverseDisconnectEventArgs args)
        {
            _caller.onUniverseDisconnect(args);
        }

        public void OnTeleport(VpNet.Instance sender, TeleportEventArgsT<Teleport<World, Avatar<VpNet.Vector3>, VpNet.Vector3>, World, Avatar<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onTeleport(args);
        }

        public void OnQueryCellResult(VpNet.Instance sender, QueryCellResultArgsT<VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onQueryResult(args);
        }

        public void OnObjectDeleteCallback(VpNet.Instance sender, ObjectDeleteCallbackArgsT<RcDefault, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectDeleteCallback(args);
        }

        public void OnObjectDelete(VpNet.Instance sender, ObjectDeleteArgsT<Avatar<VpNet.Vector3>, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectDelete(args);
        }

        public void OnQueryCellEnd(VpNet.Instance sender, QueryCellEndArgs args)
        {
            _caller.onQueryCellEnd(args);
        }

        public void OnObjectCreateCallback(VpNet.Instance sender, ObjectCreateCallbackArgsT<RcDefault, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectCreateCallback(args);
        }

        public void OnObjectCreate(VpNet.Instance sender, ObjectCreateArgsT<Avatar<VpNet.Vector3>, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectCreate(args);
        }

        public void OnObjectClick(VpNet.Instance sender, ObjectClickArgsT<Avatar<VpNet.Vector3>, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectClick(args);
        }

        public void OnObjectChangeCallback(VpNet.Instance sender, ObjectChangeCallbackArgsT<RcDefault, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectChangeCallback(args);
        }

        public void OnObjectChange(VpNet.Instance sender, ObjectChangeArgsT<Avatar<VpNet.Vector3>, VpObject<VpNet.Vector3>, VpNet.Vector3> args)
        {
            _caller.onObjectChange(args);
        }



        #endregion


        public override void Ping()
        {
            // do something with vp to get a pingback.

        }
    }
}