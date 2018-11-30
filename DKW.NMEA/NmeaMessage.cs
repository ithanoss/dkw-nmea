﻿/*
DKW.NMEA
Copyright (C) 2018 Doug Wilson

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace DKW
{
    using System;
    using System.Buffers;
    using DKW.NMEA.Parsing;

    public abstract class NmeaMessage
    {
        protected abstract ReadOnlyMemory<Byte> Key { get; }

        public virtual Boolean CanHandle(ReadOnlySequence<Byte> sentence) => sentence.Slice(0, 6).IsMatch(Key.Span);
        public abstract NmeaMessage Parse(ReadOnlySequence<Byte> sentence);

        /// <summary>
        /// Checksum
        /// </summary>
        public Int32 Checksum { get; protected set; }
    }
}
