// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccurredAndLogIt()
        {
            //given
            var serviceException = new Exception();

            var failedPersonServiceExcpetion =
                new FailedPersonServiceException(serviceException);

            var expectedPersonServiceException =
                new PersonServiceException(failedPersonServiceExcpetion);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAllPersons())
                 .Throws(serviceException);

            //when
            Action retrieveAllAction = () => this.personService.RetrieveAllPersons();

            //then
            Assert.Throws<PersonServiceException>(retrieveAllAction);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectAllPersons(),
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