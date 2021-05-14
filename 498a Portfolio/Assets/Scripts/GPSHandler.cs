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
    public List<trail_seg> Artemesia;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Artemesia = new List<trail_seg>();
        Artemesia.Add(new trail_seg(38.991461, -76.922295, 38.989659, -76.921083));
        Artemesia.Add(new trail_seg(38.989630, -76.921847, 38.987889, -76.920428));
        Artemesia.Add(new trail_seg(38.987802, -76.921096, 38.986241, -76.919720));
        Artemesia.Add(new trail_seg(38.986177, -76.920813, 38.983471, -76.918876));
        Artemesia.Add(new trail_seg(38.983436, -76.923055, 38.981209, -76.919289));
        Artemesia.Add(new trail_seg(38.985504, -76.925711, 38.983445, -76.920657));
        Artemesia.Add(new trail_seg(38.987790, -76.925453, 38.984962, -76.923908));
        Artemesia.Add(new trail_seg(38.987889, -76.923654, 38.984976, -76.921105));
        Artemesia.Add(new trail_seg(38.991340, -76.924014, 38.987715, -76.922763));
        UpdateLocation();
    }

    public int UpdateLocation()
    {
        if (Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
        }
        else return -1;
        if (lat < Artemesia[0].st_lat && lat > Artemesia[0].end_lat && lon > Artemesia[0].st_lon && lon < Artemesia[0].end_lon)
            return 0;
        else if (lat < Artemesia[1].st_lat && lat > Artemesia[1].end_lat && lon > Artemesia[1].st_lon && lon < Artemesia[1].end_lon)
            return 1;
        else if (lat < Artemesia[2].st_lat && lat > Artemesia[2].end_lat && lon > Artemesia[2].st_lon && lon < Artemesia[2].end_lon)
            return 2;
        else if (lat < Artemesia[3].st_lat && lat > Artemesia[3].end_lat && lon > Artemesia[3].st_lon && lon < Artemesia[3].end_lon)
            return 3;
        else if (lat < Artemesia[4].st_lat && lat > Artemesia[4].end_lat && lon > Artemesia[4].st_lon && lon < Artemesia[4].end_lon)
            return 4;
        else if (lat < Artemesia[5].st_lat && lat > Artemesia[5].end_lat && lon > Artemesia[5].st_lon && lon < Artemesia[5].end_lon)
            return 5;
        else if (lat < Artemesia[6].st_lat && lat > Artemesia[6].end_lat && lon > Artemesia[6].st_lon && lon < Artemesia[6].end_lon)
            return 6;
        else if (lat < Artemesia[7].st_lat && lat > Artemesia[7].end_lat && lon > Artemesia[7].st_lon && lon < Artemesia[7].end_lon)
            return 7;
        else if (lat < Artemesia[8].st_lat && lat > Artemesia[8].end_lat && lon > Artemesia[8].st_lon && lon < Artemesia[8].end_lon)
            return 7;
        else
            return 9;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
