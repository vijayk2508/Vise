using VISE.Core.Library.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VISE.Core.Library.Enum
{
    public class ExampleEnum
    {
        public enum eStaffRole {
            [EnumDescription("Select")]
            None=0,
            [EnumDescription("Admin")]
            Admin,

            [EnumDescription("Accountant")]
            Accountant,

            [EnumDescription("Faculty")]
            Faculty,

            [EnumDescription("Librarian")]
            Librarian
        }

        public enum eStaffJOBType
        {
            [EnumDescription("Select")]
            None=0,

            [EnumDescription("Contratual")]
            Contratual,

            [Description("Regular")]
            Regular,
        }

        public enum eStaffStatus
        {
            [EnumDescription("Select")]
            None=0,

            [EnumDescription("Active")]
            Active,

            [EnumDescription("InActive")]
            InActive,
        }

        public enum eBookStatus
        {
            [EnumDescription("Select")]
            None=0,

            [EnumDescription("Available")]
            Available,

            [EnumDescription("Unavailable")]
            Unavailable,
        }

        public enum eStatus
        {
            [EnumDescription("Select")]
            None = 0,

            [EnumDescription("Available")]
            Available,

            [EnumDescription("Unavailable")]
            Unavailable,
        }
    }
}
