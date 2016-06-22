using System;
using System.Linq;
using IronRebuilder.Attributes;

namespace TypeSafeEnums
{
    /// <summary>
    /// A delegate for parsing an enum from a string
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="value">The value to parse.</param>
    /// <returns>The parsed enum</returns>
    delegate T EnumParser<[GenericEnum]T>(string value);

    /// <summary>
    /// A delegate for an enum consumer
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="value">The value to consume.</param>
    delegate void EnumConsumer<[GenericEnum]T>(T value);

    /// <summary>
    /// A delegate for producing an enum
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <returns>The produced enum</returns>
    delegate T EnumProducer<[GenericEnum]T>();

    /// <summary>
    /// A delegate for selecting between two enums
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="value1">The first value to select between.</param>
    /// <param name="value2">The second value to select between.</param>
    /// <returns>The chosen value</returns>
    delegate T EnumSelector<[GenericEnum]T>(T value1, T value2);

    /// <summary>
    /// Compares two enums and returns a value indicating whether one is less than, equal to, or greater than the other.
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="value1">The first enum to compare.</param>
    /// <param name="value2">The second enum to compare.</param>
    /// <returns>
    /// A signed integer that indicates the relative values of value1 and value2.
    /// A -ve number indicates value1 &lt; value2, 0 indicates value1 = value 2 and a +ve number indicates value1 &gt; value2
    /// </returns>
    delegate int EnumComparer<[GenericEnum]T>(T value1, T value2);

    /// <summary>
    /// This class is a helper that assures type-safe <see cref="Enum"/>'s static methods
    /// </summary>
    public static class TypeSafeEnum
    {
        /// <summary>
        /// Converts the specified value of <typeparamref name="T"/> to its equivalent string representation according to the specified format.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="format">The output format to use. </param>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns>A string representation of value</returns>
        public static string Format<[GenericEnum]T>(T value, string format) => Enum.Format(typeof(T), value, format);

        /// <summary>
        /// Retrieves the name of the constant in the specified enumeration that has the specified value.
        /// </summary>
        /// <param name="value">The value of a particular enumerated constant in terms of its underlying type</param>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns>A string containing the name of the enumerated constant in <typeparamref name="T"/> whose value is value; or null if no such constant is found.</returns>
        public static string GetName<[GenericEnum]T>(T value) => Enum.GetName(typeof(T), value);

        /// <summary>
        /// Retrieves an array of the names of the constants in a specified enumeration.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns>
        /// A string array of the names of the constants in <typeparamref name="T"/>.
        /// </returns>
        public static string[] GetNames<[GenericEnum]T>() => Enum.GetNames(typeof(T));

        /// <summary>
        ///  Returns the underlying type of the specified enumeration.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns>The underlying type of <typeparamref name="T"/>.</returns>
        public static Type GetUnderlyingType<[GenericEnum]T>() => Enum.GetUnderlyingType(typeof(T));

        /// <summary>
        /// Retrieves an array of the values of the constants in a specified enumeration.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns> An array that contains the values of the constants in <typeparamref name="T"/>. </returns>
        public static T[] GetValues<[GenericEnum]T>() => Enum.GetValues(typeof(T)).Cast<T>().ToArray();

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <param name="value"> A string containing the name or value to convert. </param>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns> An object of type <typeparamref name="T"/> whose value is represented by value. </returns>
        public static T Parse<[GenericEnum]T>(string value) => (T)Enum.Parse(typeof(T), value);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.  A parameter specifies whether the operation is case-sensitive.
        /// </summary>
        /// <param name="value"> A string containing the name or value to convert. </param>
        /// <param name="ignoreCase">True to ignore case; false to regard case</param>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns> An object of type <typeparamref name="T"/> whose value is represented by value. </returns>
        public static T Parse<[GenericEnum]T>(string value, bool ignoreCase)
            => (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}