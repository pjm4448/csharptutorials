using solid_principles_in_c_sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace solid_principles_in_c_sharp.Tests
{
    public class InterfaceSegregationUnitTests
    {
        [Fact]
        public void Programmer_WorkOnTask_DoesNotThrowException()
        {
            // Arrange
            var programmer = new Programmer();

            // Act & Assert
            var exception = Record.Exception(() => programmer.WorkOnTask());
            Assert.Null(exception);
        }

        [Fact]
        public void Manager_AssignTask_DoesNotThrowException()
        {
            // Arrange
            var manager = new Manager();

            // Act & Assert
            var exception = Record.Exception(() => manager.AssignTask());
            Assert.Null(exception);
        }

        [Fact]
        public void Manager_CreateSubTask_DoesNotThrowException()
        {
            // Arrange
            var manager = new Manager();

            // Act & Assert
            var exception = Record.Exception(() => manager.CreateSubTask());
            Assert.Null(exception);
        }

        [Fact]
        public void TeamLead_AssignTask_DoesNotThrowException()
        {
            // Arrange
            var teamLead = new TeamLead();

            // Act & Assert
            var exception = Record.Exception(() => teamLead.AssignTask());
            Assert.Null(exception);
        }

        [Fact]
        public void TeamLead_CreateSubTask_DoesNotThrowException()
        {
            // Arrange
            var teamLead = new TeamLead();

            // Act & Assert
            var exception = Record.Exception(() => teamLead.CreateSubTask());
            Assert.Null(exception);
        }

        [Fact]
        public void TeamLead_WorkOnTask_DoesNotThrowException()
        {
            // Arrange
            var teamLead = new TeamLead();

            // Act & Assert
            var exception = Record.Exception(() => teamLead.WorkOnTask());
            Assert.Null(exception);
        }
    }
}

