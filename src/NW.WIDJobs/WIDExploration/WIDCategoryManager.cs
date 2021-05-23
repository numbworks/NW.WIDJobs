using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IWIDCategoryManager"/></summary>
    public class WIDCategoryManager : IWIDCategoryManager
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDCategoryManager"/> instance.</summary>
        public WIDCategoryManager() { }

        #endregion

        #region Methods_public

        public string GetCategoryToken(WIDCategories category)
        {

            DescriptionAttribute attribute =
                (DescriptionAttribute)category.GetType()
                    .GetTypeInfo()
                    .GetMember(category.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault();

            return attribute?.Description ?? category.ToString();

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/