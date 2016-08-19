using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.Tests.Services
{
    [TestClass]
    class ProjectServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Mock<Project> projects = new Mock<Project>();
        }

        [TestMethod]
        public void FindAll()
        {
            //Mock database interaction

            //assert that the type is correct
            //assert that all of the projects are contained in the output
        }
    }
}
