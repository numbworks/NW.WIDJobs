﻿using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NW.WIDJobs
{
    public class CategoryManager : ICategoryManager
    {

        // Fields
        // Properties
        // Constructors
        public CategoryManager() { }

        // Methods (public)
        public string GetCategoryToken(Categories category)
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

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/