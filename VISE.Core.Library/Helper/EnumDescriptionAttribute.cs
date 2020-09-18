using System;
using System.Collections.Generic;
using System.Text;

namespace VISE.Core.Library.Helper
{
    #region class ArgumentAttribute
    /// <summary>
    /// Provides a description for an enumerated type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        #region class-wide fields
        private string description;
        #endregion

        #region private and internal properties and methods

        #region properties

        #endregion

        #region methods

        #endregion

        #endregion

        #region public properties and methods

        #region properties

        #region Description
        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string Description
        {
            get
            {
                return this.description;
            }
        }
        #endregion

        #endregion

        #region methods

        #region constructor
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="EnumDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The description to store in this attribute.</param>
        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion
}
