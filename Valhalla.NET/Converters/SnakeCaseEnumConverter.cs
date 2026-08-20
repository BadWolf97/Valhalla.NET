// ----------------------------------------------------------------------------
// <copyright file="SnakeCaseEnumConverter.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace FPH.ValhallaNET.Converters
{
    /// <summary>
    /// A string enum converter that maps PascalCase enum members (e.g. <c>CableCar</c>) to the
    /// lower snake_case values Valhalla uses in its JSON responses (e.g. <c>cable_car</c>).
    /// </summary>
    /// <remarks>
    /// <see cref="JsonPropertyNameAttribute"/> on individual enum members is not honored by
    /// <see cref="JsonStringEnumConverter{TEnum}"/>, so multi-word enum values need this naming
    /// policy instead.
    /// </remarks>
    /// <typeparam name="TEnum">The enum type to convert.</typeparam>
    public class SnakeCaseEnumConverter<TEnum> : JsonStringEnumConverter<TEnum>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeCaseEnumConverter{TEnum}"/> class.
        /// </summary>
        public SnakeCaseEnumConverter()
            : base(JsonNamingPolicy.SnakeCaseLower)
        {
        }
    }
}
