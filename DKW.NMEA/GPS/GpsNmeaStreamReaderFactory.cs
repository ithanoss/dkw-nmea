﻿namespace DKW.NMEA.GPS
{
    using Microsoft.Extensions.Logging;

    public class GpsNmeaStreamReaderFactory
    {
        public NmeaStreamReader Create(ILogger<NmeaStreamReader> logger = null)
        {
            var nsr = new NmeaStreamReader(logger);

            nsr.Register(new GGA());
            nsr.Register(new GSA());
            nsr.Register(new GSV());
            nsr.Register(new RMC());
            nsr.Register(new GLL());

            return nsr;
        }
    }
}
