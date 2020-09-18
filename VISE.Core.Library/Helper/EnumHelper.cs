using VISE.Core.Library.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace VISE.Core.Library.Helper
{
    #region EnumHelper
    /// <summary>
    /// Provides a static utility object of methods and properties to interact with enumerated types. 
    /// </summary>
    public static class EnumHelper
    {
        #region methods

        #region GetValueFromDescription
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
           return default(T);
        }
        #endregion

        #region GetDescription
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> of an <see cref="Enum"/> type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> type value.</param>
        /// <returns>A string containing the text of the <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }
        #endregion

        #region ToExtendedList
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToExtendedList<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("It should be enum", @"type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = System.Enum.GetValues(type);

            foreach (System.Enum value in enumValues)
            {
                list.Add(new KeyValueTriplet<System.Enum, T, string>(value, (T)Convert.ChangeType(value, typeof(T), System.Globalization.CultureInfo.InvariantCulture), GetDescription(value)));
            }

            return list;
        }
        #endregion

        #region ToList

        #region ToList(this Type type)
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("", @"type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = System.Enum.GetValues(type);

            foreach (System.Enum value in enumValues)
            {
                list.Add(new KeyValuePair<System.Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
        #endregion

        #region ToList<T>(this Type type)
        /// <summary>
        ///  Converts the <see cref="Enum"/> type to an <see cref="IList"/> compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList"/> containing the enumerated type value and description.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This is a more advanced use of the ToList function; providing a type parameter has no semantic meaning for this function and would actually make the calling syntax more complicated.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IList ToList<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new ArgumentException("", "type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = System.Enum.GetValues(type);

            foreach (System.Enum value in enumValues)
            {
                list.Add(new KeyValuePair<T, string>((T)Convert.ChangeType(value, typeof(T), System.Globalization.CultureInfo.InvariantCulture), GetDescription(value)));
            }

            return list;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion
}
