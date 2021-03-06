// <copyright file="DbHelperTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections.Generic;
using CRUDExample;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUDExample.Tests
{
    /// <summary>This class contains parameterized unit tests for DbHelper</summary>
    [PexClass(typeof(DbHelper))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DbHelperTest
    {
        /// <summary>Test stub for ManageDb(String, String)</summary>
        [PexMethod]
        public List<Product> ManageDbTest(string conString, string dbName)
        {
            List<Product> result = DbHelper.ManageDb(conString, dbName);
            return result;
            // TODO: add assertions to method DbHelperTest.ManageDbTest(String, String)
        }
    }
}
