using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CPHInline
{
	public bool Execute()
	{
        CPH.SendMessage("Starting OBS28 Websocket Source Example");

        string scene = "Popups";
        string source = "cucumber_sprite";

        // First we need to do get the ID of the item in OBS
        //
        // Generate the request. Using JOBjects (you can simply use json strings
        // This is just my prefered method)
        var request_json = new JObject();
        request_json["sceneName"] = scene;
        request_json["sourceName"] = source;

        // Query OBS to get the ID
        //
        // Converting to a JObject to access "sceneItemId" as it returns
        // a single long string. Easy to query objects like this, especially if
        // lots of information is returned
        var response = CPH.ObsSendRaw("GetSceneItemId", request_json.ToString());
        var obs_id = JObject.Parse(response)["sceneItemId"];
        CPH.SendMessage($"I got the item ID: {obs_id}");

        // Now we can query the transform of the obs object
        // This is not necessary for setting a transform, but is here so the full
        // list of parameters/names can be easily found (in the streamer.bot logs)
        //
        // We have to query using the item ID. New JObject to be made
        var transform_json = new JObject();
        transform_json["sceneName"] = "Popups";
        transform_json["sceneItemId"] = obs_id;
        var transform_response = CPH.ObsSendRaw("GetSceneItemTransform", transform_json.ToString());
        CPH.LogDebug(transform_response);

        // Generate the sceneItemTransform JSON object
        //
        // We could have made a JObject from the query above and edit
        // the values we wanted.
        var transform = new JObject();
        transform["positionX"] = 500;
        transform["positionY"] = 500;

        // Leverage the transform_json from before
        transform_json["sceneItemTransform"] = transform;

        // Send the request
        CPH.ObsSendRaw("SetSceneItemTransform", transform_json.ToString());
        

        CPH.SendMessage("Finishing OBS28 Websocket Source Example");
		return true;
	}
}
