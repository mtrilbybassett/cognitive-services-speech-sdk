//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.CognitiveServices.Speech.Translation
{
    /// <summary>
    /// Define payload of translation recognizing/recognized events.
    /// </summary>
    public class TranslationRecognitionEventArgs : RecognitionEventArgs
    {
        internal TranslationRecognitionEventArgs(Microsoft.CognitiveServices.Speech.Internal.TranslationRecognitionEventArgs e)
            : base(e)
        {
            eventArgImpl = e;
            Result = new TranslationRecognitionResult(e.GetResult());
        }

        /// <summary>
        /// Specifies the recognition result.
        /// </summary>
        public TranslationRecognitionResult Result { get; }

        /// <summary>
        /// Returns a string that represents the speech recognition result event.
        /// </summary>
        /// <returns>A string that represents the speech recognition result event.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,"SessionId:{0} Result:{1}.", SessionId, Result.ToString());
        }

        // Hold the reference
        Microsoft.CognitiveServices.Speech.Internal.TranslationRecognitionEventArgs eventArgImpl;
    }

    /// <summary>
    /// Define payload of translation text result recognition canceled result events.
    /// </summary>
    public sealed class TranslationRecognitionCanceledEventArgs : TranslationRecognitionEventArgs
    {
        internal TranslationRecognitionCanceledEventArgs(Microsoft.CognitiveServices.Speech.Internal.TranslationRecognitionCanceledEventArgs e)
            : base(e)
        {
            eventArgImpl = e;
            var cancellation = e.GetCancellationDetails();
            Reason = (CancellationReason)cancellation.Reason;
            ErrorDetails = cancellation.ErrorDetails;
        }

        /// <summary>
        /// The reason the recognition was canceled.
        /// </summary>
        public CancellationReason Reason { get; }

        /// <summary>
        /// In case of an unsuccessful recognition, provides a details of why the occurred error.
        /// This field is only filled-out if the reason canceled (<see cref="Reason"/>) is set to Error.
        /// </summary>
        public string ErrorDetails { get; }

        /// <summary>
        /// Returns a string that represents the speech recognition result event.
        /// </summary>
        /// <returns>A string that represents the speech recognition result event.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,"SessionId:{0} Result:{1} CancellationReason:{2}.", SessionId, Result.ToString(), Reason);
        }

        // Hold the reference
        Microsoft.CognitiveServices.Speech.Internal.TranslationRecognitionCanceledEventArgs eventArgImpl;
    }
}