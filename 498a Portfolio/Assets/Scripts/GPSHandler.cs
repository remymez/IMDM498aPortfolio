using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSHandler : MonoBehaviour
{
    public struct trail_seg
    {
        
        public trail_seg (double startLat, double startLon, double endLat, double endLon)
        {
            st_lat = startLat;
            st_lon = startLon;
            end_lat = endLat;
            end_lon = endLon;
        }
        public double st_lat { get; }
        public double st_lon { get; }
        public double end_lat { get; }
        public double end_lon { get; }
    }

    
    private float lat;
    private float lon;
    private List<trail_seg> Artemesia;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Artemesia = new List<trail_seg>();
        Artemesia.Add(new trail_seg(38.991166, -76.919150, 38.982376, -76.926038));
        
        UpdateLocation();
    }

    private void UpdateLocation()
    {
        if (Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
