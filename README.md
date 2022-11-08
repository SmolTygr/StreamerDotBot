# OBS 28.x.x

On the new OBS 28 update they have changed how the OBS Websocket bits work.  It is now native in OBS and not reliant on a third party plugin.

Part of this change has been a significant change in the API, which likely has broken some old streamer.bot scripts.

This repo is here to document the changes we have found / examples / fixes.

<br>

---

## SceneItemProperties

GetSceneItemProperties and SetSceneItemProperties have both been removed. This was the way of setting an objects position/rotation.

GetSceneItemTransform and SetSceneItemTransform has replaced both of these methods. However, you <i> cannot </i> call this method solely with source and scene names. <b> You need scene name and source id </b>.

Example of this is found in: obs28_position_source.cs

<br>

---

## Source ID

Currently do not know a method of accessing source id from the graphical user interface. Instead you need to use a OBSRawRequest for "GetSceneItemId".

It does not appear that the ID changes unless you delete / recreate the object. So rather than querying the object in each script, you could store the values and access them later. 


