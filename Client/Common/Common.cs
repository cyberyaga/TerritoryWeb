using System.Collections.Generic;
using GoogleMapsComponents.Maps;

public class Common
{
    public static LatLngLiteral Compute2DPolygonCentroid(List<LatLngLiteral> vertices)
    {
        LatLngLiteral centroid = new LatLngLiteral() {  Lat = 0.0, Lng = 0.0 };
        double signedArea = 0.0;
        double x0 = 0.0; // Current vertex X
        double y0 = 0.0; // Current vertex Y
        double x1 = 0.0; // Next vertex X
        double y1 = 0.0; // Next vertex Y
        double a = 0.0;  // Partial signed area

        //If no vertices, then return empty
        if (vertices.Count == 0)
        {
            return centroid;
        }

        // For all vertices except last
        int i=0;
        for (i = 0; i < vertices.Count - 1; ++i)
        {
            x0 = vertices[i].Lat;
            y0 = vertices[i].Lng;
            x1 = vertices[i+1].Lat;
            y1 = vertices[i+1].Lng;
            a = x0*y1 - x1*y0;
            signedArea += a;
            centroid.Lat += (x0 + x1)*a;
            centroid.Lng += (y0 + y1)*a;
        }

        // Do last vertex
        x0 = vertices[i].Lat;
        y0 = vertices[i].Lng;
        x1 = vertices[0].Lat;
        y1 = vertices[0].Lng;
        a = x0*y1 - x1*y0;
        signedArea += a;
        centroid.Lat += (x0 + x1)*a;
        centroid.Lng += (y0 + y1)*a;

        signedArea *= 0.5F;
        centroid.Lat /= (6*signedArea);
        centroid.Lng /= (6*signedArea);

        return centroid;
    }
}