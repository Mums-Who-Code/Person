// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnIfRemoveServiceErrorOccurAndLogIt()
        {
            //given
            Person somePerson = CreateRandomPerson();
            var serviceException = new Exception();

            var failedPersonServiceException =
                new FailedPersonServiceException(
                    serviceException);

            var excpectedPersonServiceException =
                new PersonServiceException(
                    failedPersonServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.DeletePerson(It.IsAny<Person>()))
                    .Throws(serviceException);

            //when
            Action removePersonAction = () => this.personService.RemovePerson(somePerson);

            //then
            Assert.Throws<PersonServiceException>(removePersonAction);

            this.storageBrokerMock.Verify(broker =>
                broker.DeletePerson(It.IsAny<Person>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    excpectedPersonServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}