// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccurAndLogIt()
        {
            //given
            Person somePerson = CreateRandomPerson();
            var serviceException = new Exception();

            var failedPersonServiceException =
               new FailedPersonServiceException(serviceException);

            var expectedPersonServiceException =
                new PersonServiceException(failedPersonServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.InsertPerson(It.IsAny<Person>()))
                   .Throws(serviceException);

            //when
            Action addPersonAction = () => this.personService.AddPerson(somePerson);

            //then
            Assert.Throws<PersonServiceException>(addPersonAction);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertPerson(It.IsAny<Person>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                  expectedPersonServiceException))),
                      Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}