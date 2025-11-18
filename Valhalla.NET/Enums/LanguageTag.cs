// ----------------------------------------------------------------------------
// <copyright file="LanguageTag.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Enums
{
    /// <summary>
    /// An enum to represent the supported language tags.
    /// </summary>
    public enum LanguageTag
    {
        /// <summary>
        /// Czech.
        /// </summary>
        Cs,

        /// <summary>
        /// Danish.
        /// </summary>
        Da,

        /// <summary>
        /// German.
        /// </summary>
        De,

        /// <summary>
        /// English.
        /// </summary>
        En,

        /// <summary>
        /// English (Pirate).
        /// </summary>
        [JsonPropertyName("en-x-pirate")]
        EnXPirate,

        /// <summary>
        /// Spanish.
        /// </summary>
        Es,

        /// <summary>
        /// Estonian.
        /// </summary>
        Et,

        /// <summary>
        /// Finnish.
        /// </summary>
        Fi,

        /// <summary>
        /// French.
        /// </summary>
        Fr,

        /// <summary>
        /// Hindi.
        /// </summary>
        Hi,

        /// <summary>
        /// Hungarian.
        /// </summary>
        Hu,

        /// <summary>
        /// Indonesian.
        /// </summary>
        Id,

        /// <summary>
        /// Italian.
        /// </summary>
        It,

        /// <summary>
        /// Japanese.
        /// </summary>
        Ja,

        /// <summary>
        /// Dutch.
        /// </summary>
        Nl,

        /// <summary>
        /// Norwegian.
        /// </summary>
        No,

        /// <summary>
        /// Polish.
        /// </summary>
        Pl,

        /// <summary>
        /// Portuguese.
        /// </summary>
        Pt,

        /// <summary>
        /// Romanian.
        /// </summary>
        Ro,

        /// <summary>
        /// Russian.
        /// </summary>
        Ru,

        /// <summary>
        /// Slovak.
        /// </summary>
        Sk,

        /// <summary>
        /// Swedish.
        /// </summary>
        Sv,

        /// <summary>
        /// Turkish.
        /// </summary>
        Tr,

        /// <summary>
        /// Ukrainian.
        /// </summary>
        Uk,

        /// <summary>
        /// Vietnamese.
        /// </summary>
        Vi,

        /// <summary>
        /// Chinese.
        /// </summary>
        Zh,

        /// <summary>
        /// Chinese (Traditional).
        /// </summary>
        Zh_Hant,
    }
}
