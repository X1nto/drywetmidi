﻿using System;

namespace Melanchall.DryWetMidi.Multimedia
{
    internal static class TickGeneratorSession
    {
        #region Fields

        private static readonly object _lockObject = new object();

        private static IntPtr _handle;

        #endregion

        #region Methods

        public static IntPtr GetSessionHandle()
        {
            lock (_lockObject)
            {
                if (_handle == IntPtr.Zero)
                {
                    var apiType = CommonApiProvider.Api.Api_GetApiType();
                    NativeApi.HandleResult(
                        TickGeneratorSessionApiProvider.Api.Api_OpenSession(out _handle));
                }

                return _handle;
            }
        }

        #endregion
    }
}
