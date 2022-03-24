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
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccureAndLogIt()
        {
            //given
            Person someperson = CreateRandomPerson();
            var ServiceException = new Exception();

            var failedPersonServiceException =
                new FailedPersonServiceException(ServiceException);

            var expectedPersonServiceException =
                new PersonServiceException(
                    failedPersonServiceException);

            this.storagebrokermock.Setup(broker =>
              broker.InsertPerson(It.IsAny<Person>()))
               .Throws(ServiceException);


            //when
            Action addPersonAction = () => this.personService.AddPerson(someperson);


            //then
            Assert.Throws<PersonServiceException>(addPersonAction);

            this.storagebrokermock.Verify(broker =>
              broker.InsertPerson(It.IsAny<Person>()),
               Times.Once());

            this.loggingBrokerMock.Verify(broker =>
             broker.LogError(It.Is(SameExceptionAs(
                 expectedPersonServiceException))),
               Times.Once);

            this.storagebrokermock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }
    }
}