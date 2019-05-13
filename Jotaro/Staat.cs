using System;
using System.Collections.Generic;

namespace Jotaro
{
    public class Staat
    {
        #region Constructor

        public Staat(string countryCode, int parameter, float longitude, float latitude)
        {
            CountryCode = countryCode;
            Parameter = parameter;
            Longitude = longitude;
            Latitude = latitude;
            Neighbours = new List<string>();
        }

        #endregion

        #region members

        #endregion


        #region properties

        public string CountryCode { get; }

        public int Parameter { get; }

        public float Longitude { get; } //y value of the center

        public float Latitude { get; } //x value of the center

        public List<string> Neighbours { get; }

        public float XMax { get; private set; }

        public float XMin { get; private set; }

        public float YMax { get; private set; }

        public float YMin { get; private set; }

        public float Radius { get; private set; }

        #endregion

        #region methods

        public void CalculateRadius()
        {
            double parameter = Parameter;
            Radius = (float) Math.Sqrt(parameter / Math.PI);
        }


        public void CalculateExtremePoints()
        {
            XMax = Latitude + Radius;
            XMin = Latitude - Radius;
            YMax = Longitude + Radius;
            YMin = Longitude - Radius;
        }

        #endregion
    }
}